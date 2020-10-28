using System;
using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public enum ViolationLevel
    {
        Information,
        Warning,
        Error
    }
    public interface IViolation
    {
        IOfficeDocument Document { get; }
        Object Object { get; }
        ViolationLevel Level { get; }
        IDictionary<string, object> Data { get; }
        ICheckResult CheckResult { get; } 
    }
}
