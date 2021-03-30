using System;
using System.IO;
using System.Security.Cryptography;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public abstract class DocumentBase : IDocument
    {
        public string Name => System.IO.Path.GetFileName(Path);
        public string Path { get; }
        public IDocumentFactory Creator { get; }
        public bool IsInitialized { get; protected set; }

        private string _hash;
        public string Hash
        {
            get
            {
                if (string.IsNullOrEmpty(_hash))
                {
                    using (var md5Document = MD5.Create())
                    {
                        using (var fs = File.OpenRead(Path))
                        {
                            _hash = BitConverter.ToString(md5Document.ComputeHash(fs))
                                .Replace("-", "")
                                .ToLowerInvariant();
                        }
                    }
                    
                }
                return _hash;
            }
        }

        protected DocumentBase(string path, IDocumentFactory creator)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Документ не найден", path);
            }
            Creator = creator ?? throw new ArgumentNullException(nameof(creator));
            this.Path = System.IO.Path.GetFullPath(path);
        }

        public void Initialize()
        {
            if (!IsInitialized)
            {
                InitializeInternal();
            }
            IsInitialized = true;
        }
        public abstract void InitializeInternal();

        public virtual void DisposeInternal() { }

        public void Dispose()
        {
            if (IsInitialized)
                DisposeInternal();

            IsInitialized = false;
        }

        public override string ToString() => Name;

        public override int GetHashCode() => $"{Creator.Name}_{Path}".GetHashCode();

        public override bool Equals(object obj) => 
            obj is IDocument doc && doc.GetHashCode() == this.GetHashCode();
    }
}
