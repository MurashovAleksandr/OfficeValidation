using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Проверка
    /// </summary>
    public interface ICheck
    {
        /// <summary>
        /// Имя проверки
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Отображаемое описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        IDictionary<string, object> Parameters { get; }
        /// <summary>
        /// Метки
        /// </summary>
        IList<string> Tags { get; }
        /// <summary>
        /// Доступность проверки
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        bool IsAvailable(ISession session);
        /// <summary>
        /// Подготовка параметров
        /// </summary>
        /// <param name="parameters"></param>
        void InitializeParameters(IDictionary<string, object> parameters);
        /// <summary>
        /// Подготовка документов
        /// </summary>
        /// <param name="documents"></param>
        void InitializeDocuments(IEnumerable<IDocument> documents);
        /// <summary>
        /// Выполнение проверки
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        ICheckResult Perform(ISession session);
    }
}
