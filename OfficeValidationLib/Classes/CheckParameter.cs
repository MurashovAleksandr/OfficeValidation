using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class CheckParameter : ICheckParameter
    {
        public ICheck Check { get; }
        public string Name { get; }
        public object Value { get; set; }

        public CheckParameter(ICheck check, string name, object value)
        {
            this.Check = check;
            this.Name = name;
            this.Value = value;
        }
    }
}
