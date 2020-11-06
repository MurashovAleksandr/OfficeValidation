using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class CheckResult : ICheckResult
    {
        public CheckResult(ICheck check)
        {
            Check = check;
        }
        public ICheck Check { get; }
        public IList<ICheckedObject> CheckedObjects { get; } = new List<ICheckedObject>();
        public IList<IViolation> Violations { get; } = new List<IViolation>();
        public void Save(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (!Violations.Any())
            {
                return;
            }

            var table = new DataTable();

            //prepare columns
            foreach (var violation in Violations)
            {
                foreach (var item in violation.Data)
                {
                    if (!table.Columns.Contains(item.Key))
                    {
                        if (item.Value != null)
                        {
                            table.Columns.Add(item.Key, item.Value.GetType());
                        }
                    }
                }
            }
            //fill data
            foreach (var violation in Violations)
            {
                var row = table.NewRow();
                if (violation.Data != null)
                {
                    foreach (var column in table.Columns.Cast<DataColumn>())
                    {
                        if (violation.Data.ContainsKey(column.ColumnName))
                        {
                            row[column] = violation.Data[column.ColumnName];
                        }
                    }
                }
                table.Rows.Add(row);
            }

            //save
            var fileContent = new List<string>();
            fileContent.Add(string.Join("\t", from DataColumn c in table.Columns select c.Caption));
            foreach (DataRow row in table.Rows)
            {
                fileContent.Add(string.Join("\t", row.ItemArray));
            }
            File.WriteAllLines(filePath, fileContent);
        }
    }
}
