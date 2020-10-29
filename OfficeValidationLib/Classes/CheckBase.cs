using System;
using System.Collections.Generic;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public abstract class CheckBase : ICheck
    {
        protected IDictionary<string, object> _parameters;
        public IDictionary<string, object> Parameters => _parameters;

        protected readonly IList<string> _tags = new List<string>();
        public IList<string> Tags => _tags;

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ICheckResult Perform(ISession session)
        {
            foreach (var sessionDocument in session.Documents)
            {
                try
                {
                    sessionDocument.Initialize();
                }
                catch (Exception exception)
                {
                    session.Log.AddMessage(new ErrorLogMessage(exception, this));
                    return null;
                }
            }
            return PerformInternal(session);
        }
        protected abstract ICheckResult PerformInternal(ISession session);

        public virtual bool IsAvailable(ISession session) => true;

        public void InitializeParameters(IDictionary<string, object> values)
        {
            _parameters = values;
            InitializeParametersInternal(values);
        }

        protected virtual void InitializeParametersInternal(IDictionary<string, object> values) { }
    }
}
