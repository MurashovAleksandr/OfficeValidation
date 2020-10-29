using System.Collections.Generic;
using System.Windows.Forms;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class ResultForm : Form
    {
        private readonly IEnumerable<ISessionResults> _sessionResults;
        public ResultForm(IEnumerable<ISessionResults> sessionResults)
        {
            _sessionResults = sessionResults;
            InitializeComponent();

            foreach (var result in _sessionResults)
            {
                var tabPage = new TabPage(result.Session.CreationDateTime.ToShortTimeString());
                tabControlSessions.TabPages.Add(tabPage);
                tabControlSessions.SelectedTab = tabPage;
                var checksControl = new CheckResultControl(result) { Dock = DockStyle.Fill};
                tabPage.Controls.Add(checksControl);
            }
        }
    }
}
