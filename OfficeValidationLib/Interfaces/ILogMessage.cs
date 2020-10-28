using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Interfaces
{
    public interface ILogMessage
    {
        LogMessageSeverity Severity { get; }
        string Message { get; }
        ISessionLog SessionLog { get; set; }
        object Sender { get; }
    }
}
