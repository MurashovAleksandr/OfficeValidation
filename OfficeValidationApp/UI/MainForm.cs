using System;
using System.Linq;
using System.Windows.Forms;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Session;

namespace OfficeValidationApp.UI
{
    public partial class MainForm : Form
    {
        private readonly DocumentManager _documentManager = new DocumentManager();
        private readonly SessionManager _sessionManager = new SessionManager("config.json");
        public MainForm()
        {
            InitializeComponent();

            objectListViewDocumentTypes.Objects =
                _documentManager.DocumentFactories.SelectMany(x => x.SupportingExtention).Distinct();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var session in _sessionManager.Sessions)
            {
                session.Dispose();
            }
        }
    }
}
