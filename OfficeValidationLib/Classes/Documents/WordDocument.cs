using Microsoft.Office.Interop.Word;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class WordDocumentFactory : DocumentFactoryBase
    {
        public override string ExtentionsName { get; protected set; } = "Word";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".doc", ".docm", ".docx", ".dot",
            ".dotm", ".dotx",".odt", ".rtf", ".wps", ".xps"
        };
        public override IDocument CreateInternal(string path) =>
            new WordDocument(path);
    }

    public class WordDocument : DocumentBase
    {
        public Application Application { get; private set; }
        public Document Document { get; private set; }
        public WordDocument(string path) : base(path) { }
        public override void Initialize()
        {
            Application = new Application() { Visible = false };
            Document = Application.Documents.Open(Path);
        }
        public override void Dispose()
        {
            Document.Close(false);
            Application.Quit();
        }
    }
}
