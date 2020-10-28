using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ISession
    {
        long ID { get; }
        IList<IDocument> Documents { get; }
        IEnumerable<ICheck> Checks { get; }
        ISessionLog Log { get; set; }
        ICheckResult[] PerformAll();
    }
}
