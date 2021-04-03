using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OfficeValidationLib.Classes.Documents;
using OfficeValidationLib.Database.Entities;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;
using SQLite.Net;

namespace OfficeValidationLib.Classes
{
    public class CheckResultHistory : ICheckResult
    {
        private readonly SQLiteConnection _db;

        public CheckResultHistory(SQLiteConnection db, CheckResultEntity checkResultEntity, DocumentManager documentManager)
        {
            _db = db;
            Violations = new List<IViolation>();
            CheckedObjects = new List<ICheckedObject>();

            var checkEntity = _db.Table<CheckEntity>().First(x => x.Id == checkResultEntity.IdCheck);
            Check = new CheckHistory()
            {
                Name = checkEntity.Name,
                Description = checkEntity.Description,
                DisplayName = checkEntity.DisplayName,
                Tags = checkEntity.GetTagEntities(db).Select(x => x.Name).ToArray(),
                Parameters = checkEntity.GetCheckParameterEntities(db)
                    .ToDictionary(x => x.Name, y => JsonConvert.DeserializeObject(y.Value))
            };
            var violationEntities = checkResultEntity.GetViolations(db).ToArray();
            foreach (var violationEntity in violationEntities.ToArray())
            {
                var documentEntity = violationEntity.GetDocumentEntity(db);
                var documentFactory = documentManager.DocumentFactories.First(x => x.Name == documentEntity.Type);
                var documentHistory = new DocumentHistory(documentEntity.Path, documentFactory);
                ViolationLevel level = (ViolationLevel)Enum.Parse(typeof(ViolationLevel), violationEntity.GetViolationLevelEntity(db).Name);
                var violation = new Violation(this, documentHistory, violationEntity.ObjectName, level);
                var violationDataEntities = violationEntity.GetViolationData(db);
                foreach (var violationDataEntity in violationDataEntities)
                {
                    if (!violation.Data.ContainsKey(violationDataEntity.Name))
                    {
                        violation.Data.Add(violationDataEntity.Name, violationDataEntity.Value);
                    }
                }
                Violations.Add(violation);
                CheckedObjects.Add(new CheckedObject(violationEntity.ObjectName, this));
            }
        }

        public ICheck Check { get; }
        public IList<ICheckedObject> CheckedObjects { get; }
        public IList<IViolation> Violations { get; }
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
