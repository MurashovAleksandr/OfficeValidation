using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class DocumentHistory : DocumentBase
    {
        public DocumentHistory(string path, IDocumentFactory creator) : base(path, creator) { }

        public override void InitializeInternal() { }
    }
}
