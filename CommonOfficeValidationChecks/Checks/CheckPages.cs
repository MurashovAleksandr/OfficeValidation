using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;

namespace CommonOfficeValidationChecks.Checks
{
    public class Bookmarks : CheckBase
    {
        private long _bookmarksMinCount;
        public override bool IsAvailable(ISession session) =>
            session.Documents.Cast<WordDocument>().Any();
        protected override void InitializeParametersInternal(IDictionary<string, object> values)
        {
            _bookmarksMinCount = (long)values["BookmarksMinCount"];
        }
        protected override ICheckResult PerformInternal(ISession session)
        {
            var checkResult = new SimpleCheckResult(this);
            var wordDocuments = session.Documents.Cast<WordDocument>().ToArray();
            foreach (var wordDocument in wordDocuments)
            {
                checkResult.CheckedObjects.Add(wordDocument);
                var bookmarks = wordDocument.Document.Bookmarks;
                if (bookmarks == null || bookmarks.Count < _bookmarksMinCount)
                {
                    checkResult.Violations.Add(new SimpleViolation(
                        checkResult,
                        wordDocument,
                        wordDocument,
                        ViolationLevel.Error,
                        new Dictionary<string, object>()
                    {
                        {"Кол-во закладок", bookmarks?.Count}
                    }));
                }
            }

            return checkResult;
        }
    }
}
