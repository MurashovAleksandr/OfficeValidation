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

            //load checks
            treeListViewChecks.Objects = _sessionResult.Results;
            olvColumnName.AspectGetter = delegate(object rowObject)
            {
                if (rowObject is ICheckResult checkResult)
                {
                    return checkResult.Check.DisplayName;
                }
                return rowObject;
            };
            treeListViewChecks.UpdateObjects(treeListViewChecks.Objects.Cast<ICheckResult>().ToArray());

            //load checked objects
            treeListViewChecks.CanExpandGetter =
                model => model is ICheckResult checkResult && checkResult.CheckedObjects.Any();
            treeListViewChecks.ChildrenGetter = delegate(object model) { return (model as ICheckResult) ?.CheckedObjects; };
        }
    }
}
