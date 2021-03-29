using OfficeValidationLib.Classes;
using System;
using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface IDatabaseManager: IDisposable
    {
        IEnumerable<Instance> GetInstances();
        IEnumerable<ICheckResult> GetResults();
        IEnumerable<string> GetDocumentFactoryNames();
    }
}
