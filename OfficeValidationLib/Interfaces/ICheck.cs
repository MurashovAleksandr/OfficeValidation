using System.Collections.Generic;

namespace OfficeValidationLib.Interfaces
{
    public interface ICheck
    {
        string Name { get; set; }
        string DisplayName { get; }
        string Description { get; }
        IEnumerable<ICheckParameter> Parameters { get; }
        IList<string> Tags { get; }

        bool IsAvailable(ISession session);
        void InitializeParameters(IDictionary<string, object> parameters);
        ICheckResult Perform(ISession session);
    }
}
