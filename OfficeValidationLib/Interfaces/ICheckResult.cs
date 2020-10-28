using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ICheckResult
    {
        ICheck Check { get; }
        IList<object> CheckedObjects { get; }
        IList<IViolation> Violations { get; }
    }
}
