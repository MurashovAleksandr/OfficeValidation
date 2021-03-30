using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class SupportingDocumentsForm : Form
    {
        public SupportingDocumentsForm(IEnumerable<IDocumentFactory> documentFactories)
        {
            InitializeComponent();

            objectListViewDocuments.Objects = documentFactories;
            olvColumnType.AspectGetter = rowObject => rowObject is IDocumentFactory documentFactory 
                ? documentFactory.Name 
                : null;
            olvColumnExtentions.AspectGetter = rowObject => rowObject is IDocumentFactory documentFactory 
                ? string.Join(";", documentFactory.SupportingExtension) 
                : null;
            objectListViewDocuments.UpdateObjects(documentFactories.ToArray());
        }
    }
}
