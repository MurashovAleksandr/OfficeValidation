using System;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Любой документ, имеющий путь к файлу
    /// </summary>
    public interface IDocument : IDisposable
    {
        /// <summary>
        /// Имя документа
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Путь к файлу документа
        /// </summary>
        string Path { get; }
        /// <summary>
        /// Создатель документа
        /// </summary>
        IDocumentFactory Creator { get; }
        /// <summary>
        /// Был ли документ инициализирован
        /// </summary>
        bool IsInitialized { get; }
        /// <summary>
        /// Инициализация документа (может быть произведена один раз)
        /// </summary>
        void Initialize();
    }
}
