namespace OfficeValidationLib.Interfaces
{
    public enum LogMessageSeverity
    {
        Information,
        Warning,
        Error
    };
    public interface ILogMessage
    {
        LogMessageSeverity Severity { get; }
        string Message { get; }
        ISessionLog SessionLog { get; set; }
        object Sender { get; }
    }
}
