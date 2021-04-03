using System.Collections.Generic;
using CommandLine;

namespace OfficeValidationCLI
{
    class Options
    {
        [Option('d',
            "documents",
            Required = true,
            HelpText = "Document files for check")]
        public IEnumerable<string> DocumentFiles { get; set; }

        [Option('p',
            "database",
            Required = false,
            HelpText = "SQLite database path",
            Default = "Checks.db")]
        public string ConnectionString { get; set; }

        [Option('s',
            "session_path",
            Required = false,
            HelpText = "Session directory path for save session log and checks result. Add '{0}' for set session id",
            Default = "sessions_{0}")]
        public string SessionDirectoryPath { get; set; }
    }
}
