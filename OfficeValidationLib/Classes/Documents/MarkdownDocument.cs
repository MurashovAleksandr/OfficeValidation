﻿using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Documents
{
    public class MarkdownDocumentFactory : DocumentFactoryBase
    {
        public override string Name { get; protected set; } = "Markdown";
        public override string[] SupportingExtension { get; protected set; } = new[]
        {
            ".md"
        };
        protected override IDocument CreateInternal(string path) =>
            new MarkdownDocument(path, this);
    }

    public class MarkdownDocument : DocumentBase
    {
        public string Document { get; private set; }
        public MarkdownDocument(string path, IDocumentFactory creator) : base(path, creator) { }
        public override void InitializeInternal()
        {
            Document = System.IO.File.ReadAllText(Path);
        }
        public override void DisposeInternal()
        {
            Document = null;
        }
    }
}
