using Newtonsoft.Json;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Interfaces;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OfficeValidationManager
{
    public partial class MainForm : Form
    {
        private const string CONFIG_PATH = "config.json";
        private readonly Config _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(CONFIG_PATH));
        public MainForm()
        {
            InitializeComponent();

            foreach (var docFactory in new DocumentManager().DocumentFactories)
            {
                checkedListBoxDocumentFactoryNames.Items.Add(docFactory, _config.DocumentFactoryNames.Contains(docFactory.Name));
            }
        }

        private void buttonCancel_Click(object sender, System.EventArgs e) => 
            Close();

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            _config.DocumentFactoryNames = checkedListBoxDocumentFactoryNames.CheckedItems.Cast<IDocumentFactory>().Select(x => x.Name).ToArray();

            var content = JsonConvert.SerializeObject(_config, Formatting.Indented);
            File.WriteAllText(CONFIG_PATH, content, System.Text.Encoding.Default);
        }
    }
}
