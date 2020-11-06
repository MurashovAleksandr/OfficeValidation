using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class MultiLog : ISessionLog
    {
        readonly ISession _session;
        public ISession Session => _session;
        readonly IList<ILogMessage> _messages = new List<ILogMessage>();
        public ILogMessage[] Messages => _messages.ToArray();

        public MultiLog(ISession session)
        {
            _session = session;
        }
        public void AddMessage(ILogMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _messages.Add(message);
            message.SessionLog = this;
        }

        public void Save(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            foreach (var logMsg in Messages)
            {
                File.AppendAllText(filePath, $"{logMsg.Severity}\t{logMsg.Message}\t{logMsg.Sender}\n");
            }
        }
    }
}
