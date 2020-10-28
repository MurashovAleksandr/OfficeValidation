using System;
using System.Collections.Generic;
using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Interfaces
{
    public interface IViolation
    {
        IDocument Document { get; }
        Object Object { get; }
        ViolationLevel Level { get; }
        IDictionary<string, object> Data { get; }
        ICheckResult CheckResult { get; } 
    }
}
