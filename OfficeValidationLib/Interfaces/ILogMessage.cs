using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Сообщение лога
    /// </summary>
    public interface ILogMessage
    {
        /// <summary>
        /// Важность
        /// </summary>
        LogMessageSeverity Severity { get; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        string Message { get; }
        /// <summary>
        /// Связанные логи сессии
        /// </summary>
        ISessionLog SessionLog { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        object Sender { get; }
    }
}
