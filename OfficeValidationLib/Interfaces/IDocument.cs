using System;

namespace OfficeValidationLib.Interfaces
{
    public interface IDocument : IDisposable
    {
        string Name { get; }
        string Path { get; }
        IDocumentFactory Creator { get; }
        void Initialize();
    }
}
