using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class Session : ISession
    {
        public Session()
        {
            this.ID = DateTime.Now.Ticks;
        }
        public long ID { get; }
        public IList<IDocument> Documents { get; } = new List<IDocument>();
        public IEnumerable<ICheck> Checks { get; } = new List<ICheck>();
        public ISessionLog Log { get; set; }

        public ICheckResult[] PerformAll() =>
            Checks.Select(x => x.Perform(this)).ToArray();
    }
}
