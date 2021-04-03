using System;
using System.Collections.Generic;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    class CheckHistory : ICheck
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
        public IList<string> Tags { get; set; }
        public bool IsAvailable(ISession session) => false;

        public void InitializeParameters(IDictionary<string, object> parameters) { }

        public void InitializeDocuments(IEnumerable<IDocument> documents) { }

        public ICheckResult Perform(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
