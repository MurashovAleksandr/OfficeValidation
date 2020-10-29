using Microsoft.Office.Interop.Excel;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class ExcelDocumentFactory : DocumentFactoryBase
    {
        public override string Name { get; protected set; } = "Excel";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".csv", ".ods", ".prn",
            ".slk", ".xla", ".xlam",
            ".xls", ".xlsb", ".xlsm",
            ".xlsx", ".xlt", ".xltm",
            ".xltx", ".xlw", ".xps"
        };
        protected override IDocument CreateInternal(string path) => 
            new ExcelDocument(path, this);
    }

    public class ExcelDocument : DocumentBase
    {
        public Application Application { get; private set; }
        public Workbook Document { get; private set; }
        public ExcelDocument(string path, IDocumentFactory creator) : base(path, creator) { }
        public override void InitializeInternal()
        {
            Application = new Application() { Visible = false };
            Document = Application.Workbooks.Open(Path);
        }
        public override void Dispose()
        {
            Document.Close(false);
            Application.Quit();
        }
    }
}
