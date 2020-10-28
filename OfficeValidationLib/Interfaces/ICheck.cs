using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ICheck
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
        IDictionary<string, object> Parameters { get; }
        IList<string> Tags { get; }

        bool IsAvailable(ISession session);
        void InitializeParameters(IDictionary<string, object> parameters);
        ICheckResult Perform(ISession session);
    }
}
