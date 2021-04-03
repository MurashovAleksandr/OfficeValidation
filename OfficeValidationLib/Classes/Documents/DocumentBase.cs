using System;
using System.IO;
using System.Security.Cryptography;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public abstract class DocumentBase : IDocument
    {
        private string _name;

        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name)) return _name;
                _name = System.IO.Path.GetFileName(Path);
                return _name;
            }
        }
        public string Path { get; }
        public IDocumentFactory Creator { get; }
        public bool IsInitialized { get; protected set; }

        private string _hash;
        public string Hash
        {
            get
            {
                if (!string.IsNullOrEmpty(_hash)) return _hash;
                using (var md5Document = MD5.Create())
                {
                    using (var fs = File.OpenRead(Path))
                    {
                        _hash = BitConverter.ToString(md5Document.ComputeHash(fs))
                            .Replace("-", "")
                            .ToLowerInvariant();
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

        private int? _hashCode = null;
        public override int GetHashCode()
        {
            if (_hashCode.HasValue) return _hashCode.Value;
            _hashCode = $"{Creator.Name}_{Path}".GetHashCode();
            return _hashCode.Value;
        }

        public override bool Equals(object obj) => 
            obj is IDocument doc && doc.GetHashCode() == this.GetHashCode();
    }
}
