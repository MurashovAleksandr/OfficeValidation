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
        IList<ICheckedObject> CheckedObjects { get; }
        /// <summary>
        /// Список нарушений
        /// </summary>
        IList<IViolation> Violations { get; }
        /// <summary>
        /// Сохранить результат проверки в файл
        /// </summary>
        /// <param name="filePath"></param>
        void Save(string filePath);
    }

}
