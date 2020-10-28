using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ICheckResult
    {
        ICheck Check { get; }
        IEnumerable<object> AllObjects { get; }
        IEnumerable<IViolation> Violations { get; }
    }
}
