using System;
using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Classes
{
    public class ErrorLogMessage : LogMessage
    {
        public ErrorLogMessage(string message, object sender)
            : base(LogMessageSeverity.Error, message, sender)
        {
        }
        public ErrorLogMessage(string message)
            : this(message, null)
        {
        }
        public ErrorLogMessage(Exception ex, object sender)
            : this(ex != null ? ex.ToString() : "", sender)
        {
        }
        public ErrorLogMessage(Exception ex)
            : this(ex, null)
        {
        }
    }
}
