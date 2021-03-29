using System.Collections.Generic;
using CommandLine;

namespace OfficeValidationCLI
{
    class Options
    {
        [Option('c',
            "connection",
            Required = false,
            HelpText = "SQLite connection string",
            Default = "Data Source=Checks.db;Version=3;")]
        public string ConnectionString { get; set; }

        [Option('s',
            "session_path",
            Required = false,
            HelpText = "Session directory path for save session log and checks result. Add '{0}' for set session id",
            Default = "sessions_{0}")]
        public string SessionDirectoryPath { get; set; }
    }
}
