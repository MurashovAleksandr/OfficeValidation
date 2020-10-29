namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Логи сессии
    /// </summary>
    public interface ISessionLog
    {
        /// <summary>
        /// Связанная сессия
        /// </summary>
        ISession Session { get; }
        /// <summary>
        /// Сообщения
        /// </summary>
        ILogMessage[] Messages { get; }
        /// <summary>
        /// Добавление сообщений
        /// </summary>
        /// <param name="message">Текст и важность сообщения</param>
        void AddMessage(ILogMessage message);
    }
}
