using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionManager : IDisposable
    {
        readonly SessionBuilder _builder = new SessionBuilder();
        private readonly Config _config;
        public Config Config => _config;
        readonly IList<ISession> _sessions = new List<ISession>();
        readonly IDatabaseManager _databaseManager;
        public ISession[] Sessions => _sessions.ToArray();

        public SessionManager(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
            _config = new Config()
            {
                Instances = _databaseManager.GetInstances().ToArray(),
                DocumentFactoryNames = _databaseManager.GetDocumentFactoryNames().ToArray()
            };
        }

        [Obsolete("Вместо конфигурационного файла используйте БД", true)]
        public SessionManager(Config config)
        {
            _config = config;
        }

        [Obsolete("Вместо конфигурационного файла используйте БД", true)]
        public SessionManager(string configPath) : 
            this(JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath)))
        {

        }
        public ISession Create(IEnumerable<Instance> instances, IEnumerable<IDocument> documents)
        {
            var session = _builder.Build(instances, documents);
            _sessions.Add(session);
            return session;
        }

        public void Dispose()
        {
            foreach (var session in Sessions)
            {
                session.Dispose();
            }
            _databaseManager.Dispose();
        }
    }
}
