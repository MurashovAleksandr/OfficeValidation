using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class MultiLog : ISessionLog
    {
        readonly ISession _session;
        public ISession Session
        {
            get { return _session; }
        }
        readonly IList<ILogMessage> _messages = new List<ILogMessage>();
        public ILogMessage[] Messages => _messages.ToArray();

        readonly IList<Action<ILogMessage>> _handlers = new List<Action<ILogMessage>>();
        public IList<Action<ILogMessage>> Handlers
        {
            get { return _handlers; }
        }

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

            // call message handlers
            foreach (var handler in _handlers)
            {
                handler(message);
            }
        }
    }
}
