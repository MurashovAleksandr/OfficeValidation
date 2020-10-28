using System;
using System.Windows.Forms;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class MainForm : Form
    {
        private readonly DocumentManager _documentManager = new DocumentManager();
        private readonly SessionManager _sessionManager = new SessionManager("config.json");
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*using (ISession session = _sessionManager.Create(new IDocument[]
            {
                new WordDocument(
                    @"C:\Projects\CSharp\OfficeValidation\OfficeValidationApp\bin\x64\Debug\Arduino Nano.docx")
            }))
            {
                var checkResult = session.PerformAll();
            }*/
        }
    }
}
