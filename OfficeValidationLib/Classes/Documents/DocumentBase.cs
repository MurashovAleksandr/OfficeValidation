using System.IO;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public abstract class DocumentBase : IDocument
    {
        public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);
        public string Path { get; protected set; }

        public DocumentBase(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Документ не найден", path);
            }
            this.Path = path;
        }
        public abstract void Initialize();

        public abstract void Dispose();
    }
}
