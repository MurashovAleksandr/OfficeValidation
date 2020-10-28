using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionManager
    {
        readonly SessionBuilder _builder = new SessionBuilder();
        readonly Config _config;
        readonly IEnumerable<IDocument> _documents;
        readonly IList<ISession> _sessions = new List<ISession>();
        public ISession[] Sessions => _sessions.ToArray();

        public SessionManager(Config config, IEnumerable<IDocument> documents)
        {
            _config = config;
            _documents = documents;
        }

        public SessionManager(string configPath, IEnumerable<IDocument> documents)
        {
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
            _documents = documents;
        }
        public ISession Create()
        {
            var session = _builder.Build(_config, _documents);
            _sessions.Add(session);
            return session;
        }
    }
}
