using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class Session : ISession
    {
        public DateTime CreationDateTime { get; } = DateTime.Now;
        public int ID { get; } = (int)DateTime.Now.TimeOfDay.TotalMilliseconds;
        public IList<IDocument> Documents { get; } = new List<IDocument>();
        public IList<ICheck> Checks { get; } = new List<ICheck>();
        public ISessionLog Log { get; set; }

        public ICheckResult[] PerformAll() =>
            Checks.Where(x=>x.IsAvailable(this)).Select(x => x.Perform(this)).ToArray();

        public override int GetHashCode() => ID;

        public override bool Equals(object obj) =>
            obj is Session session && session.GetHashCode() == this.GetHashCode();


        public void Dispose()
        {
            foreach (var document in Documents)
            {
                document.Dispose();
            }
        }
    }
}
