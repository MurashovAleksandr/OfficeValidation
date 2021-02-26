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
    enum CheckTypes { Short, Modules, Sources }
    public class Antiplagiat : CheckBase
    {
        private CheckTypes _checkType;
        private string _antipalgiatUrl;
        private string _apicorpAddr;
        private string _company;
        private string _login;
        private string _password;
        private string _securityDomain;
        private string _externalUserID;

        public override void InitializeDocuments(IEnumerable<IDocument> documents) { }

        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _antipalgiatUrl = (string)values["AntipalgiatUrl"];
            _apicorpAddr = (string)values["ApicorpAddr"];
            _company = (string)values["Company"];
            _login = (string)values["Login"];
            _password = (string)values["Password"];
            _securityDomain = (string)values["SecurityDomain"];
            _externalUserID = (string)values["ExternalUserID"];
            _checkType = (CheckTypes)Enum.Parse(typeof(CheckTypes), (string)values["CheckType"]);
        }

        public override ICheckResult Perform(ISession session)
        {
            var checkResult = new CheckResult(this);

            var client = new ApiCorpClient(_company, _apicorpAddr, _login, _password).UseMtomMessageEnconding();
            foreach (var document in session.Documents)
            {
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
                    var report = client.GetReportView(id);
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
                                    {"Report Summary", 100 - report.Summary.DetailedScore.Unknown},
                                    {"Legal", report.Summary.DetailedScore.Legal},
                                    {"Plagiarism", report.Summary.DetailedScore.Plagiarism},
                                    {"SelfCite", report.Summary.DetailedScore.SelfCite}
                                }));
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
                                        {"Сервис", checkService.CheckServiceName},
                                        {"Описание", checkService.CollectionDescription},
                                        {"Score by report", checkService.ScoreByReport.Unknown},
                                        {"Score white", checkService.ScoreByReport.Legal},
                                        {"Score black", checkService.ScoreByReport.Plagiarism},
                                        {"Score self cite", checkService.ScoreByReport.SelfCite}
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
                                            {"Score by report", source.ScoreByReport},
                                            {"Score by source", source.ScoreBySource }
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
