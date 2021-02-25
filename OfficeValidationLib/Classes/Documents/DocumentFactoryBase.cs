using System;
using System.Linq;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public abstract class DocumentFactoryBase : IDocumentFactory
    {
        public abstract string Name { get; protected set; }
        public abstract string[] SupportingExtention { get; protected set; }
        public virtual bool CanCreate(string path) =>
            SupportingExtention.Select(x => x.ToLower()).Contains(System.IO.Path.GetExtension(path).ToLower());
        public IDocument Create(string path)
        {
            if (!CanCreate(path))
            {
                throw new ArgumentException($"Невозможно создать экземпляр {this}. Расширение документа не поддерживается. Перед созданием экземпляра вызовите {nameof(CanCreate)}");
            }
            return CreateInternal(path);
        }

        protected abstract IDocument CreateInternal(string path);

        public override string ToString() => Name;

        public override int GetHashCode() => $"{Name}".GetHashCode();

        public override bool Equals(object obj) => obj is IDocumentFactory docFactory && docFactory.GetHashCode() == this.GetHashCode();
    }
}
