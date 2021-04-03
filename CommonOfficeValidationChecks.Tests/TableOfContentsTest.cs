using CommonOfficeValidationChecks.Checks;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Interfaces;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace CommonOfficeValidationChecks.Tests
{
    public class TableOfContentsTest
    {
        private SessionBuilder _sessionBuilder = new SessionBuilder();
        private Instance _instance;
        private WordDocumentFactory _wordDocumentFactory = new WordDocumentFactory();

        public TableOfContentsTest()
        {
            var checkAssembly = Assembly.GetAssembly(typeof(TableOfContents));
            _instance = new Instance()
            {
                Assembly = Path.GetFileName(checkAssembly.CodeBase),
                ClassName = typeof(TableOfContents).FullName,
                Name = nameof(TableOfContents)
            };
        }

        [Fact]
        public void PerformWithoutTableOfContentsTest()
        {
            var result = GetResult("WithoutTableOfContents.docx");
            int expected = 1;
            Assert.Equal(result.Violations.Count, expected);
        }

        [Fact]
        public void PerformWithTableOfContentsTest()
        {
            var result = GetResult("WithTableOfContents.docx");
            int expected = 0;
            Assert.Equal(result.Violations.Count, expected);
        }

        private ICheckResult GetResult(string fileName)
        {
            using (var document = _wordDocumentFactory.Create(Path.Combine("Documents", fileName)))
            {
                using (var session = _sessionBuilder.Build(new[] { _instance }, new[] { document }))
                {
                    return session.Checks.First(x => x.Name == _instance.Name).Perform(session); 
                }
            }
        }
    }
}
