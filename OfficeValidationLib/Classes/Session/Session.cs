using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class Session : ISession, IDisposable
    {
        public Session()
        {
            this.ID = DateTime.Now.Ticks;
        }
        public long ID { get; }
        public IList<IDocument> Documents { get; } = new List<IDocument>();
        public IList<ICheck> Checks { get; } = new List<ICheck>();
        public ISessionLog Log { get; set; }

        public ICheckResult[] PerformAll() =>
            Checks.Select(x => x.Perform(this)).ToArray();

        public void Dispose()
        {
            foreach (var document in Documents)
            {
                document.Dispose();
            }
        }
    }
}
