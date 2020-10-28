using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionManager
    {
        readonly SessionBuilder _builder = new SessionBuilder();
        private readonly Config _config;
        readonly IList<ISession> _sessions = new List<ISession>();
        public ISession[] Sessions => _sessions.ToArray();

        public SessionManager(Config config)
        {
            _config = config;
        }

        public SessionManager(string configPath)
        {
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
        }
        public ISession Create(IEnumerable<IDocument> documents)
        {
            var session = _builder.Build(_config, documents);
            _sessions.Add(session);
            return session;
        }
    }
}
