using System;
using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Сессия
    /// </summary>
    public interface ISession : IDisposable
    {
        DateTime CreationDateTime { get; }
        /// <summary>
        /// Уникальный номер сессии
        /// </summary>
        int ID { get; }
        /// <summary>
        /// Список документов
        /// </summary>
        IList<IDocument> Documents { get; }
        /// <summary>
        /// Список проверок
        /// </summary>
        IList<ICheck> Checks { get; }
        /// <summary>
        /// Логи загрузки
        /// </summary>
        ISessionLog Log { get; set; }
        /// <summary>
        /// Выполнение всех проверок для текущий документов сессии
        /// </summary>
        /// <returns>Результат проверок</returns>
        ICheckResult[] PerformAll();
    }
}
