using System.Collections.Generic;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;
using System.Linq;

namespace CommonOfficeValidationChecks.Checks
{
    public class TableOfContents : CheckBase
    {
        public override bool IsAvailable(ISession session) =>
            session.Documents.Where(x => x is WordDocument).Cast<WordDocument>().Any();

        public override ICheckResult Perform(ISession session)
        {
            var wordDocuments = session.Documents
                .Where(x => x is WordDocument)
                .Cast<WordDocument>()
                .ToArray();
            var checkResult = new CheckResult(this);

            foreach (var wordDocument in wordDocuments)
            {
                checkResult.CheckedObjects.Add(new CheckedObject(wordDocument, checkResult));
                var tablesOfContents = wordDocument.Document.TablesOfContents;
                if (tablesOfContents == null || tablesOfContents.Count <= 0)
                {
                    checkResult.Violations.Add(new Violation(
                        checkResult,
                        wordDocument,
                        wordDocument,
                        ViolationLevel.Error,
                        new Dictionary<string, object>() { { "Сообщение об ошибке", "Документ без оглавления" } }));
                }
            }
            return checkResult;
        }
    }
}
