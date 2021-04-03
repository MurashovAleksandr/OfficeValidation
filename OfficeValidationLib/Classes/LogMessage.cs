using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class LogMessage : ILogMessage
    {
        public LogMessageSeverity Severity { get; }
        public string Message { get; }
        public ISessionLog SessionLog { get; set; }
        public object Sender { get; }

        public LogMessage(LogMessageSeverity severity, string message, object sender)
        {
            Severity = severity;
            Message = message;
            Sender = sender;
        }
        public LogMessage(LogMessageSeverity severity, string message)
            : this(severity, message, null)
        {

        }
    }
}
