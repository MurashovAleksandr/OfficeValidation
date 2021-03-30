using System;
using System.Linq;
using CommandLine;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Database;
using OfficeValidationLib.Enums;

namespace OfficeValidationCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions);
        }
        static void RunOptions(Options opts)
        {
            var databaseManager = new DatabaseManager(opts.ConnectionString);
            var sessionManager = new SessionManager(databaseManager);
            var documentManager = new DocumentManager(sessionManager.Config.DocumentFactoryNames);
            var documents = opts.DocumentFiles
                .SelectMany(file =>
                    documentManager.DocumentFactories
                        .Where(docFactory => docFactory.CanCreate(file))
                        .Select(docFactory => docFactory.Create(file)))
                .ToArray();
            using (var session = sessionManager.Create(sessionManager.Config.Instances, documents))
            {
                opts.SessionDirectoryPath = string.Format(opts.SessionDirectoryPath, session.ID);
                if (!System.IO.Directory.Exists(opts.SessionDirectoryPath))
                {
                    System.IO.Directory.CreateDirectory(opts.SessionDirectoryPath);
                }
                session.Log.Save(System.IO.Path.Combine(opts.SessionDirectoryPath, $"session.log"));
                var errors = session.Log.Messages
                    .Where(x => x.Severity > LogMessageSeverity.Information)
                    .ToArray();
                if (errors.Any())
                {
                    string errorMessage = "\nCreate session errors::\n";
                    errorMessage += string.Join("\n\n", errors.Select(x => $"Message: {x.Message}\nSender:{x.Sender}"));
                    errorMessage += $"More details in session log: {opts.SessionDirectoryPath}";
                    throw new Exception(errorMessage);
                }

                var checkResults = session.PerformAll();
                databaseManager.AddResults(checkResults);
                foreach (var checkResult in checkResults)
                {
                    checkResult.Save(System.IO.Path.Combine(opts.SessionDirectoryPath, $"{checkResult.Check.Name}.txt"));
                }
            }
        }
    }
}
