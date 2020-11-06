using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Enums;

namespace OfficeValidationCLI
{
    class Options
    {
        [Option('c', 
            "config", 
            Required = true, 
            HelpText = "Path to config json file. Content example: {\n\t\"Instances\":\n\t[\n\t\t{\n\t\t\t\"Name\":\"ContainsBookmarks2\",\n\t\t\t\"DisplayName\":\"Более 2 закладок\",\n\t\t\t\"Description\":\"Проверяется наличие закладок в документе (должно быть 2 или более)\",\n\t\t\t\"Assembly\":\"CommonOfficeValidationChecks.dll\",\n\t\t\t\"ClassName\":\"CommonOfficeValidationChecks.Checks.Bookmarks\",\n\t\t\t\"Parameters\":\n\t\t\t{\n\t\t\t\t\"BookmarksMinCount\":2\n\t\t\t}\n\t\t}\n\t]\n}")]
        public string ConfigFile { get; set; }

        [Option('d',
            "documents", 
            Required = true, 
            HelpText = "Document files for check")]
        public IEnumerable<string> DocumentFiles { get; set; }

        [Option('s', 
            "session_path", 
            Required = false, 
            HelpText = "Session directory path for save session log and checks result. Add '{0}' for set session id", 
            Default = "sessions_{0}")]
        public string SessionDirectoryPath { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions);
        }
        static void RunOptions(Options opts)
        {
            var documentManager = new DocumentManager();
            var documents = opts.DocumentFiles
                .SelectMany(file =>
                    documentManager.DocumentFactories
                        .Where(docFactory => docFactory.CanCreate(file))
                        .Select(docFactory => docFactory.Create(file)))
                .ToArray();
            var sessionManager = new SessionManager(opts.ConfigFile);
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

                foreach (var checkResult in session.PerformAll())
                {
                    checkResult.Save(System.IO.Path.Combine(opts.SessionDirectoryPath, $"{checkResult.Check.Name}.txt"));
                }
            }
        }
    }
}
