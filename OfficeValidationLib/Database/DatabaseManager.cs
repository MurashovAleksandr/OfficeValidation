using Newtonsoft.Json;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OfficeValidationLib.Enums;

namespace OfficeValidationLib.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly SQLiteConnection _connection;
        public DatabaseManager(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        public IEnumerable<Instance> GetInstances()
        {
            using (var commandGetChecks =
                new SQLiteCommand(
                    "SELECT Id, Name, DisplayName, Description, Active, Assembly, ClassName FROM 'Check';",
                    _connection))
            {
                using (var readerGetChecks = commandGetChecks.ExecuteReader())
                {
                    while (readerGetChecks.Read())
                    {
                        var instance = new Instance()
                        {
                            Id = (long)readerGetChecks["Id"],
                            Name = (string)readerGetChecks["Name"],
                            DisplayName = (string)readerGetChecks["DisplayName"],
                            Description = (string)readerGetChecks["Description"],
                            Active = (bool)readerGetChecks["Active"],
                            Assembly = (string)readerGetChecks["Assembly"],
                            ClassName = (string)readerGetChecks["ClassName"],
                            Parameters = new Dictionary<string, object>()
                        };
                        //get tags
                        using (var commandGetTags =
                            new SQLiteCommand(
                                $"SELECT t.Name FROM Tag t, CheckTag ct WHERE t.id = ct.IdTag AND ct.IdCheck = {instance.Id};",
                                _connection))
                        {
                            using (var readerGetTags = commandGetTags.ExecuteReader())
                            {
                                var tagList = new List<string>();
                                while (readerGetTags.Read())
                                    tagList.Add((string)readerGetTags["Name"]);
                                instance.Tags = tagList.ToArray();
                                //get parameters
                                using (var commandGetParameters =
                                    new SQLiteCommand(
                                        $"SELECT cp.Name, cp.Value FROM CheckParameter cp WHERE cp.IdCheck = {instance.Id};",
                                        _connection))
                                {
                                    using (var readerGetParameters = commandGetParameters.ExecuteReader())
                                    {
                                        while (readerGetParameters.Read())
                                            instance.Parameters.Add(
                                                (string)readerGetParameters["Name"],
                                                JsonConvert.DeserializeObject((string)readerGetParameters["Value"]));
                                        yield return instance;
                                    } 
                                }
                            }
                        }
                        
                    }
                }
            }
        }

        public IEnumerable<string> GetDocumentFactoryNames()
        {
            using (var commandGetDocumentFactoryName =
                new SQLiteCommand("SELECT Name FROM DocumentFactoryName WHERE Active = true;", _connection))
            {
                using (var readerGetDocumentFactoryName = commandGetDocumentFactoryName.ExecuteReader())
                {
                    while (readerGetDocumentFactoryName.Read())
                    {
                        yield return (string)readerGetDocumentFactoryName["Name"];
                    }
                }
            }
            
        }

        [Obsolete("Не реализовано", true)]
        public IEnumerable<ICheckResult> GetResults()
        {
            throw new System.NotImplementedException();
        }

        public void AddResults(IEnumerable<ICheckResult> results)
        {
            foreach (var checkResult in results)
            {
                AddResult(checkResult);
            }
        }
        private void AddResult(ICheckResult result)
        {
            //find id result.Check
            var checkId = (long)new SQLiteCommand($"SELECT Id FROM 'Check' c WHERE c.Name = '{result.Check.Name}';", _connection)
                .ExecuteScalar();
            var checkResultId = AddCheckResult(checkId);
            foreach (var violation in result.Violations)
            {
                //add violation
                var violationId = AddViolation(checkResultId, violation);
                foreach (var data in violation.Data)
                {
                    //add result.Violations...Data
                    AddViolationData(violationId, data.Key, data.Value);
                }
            }
        }

        private long AddCheckResult(long checkId)
        {
            var checkResultId = NewSequence("CheckResult");
            //add result
            new SQLiteCommand("INSERT INTO CheckResult (Id, IdCheck, Date) VALUES (@Id, @IdCheck, @Date)", _connection)
            {
                Parameters =
                {
                    new SQLiteParameter("@Id", checkResultId),
                    new SQLiteParameter("@IdCheck", checkId),
                    new SQLiteParameter("@Date", DateTime.Now)
                }
            }.ExecuteNonQuery();
            return checkResultId;
        }
        private long AddViolationData(long violationId, string name, object value)
        {
            var seqId = NewSequence("ViolationData");
            new SQLiteCommand("INSERT INTO ViolationData (Id, Name, Value, IdViolation) VALUES (@Id, @Name, @Value, @IdViolation)", _connection)
            {
                Parameters =
                {
                    new SQLiteParameter("@Id", seqId),
                    new SQLiteParameter("@Name", name),
                    new SQLiteParameter("@Value", $"{value}"),
                    new SQLiteParameter("@IdViolation", violationId)
                }
            }.ExecuteNonQuery();
            return seqId;
        }

        private long AddViolation(long checkResultId, IViolation violation)
        {
            var violationLevelId = GetViolationLevelId(violation.Level) ?? AddViolationLevel(violation.Level);
            var documentId = GetDocumentId(violation.Document) ?? AddDocument(violation.Document);
            var seqId = NewSequence("Violation");
            new SQLiteCommand("INSERT INTO Violation (Id, IdCheckResult, IdViolationLevel, IdDocument, ObjectName) VALUES (@Id, @IdCheckResult, @IdViolationLevel, @IdDocument, @ObjectName)", _connection)
            {
                Parameters =
                {
                    new SQLiteParameter("@Id", seqId),
                    new SQLiteParameter("@IdCheckResult", checkResultId),
                    new SQLiteParameter("@IdViolationLevel", violationLevelId),
                    new SQLiteParameter("@IdDocument", documentId),
                    new SQLiteParameter("@ObjectName", $"{violation.Object}")

                }
            }.ExecuteNonQuery();
            return seqId;
        }

        private long AddDocument(IDocument document)
        {
            var seqId = NewSequence("Document");
            new SQLiteCommand("INSERT INTO Document (Id, Path, Type, Hash) VALUES (@Id, @Path, @Type, @Hash)", _connection)
            {
                Parameters =
                {
                    new SQLiteParameter("@Id", seqId),
                    new SQLiteParameter("@Path", $"{document.Path}"),
                    new SQLiteParameter("@Type", $"{document.Creator.Name}"),
                    new SQLiteParameter("@Hash", $"{document.Hash}")
                }
            }.ExecuteNonQuery();
            return seqId;
        }

        private long? GetDocumentId(IDocument document) =>
            (long?)new SQLiteCommand($"SELECT Id FROM Document WHERE Path = '{document.Path}' AND Type = '{document.Creator.Name}' AND Hash = '{document.Hash}';", _connection).ExecuteScalar();

        private long AddViolationLevel(ViolationLevel level)
        {
            var seqId = NewSequence("ViolationLevel");
            new SQLiteCommand("INSERT INTO ViolationLevel (Id, Name) VALUES (@Id, @Name)", _connection)
            {
                Parameters =
                {
                    new SQLiteParameter("@Id", seqId),
                    new SQLiteParameter("@Name", $"{level}")
                }
            }.ExecuteNonQuery();
            return seqId;
        }

        private long? GetViolationLevelId(ViolationLevel level) =>
            (long?)new SQLiteCommand($"SELECT Id FROM ViolationLevel WHERE Name = '{level}'", _connection).ExecuteScalar();


        private long NewSequence(string tableName) =>
            (long)new SQLiteCommand($"SELECT seq FROM sqlite_sequence WHERE name = '{tableName}';", _connection).ExecuteScalar() + 1;
        
        /// <summary>
        /// Закрывает соединение с БД
        /// </summary>
        public void Dispose()
        {
            _connection.Close();
        }
    }
}
