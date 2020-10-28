using System.Collections.Generic;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class SimpleCheckResult : ICheckResult
    {
        public SimpleCheckResult(ICheck check)
        {
            Check = check;
        }
        public ICheck Check { get; }
        public IList<object> CheckedObjects { get; } = new List<object>();
        public IList<IViolation> Violations { get; } = new List<IViolation>();
    }
}
