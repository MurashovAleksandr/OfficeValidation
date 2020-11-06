using DocumentFormat.OpenXml.Packaging;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class WordOpenXMLDocumentFactory : DocumentFactoryBase
    {
        public override string Name { get; protected set; } = "Word_OpenXML";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".doc", ".docm", ".docx", ".dot",
            ".dotm", ".dotx",".odt", ".rtf",
            ".wps", ".xps"
        };
        protected override IDocument CreateInternal(string path) =>
            new WordOpenXMLDocument(path, this);
    }

    public class WordOpenXMLDocument : DocumentBase
    {
        public WordprocessingDocument Document { get; private set; }
        public WordOpenXMLDocument(string path, IDocumentFactory creator) : base(path, creator) { }
        public override void InitializeInternal()
        {
            Document = WordprocessingDocument.Open(Path, false);
        }
        public override void DisposeInternal()
        {
            Document.Clone();
        }
    }
}