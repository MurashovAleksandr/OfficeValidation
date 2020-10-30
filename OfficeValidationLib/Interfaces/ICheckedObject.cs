using System;

namespace OfficeValidationLib.Interfaces
{

    public interface ICheckedObject
    {
        ICheckResult CheckResult { get; }
        Object Object { get; }
    }
}
