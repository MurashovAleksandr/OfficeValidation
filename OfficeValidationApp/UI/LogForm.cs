using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class LogForm : Form
    {
        private readonly IEnumerable<ILogMessage> _logs;
        public LogForm(IEnumerable<ILogMessage> logs)
        {
            InitializeComponent();
            _logs = logs;
            objectListViewLogs.Objects = logs.ToArray();
            olvColumnSeverity.AspectGetter = rowObject => ((ILogMessage)rowObject).Severity;
            olvColumnMessage.AspectGetter = rowObject => ((ILogMessage)rowObject).Message;
            olvColumnSender.AspectGetter = rowObject => ((ILogMessage)rowObject).Sender;
            objectListViewLogs.UpdateObjects(objectListViewLogs.Objects.Cast<ILogMessage>().ToArray());
        }

        private void ToolStripButtonSave_Click(object sender, System.EventArgs e)
        {
            if(saveFileDialogLog.ShowDialog() == DialogResult.OK)
                File.WriteAllLines(saveFileDialogLog.FileName, _logs.Select(x => $"{x.Severity}\t{x.Message}\t{x.Sender}"));
        }
    }
}
