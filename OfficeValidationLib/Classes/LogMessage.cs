using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class LogMessage : ILogMessage
    {
        private LogMessageSeverity _severity;
        public LogMessageSeverity Severity => _severity;
        private string _message;
        public string Message => _message;
        public ISessionLog SessionLog { get; set; }
        private object _sender;
        public object Sender => _sender;

        public LogMessage(LogMessageSeverity severity, string message, object sender)
        {
            _severity = severity;
            _message = message;
            _sender = sender;
        }
        public LogMessage(LogMessageSeverity severity, string message)
            : this(severity, message, null)
        {

        }
    }
}
