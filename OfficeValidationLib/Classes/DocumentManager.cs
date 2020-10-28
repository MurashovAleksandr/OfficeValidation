using System;
using System.Linq;
using System.Reflection;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class DocumentManager
    {
        public IDocumentFactory[] DocumentFactories => Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => !x.IsAbstract && x.GetInterfaces()
                        .Contains(typeof(IDocumentFactory)))
                    .Select(Activator.CreateInstance)
                    .Cast<IDocumentFactory>()
                    .ToArray();
    }
}
