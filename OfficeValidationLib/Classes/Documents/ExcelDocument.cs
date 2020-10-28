using Microsoft.Office.Interop.Excel;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class ExcelDocumentFactory : DocumentFactoryBase
    {
        public override string ExtentionsName { get; protected set; } = "Excel";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".csv", ".ods", ".prn",
            ".slk", ".xla", ".xlam",
            ".xls", ".xlsb", ".xlsm",
            ".xlsx", ".xlt", ".xltm",
            ".xltx", ".xlw", ".xps"
        };
        public override IDocument CreateInternal(string path) => 
            new ExcelDocument(path);
    }

    public class ExcelDocument : DocumentBase
    {
        public Application Application { get; private set; }
        public Workbook Document { get; private set; }
        public ExcelDocument(string path) : base(path) { }
        public override void Initialize()
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
