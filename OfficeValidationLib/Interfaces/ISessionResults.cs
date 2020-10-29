using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Результат сессии
    /// </summary>
    public interface ISessionResults
    {
        /// <summary>
        /// Результаты сессии
        /// </summary>
        IEnumerable<ICheckResult> Results { get; }

        /// <summary>
        /// Сессия
        /// </summary>
        ISession Session { get; }
    }
}
