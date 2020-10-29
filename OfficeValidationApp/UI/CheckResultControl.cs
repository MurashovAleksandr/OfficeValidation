using System.Linq;
using System.Windows.Forms;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class CheckResultControl : UserControl
    {
        private readonly ISessionResults _sessionResult;
        public CheckResultControl(ISessionResults sessionResult)
        {
            _sessionResult = sessionResult;
            InitializeComponent();

            treeListViewChecks.Objects = _sessionResult.Results;
            olvColumnName.AspectGetter = rowObject => (rowObject as ICheckResult).Check.DisplayName;
            treeListViewChecks.UpdateObjects(treeListViewChecks.Objects.Cast<ICheckResult>().ToArray());
        }
    }
}
