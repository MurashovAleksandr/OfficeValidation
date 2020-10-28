namespace OfficeValidationLib.Interfaces
{
    public interface ICheckParameter
    {
        ICheck Check { get; }
        string Name { get; }
        object Value { get; set; }
    }
}
