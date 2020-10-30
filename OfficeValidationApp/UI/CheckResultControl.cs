using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OfficeValidationLib.Enums;
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
            olvColumnName.AspectGetter = rowObject =>
                rowObject is ICheckResult checkResult
                    ? checkResult.Check.DisplayName
                    : rowObject;
            treeListViewChecks.UpdateObjects(treeListViewChecks.Objects.Cast<ICheckResult>().ToArray());

            //load checked objects
            treeListViewChecks.CanExpandGetter =
                model => model is ICheckResult checkResult && checkResult.CheckedObjects.Any();
            treeListViewChecks.ChildrenGetter = model => (model as ICheckResult)?.CheckedObjects;
        }

        private void TreeListViewChecks_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            groupBoxViolations.Text = "Нарушения";
            objectListViewViolations.AllColumns.Clear();
            objectListViewViolations.Objects = null;
            if (sender is TreeListView treeListView && treeListView.SelectedObject is ICheckResult checkResult)
            {
                if (checkResult.Violations.Any())
                {
                    var allColumns = new Dictionary<string, OLVColumn>();
                    foreach (var violation in checkResult.Violations)
                    {
                        if (violation.Data == null) continue;
                        foreach (var item in violation.Data)
                        {
                            if (!allColumns.ContainsKey(item.Key))
                            {
                                allColumns.Add(item.Key, BuildViolationColumn(item.Key));
                            }
                        }
                    }
                    objectListViewViolations.AllColumns.AddRange(allColumns.Values);
                    objectListViewViolations.Objects = checkResult.Violations;
                    groupBoxViolations.Text = string.Format("Нарушения ({0} шт.)", checkResult.Violations.Count);
                }
                objectListViewViolations.RebuildColumns();
            }
        }

        OLVColumn BuildViolationColumn(string name) =>
            new OLVColumn
            {
                Text = name,
                Name = name,
                DataType = typeof(string),
                AspectGetter = x =>
                {
                    var data = ((IViolation) x).Data;
                    return data != null && data.ContainsKey(name) ? data[name] : null;
                },
                FillsFreeSpace = true
            };

        ViolationLevel? GetResultViolationLevel(IEnumerable<IViolation> violations)
        {
            foreach (var level in new[] {ViolationLevel.Error, ViolationLevel.Warning, ViolationLevel.Information})
            {
                if (violations.Any(y => y.Level == level))
                {
                    return level;
                }
            }
            return null;
        }

        private Dictionary<ViolationLevel, Color> violationColor = new Dictionary<ViolationLevel, Color>()
        {
            {ViolationLevel.Error, Color.Red},
            {ViolationLevel.Warning, Color.SandyBrown},
            {ViolationLevel.Information, Color.Black}
        };
        private void TreeListViewChecks_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Model is ICheckResult checkResult)
            {
                e.Item.ForeColor = violationColor[GetResultViolationLevel(checkResult.Violations) ?? ViolationLevel.Information];
            }

            if (e.Model is ICheckedObject checkedObject)
            {
                var violation = checkedObject.CheckResult.Violations
                    .FirstOrDefault(x => Object.Equals(x.Object, checkedObject.Object))?.Level;
                e.Item.ForeColor = violationColor[violation ?? ViolationLevel.Information];
            }
        }

        private void ObjectListViewViolations_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Model is IViolation violation)
            {
                e.Item.ForeColor = violationColor[violation.Level];
            }
        }

        private void toolStripButtonLog_Click(object sender, EventArgs e) =>
            new LogForm(_sessionResult.Session.Log.Messages).ShowDialog();
    }
}
