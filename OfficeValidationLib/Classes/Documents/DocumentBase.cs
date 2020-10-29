using System;
using System.IO;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public abstract class DocumentBase : IDocument
    {
        public string Name => System.IO.Path.GetFileName(Path);
        public string Path { get; }
        public IDocumentFactory Creator { get; }

        protected DocumentBase(string path, IDocumentFactory creator)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Документ не найден", path);
            }
            Creator = creator ?? throw new ArgumentNullException(nameof(creator));
            this.Path = path;
        }
        public abstract void Initialize();

        public abstract void Dispose();

        public override string ToString() => Name;

        public override int GetHashCode() => Path.GetHashCode();

        public override bool Equals(object obj) => 
            obj is IDocument doc && doc.GetHashCode() == this.GetHashCode();
    }
}
