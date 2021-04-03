using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CommonOfficeValidationChecks.Checks
{
    public class FontSize : CheckBase
    {
        private float[] _sizeList;
        public override bool IsAvailable(ISession session) =>
            session.Documents.Where(x => x is WordDocument).Cast<WordDocument>().Any();

        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _sizeList = (values["SizeList"] as JArray)
                .Select(x => (float)x)
                .ToArray();
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
                    var paragraphText = paragraph.Range.Text;

                    if (string.IsNullOrEmpty(paragraphText)|| paragraphText.All(char.IsControl))
                        continue;
                    
                    checkResult.CheckedObjects.Add(new CheckedObject(paragraphText, checkResult));
                    if (!_sizeList.Contains(paragraph.Range.Font.Size))
                    {
                        checkResult.Violations.Add(new Violation(
                            checkResult,
                            wordDocument,
                            paragraphText,
                            ViolationLevel.Error,
                            new Dictionary<string, object>()
                                {
                                    {"Размер", paragraph.Range.Font.Size}
                                }));
                    }
                }
            }
            return checkResult;
        }
    }
}