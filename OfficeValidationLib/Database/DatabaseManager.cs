using Newtonsoft.Json;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
            using var commandGetChecks = new SQLiteCommand("SELECT Id, Name, DisplayName, Description, Active, Assembly, ClassName FROM 'Check';", _connection);
            using var readerGetChecks = commandGetChecks.ExecuteReader();
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
                    Parameters = new Dictionary<string,object>()
                };
                //get tags
                using var commandGetTags = new SQLiteCommand($"SELECT t.Name FROM Tag t, CheckTag ct WHERE t.id = ct.IdTag AND ct.IdCheck = {instance.Id};", _connection);
                using var readerGetTags = commandGetTags.ExecuteReader();
                var tagList = new List<string>();
                while(readerGetTags.Read())
                    tagList.Add((string)readerGetTags["Name"]);
                instance.Tags = tagList.ToArray();
                //get parameters
                using var commandGetParameters = new SQLiteCommand($"SELECT cp.Name, cp.Value FROM CheckParameter cp WHERE cp.IdCheck = {instance.Id};", _connection);
                using var readerGetParameters = commandGetParameters.ExecuteReader();
                while (readerGetParameters.Read())
                    instance.Parameters.Add(
                        (string)readerGetParameters["Name"],
                        JsonConvert.DeserializeObject((string)readerGetParameters["Value"]));
                yield return instance;
            }
        }

        public IEnumerable<string> GetDocumentFactoryNames()
        {
            using var commandGetDocumentFactoryName = new SQLiteCommand("SELECT Name FROM DocumentFactoryName WHERE Active = true;", _connection);
            using var readerGetDocumentFactoryName = commandGetDocumentFactoryName.ExecuteReader();
            while (readerGetDocumentFactoryName.Read())
            {
                yield return (string)readerGetDocumentFactoryName["Name"];
            }
        }
        public IEnumerable<ICheckResult> GetResults()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
