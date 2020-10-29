using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Результат проверки
    /// </summary>
    public interface ICheckResult
    {
        /// <summary>
        /// Проверка
        /// </summary>
        ICheck Check { get; }
        /// <summary>
        /// Список проверенных объектов
        /// </summary>
        IList<object> CheckedObjects { get; }
        /// <summary>
        /// Список нарушений
        /// </summary>
        IList<IViolation> Violations { get; }
    }
}
