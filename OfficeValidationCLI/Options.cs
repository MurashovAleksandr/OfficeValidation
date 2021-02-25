using System.Collections.Generic;
using CommandLine;

namespace OfficeValidationCLI
{
    class Options
    {
        [Option('c',
            "config",
            Required = true,
            HelpText = "Path to config json file. Content example: \n{\n\t\"DocumentFactoryNames\": [\"Excel\",\"LaTeX\",\"Markdown\",\"PowerPoint\",\"Word\",\"Word_OpenXML\"],\n\t\"Instances\":\n\t[\n\t\t{\n\t\t\t\"Name\":\"ContainsBookmarks2\",\n\t\t\t\"DisplayName\":\"Более 2 закладок\",\n\t\t\t\"Description\":\"Проверяется наличие закладок в документе (должно быть 2 или более)\",\n\t\t\t\"Assembly\":\"CommonOfficeValidationChecks.dll\",\n\t\t\t\"ClassName\":\"CommonOfficeValidationChecks.Checks.Bookmarks\",\n\t\t\t\"Parameters\":\n\t\t\t{\n\t\t\t\t\"BookmarksMinCount\":2\n\t\t\t}\n\t\t}\n\t]\n}")]
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
}
