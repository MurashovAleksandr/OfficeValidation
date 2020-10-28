namespace OfficeValidationLib.Interfaces
{
    public interface IDocumentFactory
    {
        string Name { get; }
        string[] SupportingExtention { get; }
        bool CanCreate(string path);
        IDocument Create(string path);
    }
}
