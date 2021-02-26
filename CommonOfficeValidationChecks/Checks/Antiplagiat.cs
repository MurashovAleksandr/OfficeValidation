using Antiplagiat.ApiCorp;
using Antiplagiat.ApiCorp.Model;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace CommonOfficeValidationChecks.Checks
{
    enum CheckTypes { Full, Short, Modules, Sources }
    public class Antiplagiat : CheckBase
    {
        private CheckTypes _checkType;
        private string _apicorpAddr;
        private string _company;
        private string _login;
        private string _password;
        private string _externalUserID;

        public override void InitializeDocuments(IEnumerable<IDocument> documents) { }

        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _apicorpAddr = (string)values["ApicorpAddr"];
            _company = (string)values["Company"];
            _login = (string)values["Login"];
            _password = (string)values["Password"];
            _externalUserID = (string)values["ExternalUserID"];
            _checkType = (CheckTypes)Enum.Parse(typeof(CheckTypes), (string)values["CheckType"]);
        }

        public override ICheckResult Perform(ISession session)
        {
            var checkResult = new CheckResult(this);

            var client = new ApiCorpClient(_company, _apicorpAddr, _login, _password).UseMtomMessageEnconding();
            foreach (var document in session.Documents)
            {
                checkResult.CheckedObjects.Add(new CheckedObject(Path.GetFileName(document.Path), checkResult));
                var docData = new DocData
                {
                    Data = File.ReadAllBytes(document.Path),
                    FileType = Path.GetExtension(document.Path),
                    FileName = Path.GetFileName(document.Path),
                    ExternalUserID = _externalUserID,
                };
                var uploadResult = client.UploadDocument(docData);
                var id = uploadResult.Uploaded.First().Id;
                client.CheckDocument(id);
                var status = client.GetCheckStatus(id);
                while (ReportStatus.InProgress == status.Status)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(status.EstimatedWaitTime.Value));
                    status = client.GetCheckStatus(id);
                }
                if (ReportStatus.Failed == status.Status)
                {
                    checkResult.Violations.Add(new Violation(
                        checkResult,
                        document,
                        Path.GetFileName(document.Path),
                        ViolationLevel.Error,
                        new Dictionary<string, object>()
                            {
                                {"Ошибка", status.FailDetails}
                            }));
                }
                else
                {
                    var report = client.GetReportView(id, new ReportViewOptions { FullReport = true, NeedText = true });
                    // Краткий отчет
                    if (_checkType == CheckTypes.Short)
                    {
                        checkResult.Violations.Add(new Violation(
                            checkResult,
                            document,
                            Path.GetFileName(document.Path),
                            ViolationLevel.Information,
                            new Dictionary<string, object>()
                                {
                                    {"Процент оригинальности", report.Summary.DetailedScore.Unknown},
                                    {"Процент заимствования", report.Summary.DetailedScore.Plagiarism},
                                    {"Процент самоцитирования", report.Summary.DetailedScore.SelfCite},
                                    {"Процент цитирования", report.Summary.DetailedScore.Legal}
                                }));
                    }
                    if(_checkType == CheckTypes.Full && report.Details.CiteBlocks != null)
                    {
                        foreach (var block in report.Details.CiteBlocks)
                        {
                            checkResult.Violations.Add(new Violation(
                                checkResult,
                                document,
                                Path.GetFileName(document.Path),
                                ViolationLevel.Information,
                                new Dictionary<string, object>()
                                    {
                                        {"Размер блока заимствования", block.Length},
                                        {"Текст заимствования", report.Details.Text.Substring(block.Offset, block.Length)}
                                    }));
                        }
                    }
                    foreach (var checkService in report.CheckServiceResults)
                    {
                        // Информация по каждому поисковому модулю
                        if (_checkType == CheckTypes.Modules)
                        {
                            checkResult.Violations.Add(new Violation(
                                checkResult,
                                document,
                                Path.GetFileName(document.Path),
                                ViolationLevel.Information,
                                new Dictionary<string, object>()
                                    {
                                        {"Название модуля поиска", checkService.CheckServiceName},
                                        {"Описание модуля поиска", checkService.CollectionDescription},
                                        {"Процент оригинальности", checkService.ScoreByReport.Unknown},
                                        {"Процент заимствования", checkService.ScoreByReport.Plagiarism},
                                        {"Процент самоцитирования", checkService.ScoreByReport.SelfCite},
                                        {"Процент цитирования", checkService.ScoreByReport.Legal}
                                    }));
                        }

                        // Информация по каждому найденному источнику
                        if (checkService.Sources == null)
                            continue;
                        foreach (var source in checkService.Sources)
                        {
                            if (_checkType == CheckTypes.Sources)
                            {
                                checkResult.Violations.Add(new Violation(
                                    checkResult,
                                    document,
                                    Path.GetFileName(document.Path),
                                    ViolationLevel.Information,
                                    new Dictionary<string, object>()
                                        {
                                            {"Источник", source.Name},
                                            {"Автор", source.Author},
                                            {"Ссылка", source.Url},
                                            {"Процент заимствования", source.ScoreBySource }
                                        }));
                            }
                        }
                    }
                }
            }

            return checkResult;
        }
    }
}
