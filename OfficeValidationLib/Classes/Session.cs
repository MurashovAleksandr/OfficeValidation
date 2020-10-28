using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class Session : ISession
    {
        public Session(IEnumerable<IOfficeDocument> documents, IList<ICheck> checks)
        {
            this.ID = DateTime.Now.Ticks;
            this.Documents = documents;
            this.Checks = checks;
        }
        public long ID { get; }
        public IEnumerable<IOfficeDocument> Documents { get; }
        public IEnumerable<ICheck> Checks { get; }
        public ISessionLog Log { get; }

        public ICheckResult[] PerformAll() =>
            Checks.Select(x => x.Perform(this)).ToArray();
    }
}
