using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonOfficeValidationChecks.Checks
{
    public class Alignment : CheckBase
    {
        /// <summary>
        /// Задает допустимые WdParagraphAlignment, представляющие выравнивание для указанных абзацев
        /// </summary>
        private WdParagraphAlignment[] _alignmentList;

        public override bool IsAvailable(ISession session) =>
            session.Documents.Where(x => x is WordDocument).Cast<WordDocument>().Any();

        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _alignmentList = (values["AlignmentList"] as JArray).Select(x => (WdParagraphAlignment)Enum.Parse(typeof(WdParagraphAlignment), x.Value<string>())).ToArray();
        }

        public override ICheckResult Perform(ISession session)
        {
            var wordDocuments = session.Documents
                            .Where(x => x is WordDocument)
                            .Cast<WordDocument>()
                            .ToArray();

            var checkResult = new CheckResult(this);

            foreach (var wordDocument in wordDocuments)
            {
                foreach (Paragraph paragraph in wordDocument.Document.Paragraphs)
                {
                    checkResult.CheckedObjects.Add(new CheckedObject(paragraph.Range.Text, checkResult));

                    if (!_alignmentList.Contains(paragraph.Alignment))
                    {
                        checkResult.Violations.Add(new Violation(
                            checkResult,
                            wordDocument,
                            paragraph.Range.Text,
                            ViolationLevel.Error,
                            new Dictionary<string, object>
                                {
                                    {"Выравнивание абзаца", _alignmentTranslate[paragraph.Alignment]}
                                }));
                    }
                }
            }
            return checkResult;
        }

        private Dictionary<WdParagraphAlignment, string> _alignmentTranslate = new()
            {
                {WdParagraphAlignment.wdAlignParagraphCenter, "Выровненный по центру"},
                {WdParagraphAlignment.wdAlignParagraphDistribute, "Символы абзаца распространяются для заполнения всей ширины абзаца"},
                {WdParagraphAlignment.wdAlignParagraphJustify, "Полностью выравниваются"},
                {WdParagraphAlignment.wdAlignParagraphJustifyHi, "По ширине при высоком коэффициенте сжатия символов"},
                {WdParagraphAlignment.wdAlignParagraphJustifyLow, "По ширине с минимальным коэффициентом сжатия символов"},
                {WdParagraphAlignment.wdAlignParagraphJustifyMed, "Выравниваются со степенью сжатия среднего символа"},
                {WdParagraphAlignment.wdAlignParagraphLeft, "Выравнивание по левому краю"},
                {WdParagraphAlignment.wdAlignParagraphRight, "Выравнивание по правому краю"},
                {WdParagraphAlignment.wdAlignParagraphThaiJustify, "Выравниваются в соответствии с разметкой тайского форматирования"}
            };
    }
}
