using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OfficeValidationLib.Classes;
using OfficeValidationLib.Classes.Session;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationApp.UI
{
    public partial class MainForm : Form
    {
        private readonly DocumentManager _documentManager = new DocumentManager();
        private readonly SessionManager _sessionManager = new SessionManager("config.json");
        private readonly List<ISessionResults>  _sessionResults = new List<ISessionResults>();
        public MainForm()
        {
            InitializeComponent();
            SetupAspects();
        }

        void SetupAspects()
        {
            //set document types
            objectListViewDocumentTypes.Objects = _documentManager.DocumentFactories;
            olvColumnDocumentTypes.AspectGetter = rowObject => rowObject is IDocumentFactory document ? document.Name : null;
            objectListViewDocumentTypes.RefreshObjects(objectListViewDocumentTypes.Objects.Cast<Object>().ToList());

            //document types selection ('OR' behavior)
            objectListViewDocuments.ModelFilter = new ModelFilter(objDocument =>
                objectListViewDocumentTypes.CheckedObjects.Count == 0 ||
                objDocument is IDocument document &&
                objectListViewDocumentTypes.CheckedObjects.Cast<IDocumentFactory>()
                    .Any(x=>string.Equals(x.Name, document.Creator.Name)));

            //prepare documents
            objectListViewDocuments.Objects = new List<IDocument>();
            olvColumnDocument.AspectGetter = rowObject => rowObject is IDocument document ? document.Name : null;
            olvColumnType.AspectGetter = rowObject => rowObject is IDocument document ? document.Creator.Name : null;
            objectListViewDocuments.RefreshObjects(objectListViewDocuments.Objects.Cast<IDocument>().ToList());

            //checks
            objectListViewChecks.Objects = _sessionManager.Config.Instances.ToList();
            olvColumnCheck.AspectGetter = rowObject => rowObject is Instance instance ? instance.DisplayName : null;
            objectListViewChecks.RefreshObjects(objectListViewChecks.Objects.Cast<Instance>().ToList());

            //tags
            objectListViewTags.Objects = _sessionManager.Config.Instances.SelectMany(x => x.Tags).Distinct().ToArray();
            olvColumnTag.AspectGetter = rowObject => rowObject;
            objectListViewTags.RefreshObjects(objectListViewTags.Objects.Cast<string>().ToList());

            //tags selection ('AND' behavior)
            objectListViewChecks.ModelFilter = new ModelFilter(objInstance => 
                objectListViewTags.CheckedObjects.Count == 0 ||
                objInstance is Instance instance && objectListViewTags.CheckedObjects.Count ==
                objectListViewTags.CheckedObjects.Cast<string>()
                .Intersect(instance.Tags).Count());
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => _sessionManager.Dispose();

        private void OpenDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogDocuments.Filter = $@"Все документы|{string.Join(";", _documentManager.DocumentFactories.SelectMany(x=>x.SupportingExtention.Select(y=>$"*{y}")).Distinct())}|" + 
                string.Join("|",
                    _documentManager.DocumentFactories
                .Select(x => $"{x.Name}|{string.Join(";", x.SupportingExtention.Select(y => $"*{y}"))}"));
            if (openFileDialogDocuments.ShowDialog() == DialogResult.OK)
            {
                var documents = openFileDialogDocuments.FileNames.SelectMany(file =>
                    _documentManager.DocumentFactories
                        .Where(docFactory => docFactory.CanCreate(file))
                        .Select(docFactory => docFactory.Create(file)))
                    .ToArray();
                foreach (var document in documents)
                {
                    if (!objectListViewDocuments.Objects.Cast<IDocument>().Contains(document))
                    {
                        objectListViewDocuments.Objects = objectListViewDocuments.Objects
                            .Cast<IDocument>().Concat(new []{ document });

                    }
                }
                objectListViewDocuments.RefreshObjects(objectListViewDocuments.Objects.Cast<IDocument>().ToList());
            }
        }

        private void ObjectListViewChecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListViewChecks.SelectedObject is Instance selectedInstance)
            {
                textBoxDescription.Text = selectedInstance.Description;
            }
        }

        private void ObjectListViewTags_ItemChecked(object sender, ItemCheckedEventArgs e) =>
            objectListViewChecks.UpdateObjects(objectListViewChecks.Objects.Cast<object>().ToArray());

        private void ObjectListViewDocumentTypes_ItemChecked(object sender, ItemCheckedEventArgs e) => 
            objectListViewDocuments.UpdateObjects(objectListViewDocuments.Objects.Cast<object>().ToArray());

        void UpdatePerformState()
        {
            buttonPerform.Enabled = objectListViewDocuments.CheckedObjects.Count > 0 && 
                                    objectListViewChecks.CheckedObjects.Count > 0;
        }


        private void ButtonPerform_Click(object sender, EventArgs e)
        {
            var splashForm = new SplashForm()
            {
                Message = "Пожалуйста, подождите"
            };
            var splashThread = new Thread(() => splashForm.ShowDialog());
            splashThread.Start();
            this.Hide();
            var session = _sessionManager.Create(
                objectListViewChecks.CheckedObjects.Cast<Instance>(),
                objectListViewDocuments.CheckedObjects.Cast<IDocument>());

            _sessionResults.Add(new SessionResults(session.PerformAll(), session));
            var resultForm = new ResultForm(_sessionResults);
            resultForm.ShowDialog();

            if (splashThread.ThreadState == ThreadState.Running)
            {
                splashForm.Invoke(new Action(() => splashForm.Close()));
            }
            this.Show();
        }

        private void ObjectListViewDocuments_ItemChecked(object sender, ItemCheckedEventArgs e) =>
            UpdatePerformState();

        private void ObjectListViewChecks_ItemChecked(object sender, ItemCheckedEventArgs e) =>
            UpdatePerformState();
    }
}
