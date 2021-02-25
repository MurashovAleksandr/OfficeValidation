using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class DocumentManager
    {
        public IDocumentFactory[] DocumentFactories { get; }

        /// <summary>
        /// Load all factories
        /// </summary>
        public DocumentManager()
        {
            DocumentFactories = GetDocumentFactories();
        }

        /// <summary>
        /// Create document factories by names
        /// </summary>
        /// <param name=""></param>
        public DocumentManager(string[] documentFactoryNames)
        {
            DocumentFactories = GetDocumentFactories(documentFactoryNames);
        }

        private IDocumentFactory[] GetDocumentFactories(IEnumerable<string> documentFactoryNames = null)
         => Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => !x.IsAbstract && x.GetInterfaces()
                    .Contains(typeof(IDocumentFactory)))
                .Select(Activator.CreateInstance)
                .Cast<IDocumentFactory>()
                .Where(x =>
                    documentFactoryNames == null ||
                    documentFactoryNames.Contains(x.Name))
                .OrderBy(x => x.Name)
                .ToArray();
    }
}
