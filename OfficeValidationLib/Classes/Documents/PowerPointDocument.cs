using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class PowerPointDocumentFactory : DocumentFactoryBase
    {
        public override string Name { get; protected set; } = "PowerPoint";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".odp", ".pot", ".potm", ".potx",
            ".ppa", ".ppam", ".pps", ".ppsm",
            ".ppsx", ".ppt", ".pptm", ".pptx", ".thmx"
        };
        protected override IDocument CreateInternal(string path) =>
            new PowerPointDocument(path);
    }

    public class PowerPointDocument : DocumentBase
    {
        public Microsoft.Office.Interop.PowerPoint.Application Application { get; private set; }
        public Presentation Document { get; private set; }
        public PowerPointDocument(string path) : base(path) { }
        public override void Initialize()
        {
            Application = new Microsoft.Office.Interop.PowerPoint.Application() { Visible = MsoTriState.msoFalse };
            Document = Application.Presentations.Open(Path);
        }
        public override void Dispose()
        {
            Document.Close();
            Application.Quit();
        }
    }
}
