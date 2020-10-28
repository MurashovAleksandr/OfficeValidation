namespace OfficeValidationLib.Interfaces
{
    public interface IDocumentFactory
    {
        string ExtentionsName { get; }
        string[] SupportingExtention { get; }
        bool CanCreate(string path);
    }
}
