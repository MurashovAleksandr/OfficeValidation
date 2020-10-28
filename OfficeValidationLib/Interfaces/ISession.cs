using System;
using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ISession : IDisposable
    {
        long ID { get; }
        IList<IDocument> Documents { get; }
        IList<ICheck> Checks { get; }
        ISessionLog Log { get; set; }
        ICheckResult[] PerformAll();
    }
}
