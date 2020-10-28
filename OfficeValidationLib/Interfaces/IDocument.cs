using System;

namespace OfficeValidationLib.Interfaces
{
    public interface IDocument : IDisposable
    {
        string Name { get; }
        string Path { get; }
        void Initialize();
    }
}
