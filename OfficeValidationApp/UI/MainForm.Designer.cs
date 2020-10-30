namespace OfficeValidationApp.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportingDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelDocumentsChecks = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPerform = new System.Windows.Forms.Button();
            this.tableLayoutPanelTagsChecksDescriptions = new System.Windows.Forms.TableLayoutPanel();
            this.objectListViewChecks = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnCheck = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objectListViewTags = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnTag = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panelDocuments = new System.Windows.Forms.Panel();
            this.objectListViewDocuments = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDocument = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogDocuments = new System.Windows.Forms.OpenFileDialog();
            this.olvColumnIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelDocumentsChecks.SuspendLayout();
            this.tableLayoutPanelTagsChecksDescriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTags)).BeginInit();
            this.groupBoxDescription.SuspendLayout();
            this.panelDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).BeginInit();
            this.contextMenuStripDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1045, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentsToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openDocumentsToolStripMenuItem
            // 
            this.openDocumentsToolStripMenuItem.Image = global::OfficeValidationApp.Properties.Resources.open;
            this.openDocumentsToolStripMenuItem.Name = "openDocumentsToolStripMenuItem";
            this.openDocumentsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openDocumentsToolStripMenuItem.Text = "Открыть документы";
            this.openDocumentsToolStripMenuItem.Click += new System.EventHandler(this.OpenDocumentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::OfficeValidationApp.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportingDocumentsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // supportingDocumentsToolStripMenuItem
            // 
            this.supportingDocumentsToolStripMenuItem.Name = "supportingDocumentsToolStripMenuItem";
            this.supportingDocumentsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.supportingDocumentsToolStripMenuItem.Text = "Поддерживаемые документы";
            this.supportingDocumentsToolStripMenuItem.Click += new System.EventHandler(this.SupportingDocumentsToolStripMenuItem_Click);
            // 
            // tableLayoutPanelDocumentsChecks
            // 
            this.tableLayoutPanelDocumentsChecks.ColumnCount = 1;
            this.tableLayoutPanelDocumentsChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.buttonPerform, 0, 2);
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.tableLayoutPanelTagsChecksDescriptions, 0, 1);
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.panelDocuments, 0, 0);
            this.tableLayoutPanelDocumentsChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDocumentsChecks.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelDocumentsChecks.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelDocumentsChecks.Name = "tableLayoutPanelDocumentsChecks";
            this.tableLayoutPanelDocumentsChecks.RowCount = 3;
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.2F));
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.8F));
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelDocumentsChecks.Size = new System.Drawing.Size(1045, 666);
            this.tableLayoutPanelDocumentsChecks.TabIndex = 1;
            // 
            // buttonPerform
            // 
            this.buttonPerform.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPerform.Enabled = false;
            this.buttonPerform.Location = new System.Drawing.Point(908, 625);
            this.buttonPerform.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPerform.Name = "buttonPerform";
            this.buttonPerform.Size = new System.Drawing.Size(133, 37);
            this.buttonPerform.TabIndex = 0;
            this.buttonPerform.Text = "Запустить";
            this.buttonPerform.UseVisualStyleBackColor = true;
            this.buttonPerform.Click += new System.EventHandler(this.ButtonPerform_Click);
            // 
            // tableLayoutPanelTagsChecksDescriptions
            // 
            this.tableLayoutPanelTagsChecksDescriptions.ColumnCount = 3;
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.06961F));
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.93039F));
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.objectListViewChecks, 0, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.objectListViewTags, 0, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.groupBoxDescription, 2, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTagsChecksDescriptions.Location = new System.Drawing.Point(4, 210);
            this.tableLayoutPanelTagsChecksDescriptions.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelTagsChecksDescriptions.Name = "tableLayoutPanelTagsChecksDescriptions";
            this.tableLayoutPanelTagsChecksDescriptions.RowCount = 1;
            this.tableLayoutPanelTagsChecksDescriptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTagsChecksDescriptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 407F));
            this.tableLayoutPanelTagsChecksDescriptions.Size = new System.Drawing.Size(1037, 407);
            this.tableLayoutPanelTagsChecksDescriptions.TabIndex = 1;
            // 
            // objectListViewChecks
            // 
            this.objectListViewChecks.AllColumns.Add(this.olvColumnCheck);
            this.objectListViewChecks.CellEditUseWholeCell = false;
            this.objectListViewChecks.CheckBoxes = true;
            this.objectListViewChecks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnCheck});
            this.objectListViewChecks.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewChecks.FullRowSelect = true;
            this.objectListViewChecks.GridLines = true;
            this.objectListViewChecks.HideSelection = false;
            this.objectListViewChecks.Location = new System.Drawing.Point(239, 4);
            this.objectListViewChecks.Margin = new System.Windows.Forms.Padding(4);
            this.objectListViewChecks.Name = "objectListViewChecks";
            this.objectListViewChecks.ShowGroups = false;
            this.objectListViewChecks.Size = new System.Drawing.Size(514, 399);
            this.objectListViewChecks.TabIndex = 3;
            this.objectListViewChecks.UseCompatibleStateImageBehavior = false;
            this.objectListViewChecks.UseFiltering = true;
            this.objectListViewChecks.View = System.Windows.Forms.View.Details;
            this.objectListViewChecks.SelectedIndexChanged += new System.EventHandler(this.ObjectListViewChecks_SelectedIndexChanged);
            // 
            // olvColumnCheck
            // 
            this.olvColumnCheck.FillsFreeSpace = true;
            this.olvColumnCheck.Text = "Проверка";
            this.olvColumnCheck.Width = 300;
            // 
            // objectListViewTags
            // 
            this.objectListViewTags.AllColumns.Add(this.olvColumnTag);
            this.objectListViewTags.CellEditUseWholeCell = false;
            this.objectListViewTags.CheckBoxes = true;
            this.objectListViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTag});
            this.objectListViewTags.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewTags.FullRowSelect = true;
            this.objectListViewTags.GridLines = true;
            this.objectListViewTags.HideSelection = false;
            this.objectListViewTags.Location = new System.Drawing.Point(4, 4);
            this.objectListViewTags.Margin = new System.Windows.Forms.Padding(4);
            this.objectListViewTags.Name = "objectListViewTags";
            this.objectListViewTags.ShowGroups = false;
            this.objectListViewTags.Size = new System.Drawing.Size(227, 399);
            this.objectListViewTags.TabIndex = 0;
            this.objectListViewTags.UseCompatibleStateImageBehavior = false;
            this.objectListViewTags.View = System.Windows.Forms.View.Details;
            this.objectListViewTags.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ObjectListViewTags_ItemChecked);
            // 
            // olvColumnTag
            // 
            this.olvColumnTag.FillsFreeSpace = true;
            this.olvColumnTag.Text = "Метка";
            this.olvColumnTag.Width = 159;
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDescription.Location = new System.Drawing.Point(761, 4);
            this.groupBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDescription.Size = new System.Drawing.Size(272, 399);
            this.groupBoxDescription.TabIndex = 2;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Описание";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(4, 20);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(264, 375);
            this.textBoxDescription.TabIndex = 0;
            // 
            // panelDocuments
            // 
            this.panelDocuments.Controls.Add(this.objectListViewDocuments);
            this.panelDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDocuments.Location = new System.Drawing.Point(3, 3);
            this.panelDocuments.Name = "panelDocuments";
            this.panelDocuments.Size = new System.Drawing.Size(1039, 200);
            this.panelDocuments.TabIndex = 2;
            // 
            // objectListViewDocuments
            // 
            this.objectListViewDocuments.AllColumns.Add(this.olvColumnIcon);
            this.objectListViewDocuments.AllColumns.Add(this.olvColumnType);
            this.objectListViewDocuments.AllColumns.Add(this.olvColumnDocument);
            this.objectListViewDocuments.AllowDrop = true;
            this.objectListViewDocuments.CellEditUseWholeCell = false;
            this.objectListViewDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnIcon,
            this.olvColumnType,
            this.olvColumnDocument});
            this.objectListViewDocuments.ContextMenuStrip = this.contextMenuStripDocument;
            this.objectListViewDocuments.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewDocuments.FullRowSelect = true;
            this.objectListViewDocuments.GridLines = true;
            this.objectListViewDocuments.HideSelection = false;
            this.objectListViewDocuments.Location = new System.Drawing.Point(0, 0);
            this.objectListViewDocuments.Margin = new System.Windows.Forms.Padding(4);
            this.objectListViewDocuments.Name = "objectListViewDocuments";
            this.objectListViewDocuments.ShowGroups = false;
            this.objectListViewDocuments.Size = new System.Drawing.Size(1039, 200);
            this.objectListViewDocuments.SmallImageList = this.imageList;
            this.objectListViewDocuments.TabIndex = 7;
            this.objectListViewDocuments.UseCompatibleStateImageBehavior = false;
            this.objectListViewDocuments.UseFiltering = true;
            this.objectListViewDocuments.UseHotControls = false;
            this.objectListViewDocuments.View = System.Windows.Forms.View.Details;
            this.objectListViewDocuments.DragDrop += new System.Windows.Forms.DragEventHandler(this.ObjectListViewDocuments_DragDrop);
            this.objectListViewDocuments.DragEnter += new System.Windows.Forms.DragEventHandler(this.ObjectListViewDocuments_DragEnter);
            // 
            // olvColumnType
            // 
            this.olvColumnType.DisplayIndex = 0;
            this.olvColumnType.Text = "Тип";
            this.olvColumnType.Width = 150;
            // 
            // olvColumnDocument
            // 
            this.olvColumnDocument.DisplayIndex = 1;
            this.olvColumnDocument.FillsFreeSpace = true;
            this.olvColumnDocument.Text = "Документ";
            this.olvColumnDocument.Width = 750;
            // 
            // contextMenuStripDocument
            // 
            this.contextMenuStripDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.showInDirectoryToolStripMenuItem,
            this.удалитьИзСпискаToolStripMenuItem});
            this.contextMenuStripDocument.Name = "contextMenuStripDocument";
            this.contextMenuStripDocument.Size = new System.Drawing.Size(175, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // showInDirectoryToolStripMenuItem
            // 
            this.showInDirectoryToolStripMenuItem.Name = "showInDirectoryToolStripMenuItem";
            this.showInDirectoryToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showInDirectoryToolStripMenuItem.Text = "Показать в папке";
            this.showInDirectoryToolStripMenuItem.Click += new System.EventHandler(this.ShowInDirectoryToolStripMenuItem_Click);
            // 
            // удалитьИзСпискаToolStripMenuItem
            // 
            this.удалитьИзСпискаToolStripMenuItem.Name = "удалитьИзСпискаToolStripMenuItem";
            this.удалитьИзСпискаToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.удалитьИзСпискаToolStripMenuItem.Text = "Удалить из списка";
            this.удалитьИзСпискаToolStripMenuItem.Click += new System.EventHandler(this.RemoveOfListToolStripMenuItem_Click);
            // 
            // openFileDialogDocuments
            // 
            this.openFileDialogDocuments.Multiselect = true;
            this.openFileDialogDocuments.RestoreDirectory = true;
            // 
            // olvColumnIcon
            // 
            this.olvColumnIcon.DisplayIndex = 2;
            this.olvColumnIcon.ImageAspectName = "Image";
            this.olvColumnIcon.IsEditable = false;
            this.olvColumnIcon.ShowTextInHeader = false;
            this.olvColumnIcon.Text = "";
            this.olvColumnIcon.Width = 41;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 690);
            this.Controls.Add(this.tableLayoutPanelDocumentsChecks);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 729);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программный комплекс для пакетной автоматизированной проверки офисной документаци" +
    "и";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanelDocumentsChecks.ResumeLayout(false);
            this.tableLayoutPanelTagsChecksDescriptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTags)).EndInit();
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.panelDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).EndInit();
            this.contextMenuStripDocument.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDocumentsChecks;
        private System.Windows.Forms.Button buttonPerform;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTagsChecksDescriptions;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.OpenFileDialog openFileDialogDocuments;
        private BrightIdeasSoftware.ObjectListView objectListViewChecks;
        private BrightIdeasSoftware.OLVColumn olvColumnCheck;
        private BrightIdeasSoftware.ObjectListView objectListViewTags;
        private BrightIdeasSoftware.OLVColumn olvColumnTag;
        private System.Windows.Forms.Panel panelDocuments;
        private BrightIdeasSoftware.ObjectListView objectListViewDocuments;
        private BrightIdeasSoftware.OLVColumn olvColumnDocument;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDocument;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзСпискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportingDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumnIcon;
        private System.Windows.Forms.ImageList imageList;
    }
}

