﻿using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class LaTeXDocumentFactory : DocumentFactoryBase
    {
        public override string ExtentionsName { get; protected set; } = "LaTeX";
        public override string[] SupportingExtention { get; protected set; } = new[]
        {
            ".tex"
        };
        public override IDocument CreateInternal(string path) =>
            new LaTeXDocument(path);
    }

    public class LaTeXDocument : DocumentBase
    {
        public string Document { get; private set; }
        public LaTeXDocument(string path) : base(path) { }
        public override void Initialize()
        {
            Document = System.IO.File.ReadAllText(Path);
        }
        public override void Dispose()
        {
            Document = null;
        }
    }
}
