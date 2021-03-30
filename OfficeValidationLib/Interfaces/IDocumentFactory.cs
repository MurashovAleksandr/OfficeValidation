namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Загрузчик документов
    /// </summary>
    public interface IDocumentFactory
    {
        /// <summary>
        /// Имя типа загружаемых документов
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Поддерживаемые расширения файлов
        /// </summary>
        string[] SupportingExtension { get; }
        /// <summary>
        /// Проверка возможности создания документа
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        bool CanCreate(string path);
        /// <summary>
        /// Создание документа
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IDocument Create(string path);
    }
}
