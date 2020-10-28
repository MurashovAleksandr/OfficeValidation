using System.Collections.Generic;

namespace OfficeValidationLib.Classes
{
    public class Instance
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Assembly { get; set; }
        public string ClassName { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
        public string[] Tags { get; set; }
    }
}
