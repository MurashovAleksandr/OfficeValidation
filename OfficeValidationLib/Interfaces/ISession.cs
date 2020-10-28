using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OfficeValidationLib.Interfaces
{
    public interface ISession
    {
        long ID { get; }
        IEnumerable<IOfficeDocument> Documents { get; }
        IEnumerable<ICheck> Checks { get; }
        ISessionLog Log { get; }
        ICheckResult[] PerformAll();
    }
}
