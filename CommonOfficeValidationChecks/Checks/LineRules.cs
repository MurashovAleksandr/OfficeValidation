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
    public class LineRules : CheckBase
    {
        /// <summary>
        /// Задает допустимые междустрочные интервалы (в пунктах) для абзацев
        /// </summary>
        private float[] _lineSpacingList;

        /// <summary>
        /// Задает допустимые расстояния 'ДО' между абзацами (в линиях сетки)
        /// </summary>
        private float[] _lineUnitBeforeList;

        /// <summary>
        /// Задает допустимые расстояния 'ПОСЛЕ' между абзацами (в линиях сетки)
        /// </summary>
        private float[] _lineUnitAfterList;

        /// <summary>
        ///Задает допустимые междустрочные интервалы для абзацев
        /// </summary>
        private WdLineSpacing[] _lineSpacingRuleList;

        public override bool IsAvailable(ISession session) =>
            session.Documents.Where(x => x is WordDocument).Cast<WordDocument>().Any();

        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _lineSpacingList = (values["LineSpacingList"] as JArray).Select(x => (float)x).ToArray();
            _lineUnitBeforeList = (values["LineUnitBeforeList"] as JArray).Select(x => (float)x).ToArray();
            _lineUnitAfterList = (values["LineUnitAfterList"] as JArray).Select(x => (float)x).ToArray();
            _lineSpacingRuleList = (values["LineSpacingRuleList"] as JArray).Select(x => (WdLineSpacing)Enum.Parse(typeof(WdLineSpacing), x.Value<string>())).ToArray();
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

                    if (!_lineSpacingList.Contains(paragraph.LineSpacing) ||
                        !_lineUnitBeforeList.Contains(paragraph.LineUnitBefore) ||
                        !_lineUnitAfterList.Contains(paragraph.LineUnitAfter) ||
                        !_lineSpacingRuleList.Contains(paragraph.LineSpacingRule))
                    {
                        checkResult.Violations.Add(new Violation(
                            checkResult,
                            wordDocument,
                            paragraph.Range.Text,
                            ViolationLevel.Error,
                            new Dictionary<string, object>()
                                {
                                    {"Межстрочный интервал (пункты)", paragraph.LineSpacing},
                                    {"Расстояния 'ДО' (линии сетки)", paragraph.LineUnitBefore},
                                    {"Расстояния 'ПОСЛЕ' (линии сетки)", paragraph.LineUnitAfter},
                                    {"Межстрочные интервалы (правило)", paragraph.LineSpacingRule}
                                }));
                    }
                }
            }
            return checkResult;
        }
    }
}
