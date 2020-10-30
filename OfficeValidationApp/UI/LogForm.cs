using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class LogForm : Form
    {
        public LogForm(IEnumerable<ILogMessage> logs)
        {
            InitializeComponent();

            objectListViewLogs.Objects = logs.ToArray();
            olvColumnSeverity.AspectGetter = rowObject => ((ILogMessage)rowObject).Severity;
            olvColumnMessage.AspectGetter = rowObject => ((ILogMessage)rowObject).Message;
            olvColumnSender.AspectGetter = rowObject => ((ILogMessage)rowObject).Sender;
            objectListViewLogs.UpdateObjects(objectListViewLogs.Objects.Cast<ILogMessage>().ToArray());
        }
    }
}
