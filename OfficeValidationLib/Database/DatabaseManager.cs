using Newtonsoft.Json;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using OfficeValidationLib.Database.Entities;
using SQLite.Net;
using SQLite.Net.Platform.Generic;

namespace OfficeValidationLib.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        public SQLiteConnection Db { get; }

        public DatabaseManager(string databasePath)
        {
            Db = new SQLiteConnection(
                sqlitePlatform: new SQLitePlatformGeneric(),
                databasePath: databasePath,
                storeDateTimeAsTicks:false);
        }

        public IEnumerable<Instance> GetInstances()
        {
            foreach (var checkEntity in Db.Table<CheckEntity>().ToArray())
            {
                //get check
                var instance = new Instance()
                {
                    Active = checkEntity.Active,
                    Assembly = checkEntity.Assembly,
                    ClassName = checkEntity.ClassName,
                    Description = checkEntity.Description,
                    DisplayName = checkEntity.DisplayName,
                    Name = checkEntity.Name
                };
                //get tags
                var checkTagEntities = Db.Table<CheckTagEntity>()
                    .Where(x => x.IdCheck == checkEntity.Id)
                    .ToArray();
                instance.Tags = Db.Table<TagEntity>()
                    .ToArray()
                    .Where(x => checkTagEntities.Any(y => y.IdTag == x.Id))
                    .Select(x => x.Name)
                    .ToArray();

                //get parameters
                instance.Parameters = new Dictionary<string, object>();
                foreach (var parameter in Db.Table<CheckParameterEntity>()
                    .Where(x=>x.IdCheck == checkEntity.Id)
                    .ToArray())
                {
                    instance.Parameters.Add(parameter.Name, JsonConvert.DeserializeObject(parameter.Value));
                }

                yield return instance;
            }
        }

        public IEnumerable<string> GetDocumentFactoryNames() =>
            Db.Table<DocumentFactoryNameEntity>()
                .Where(x => x.Active)
                .Select(x => x.Name);

        public IEnumerable<CheckResultEntity> GetResults() =>
            Db.Table<CheckResultEntity>();

        public void AddResults(IEnumerable<ICheckResult> results)
        {
            foreach (var checkResult in results)
            {
                AddResult(checkResult);
            }
        }

        private void AddResult(ICheckResult result)
        {
            //add result
            var checkResultEntity = new CheckResultEntity()
            {
                Date = DateTime.Now,
                IdCheck = (int)Db.Table<CheckEntity>()
                    .Where(x=>x.Name == result.Check.Name)
                    .First().Id //its faster. Do not touch
            };
            Db.Insert(checkResultEntity);

            foreach (var violation in result.Violations)
            {
                //get or add document
                var documentEntity = Db.Table<DocumentEntity>().Where(x =>
                        x.Hash == violation.Document.Hash && 
                        x.Path == violation.Document.Path && 
                        x.Type == violation.Document.Creator.Name)
                    .FirstOrDefault(); //its faster. Do not touch
                if (documentEntity == null)
                {
                    documentEntity = new DocumentEntity()
                    {
                        Hash = violation.Document.Hash,
                        Path = violation.Document.Path,
                        Type = violation.Document.Creator.Name
                    };
                    Db.Insert(documentEntity);
                }
                //get or add violationLevel
                var violationLevelEntity = Db.Table<ViolationLevelEntity>()
                    .FirstOrDefault(x => string.Equals($"{violation.Level}", x.Name));
                if (violationLevelEntity == null)
                {
                    violationLevelEntity = new ViolationLevelEntity()
                    {
                        Name = $"{violation.Level}"
                    };
                    Db.Insert(violationLevelEntity);
                }
                //add violation
                var violationEntity = new ViolationEntity()
                {
                    IdCheckResult = checkResultEntity.Id,
                    IdDocument = documentEntity.Id,
                    ObjectName = $"{violation.Object}",
                    IdViolationLevel = violationLevelEntity.Id
                };
                Db.Insert(violationEntity);
                foreach (var violationData in violation.Data)
                {
                    //add violation data
                    Db.Insert(new ViolationDataEntity()
                    {
                        IdViolation = violationEntity.Id,
                        Name = violationData.Key,
                        Value = $"{violationData.Value}"
                    });
                }
            }
            Db.Commit();
        }

        /// <summary>
        /// Закрывает соединение с БД
        /// </summary>
        public void Dispose()
        {
            Db.Close();
        }
    }
}
