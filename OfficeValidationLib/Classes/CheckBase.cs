using System;
using System.Collections.Generic;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public abstract class CheckBase : ICheck
    {
        protected IDictionary<string, object> _parameters;
        public IDictionary<string, object> Parameters => _parameters;

        public IList<string> Tags { get; } = new List<string>();

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public abstract ICheckResult Perform(ISession session);

        public virtual bool IsAvailable(ISession session) => true;

        public virtual void InitializeDocuments(IEnumerable<IDocument> documents)
        {
            foreach (var document in documents)
            {
                document.Initialize();
            }
        }

        public void InitializeParameters(IDictionary<string, object> values)
        {
            _parameters = values;
            InitializeParametersInternal(values);
        }

        protected virtual void InitializeParametersInternal(IDictionary<string, object> values) { }
    }
}
