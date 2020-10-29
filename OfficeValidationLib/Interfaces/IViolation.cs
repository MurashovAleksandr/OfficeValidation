using System;
using System.Collections.Generic;
using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Нарушение
    /// </summary>
    public interface IViolation
    {
        /// <summary>
        /// Документ
        /// </summary>
        IDocument Document { get; }
        /// <summary>
        /// Объект, вызвавший нарушение
        /// </summary>
        Object Object { get; }
        /// <summary>
        /// Важность
        /// </summary>
        ViolationLevel Level { get; }
        /// <summary>
        /// Поля
        /// </summary>
        IDictionary<string, object> Data { get; }
        /// <summary>
        /// Связанный результат
        /// </summary>
        ICheckResult CheckResult { get; } 
    }
}
