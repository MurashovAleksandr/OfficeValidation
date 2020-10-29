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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelDocumentsChecks = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPerform = new System.Windows.Forms.Button();
            this.tableLayoutPanelTagsChecksDescriptions = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTypesDocuments = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDocumentTypes = new System.Windows.Forms.GroupBox();
            this.groupBoxDocuments = new System.Windows.Forms.GroupBox();
            this.groupBoxTags = new System.Windows.Forms.GroupBox();
            this.groupBoxChecks = new System.Windows.Forms.GroupBox();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.objectListViewDocumentTypes = new BrightIdeasSoftware.ObjectListView();
            this.objectListViewDocuments = new BrightIdeasSoftware.ObjectListView();
            this.objectListViewTags = new BrightIdeasSoftware.ObjectListView();
            this.objectListViewChecks = new BrightIdeasSoftware.ObjectListView();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelDocumentsChecks.SuspendLayout();
            this.tableLayoutPanelTagsChecksDescriptions.SuspendLayout();
            this.tableLayoutPanelTypesDocuments.SuspendLayout();
            this.groupBoxDocumentTypes.SuspendLayout();
            this.groupBoxDocuments.SuspendLayout();
            this.groupBoxTags.SuspendLayout();
            this.groupBoxChecks.SuspendLayout();
            this.groupBoxDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocumentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewChecks)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // openDocumentsToolStripMenuItem
            // 
            this.openDocumentsToolStripMenuItem.Image = global::OfficeValidationApp.Properties.Resources.open;
            this.openDocumentsToolStripMenuItem.Name = "openDocumentsToolStripMenuItem";
            this.openDocumentsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openDocumentsToolStripMenuItem.Text = "Открыть документы";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::OfficeValidationApp.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanelDocumentsChecks
            // 
            this.tableLayoutPanelDocumentsChecks.ColumnCount = 1;
            this.tableLayoutPanelDocumentsChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.buttonPerform, 0, 2);
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.tableLayoutPanelTagsChecksDescriptions, 0, 1);
            this.tableLayoutPanelDocumentsChecks.Controls.Add(this.tableLayoutPanelTypesDocuments, 0, 0);
            this.tableLayoutPanelDocumentsChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDocumentsChecks.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelDocumentsChecks.Name = "tableLayoutPanelDocumentsChecks";
            this.tableLayoutPanelDocumentsChecks.RowCount = 3;
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.2F));
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.8F));
            this.tableLayoutPanelDocumentsChecks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelDocumentsChecks.Size = new System.Drawing.Size(784, 537);
            this.tableLayoutPanelDocumentsChecks.TabIndex = 1;
            // 
            // buttonPerform
            // 
            this.buttonPerform.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPerform.Location = new System.Drawing.Point(681, 503);
            this.buttonPerform.Name = "buttonPerform";
            this.buttonPerform.Size = new System.Drawing.Size(100, 31);
            this.buttonPerform.TabIndex = 0;
            this.buttonPerform.Text = "Запустить";
            this.buttonPerform.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTagsChecksDescriptions
            // 
            this.tableLayoutPanelTagsChecksDescriptions.ColumnCount = 3;
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.06961F));
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.93039F));
            this.tableLayoutPanelTagsChecksDescriptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.groupBoxTags, 0, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.groupBoxChecks, 1, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Controls.Add(this.groupBoxDescription, 2, 0);
            this.tableLayoutPanelTagsChecksDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTagsChecksDescriptions.Location = new System.Drawing.Point(3, 169);
            this.tableLayoutPanelTagsChecksDescriptions.Name = "tableLayoutPanelTagsChecksDescriptions";
            this.tableLayoutPanelTagsChecksDescriptions.RowCount = 1;
            this.tableLayoutPanelTagsChecksDescriptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTagsChecksDescriptions.Size = new System.Drawing.Size(778, 328);
            this.tableLayoutPanelTagsChecksDescriptions.TabIndex = 1;
            // 
            // tableLayoutPanelTypesDocuments
            // 
            this.tableLayoutPanelTypesDocuments.ColumnCount = 2;
            this.tableLayoutPanelTypesDocuments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.65038F));
            this.tableLayoutPanelTypesDocuments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.34962F));
            this.tableLayoutPanelTypesDocuments.Controls.Add(this.groupBoxDocumentTypes, 0, 0);
            this.tableLayoutPanelTypesDocuments.Controls.Add(this.groupBoxDocuments, 1, 0);
            this.tableLayoutPanelTypesDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTypesDocuments.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTypesDocuments.Name = "tableLayoutPanelTypesDocuments";
            this.tableLayoutPanelTypesDocuments.RowCount = 1;
            this.tableLayoutPanelTypesDocuments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTypesDocuments.Size = new System.Drawing.Size(778, 160);
            this.tableLayoutPanelTypesDocuments.TabIndex = 2;
            // 
            // groupBoxDocumentTypes
            // 
            this.groupBoxDocumentTypes.Controls.Add(this.objectListViewDocumentTypes);
            this.groupBoxDocumentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDocumentTypes.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDocumentTypes.Name = "groupBoxDocumentTypes";
            this.groupBoxDocumentTypes.Size = new System.Drawing.Size(177, 154);
            this.groupBoxDocumentTypes.TabIndex = 0;
            this.groupBoxDocumentTypes.TabStop = false;
            this.groupBoxDocumentTypes.Text = "Типы документов";
            // 
            // groupBoxDocuments
            // 
            this.groupBoxDocuments.Controls.Add(this.objectListViewDocuments);
            this.groupBoxDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDocuments.Location = new System.Drawing.Point(186, 3);
            this.groupBoxDocuments.Name = "groupBoxDocuments";
            this.groupBoxDocuments.Size = new System.Drawing.Size(589, 154);
            this.groupBoxDocuments.TabIndex = 1;
            this.groupBoxDocuments.TabStop = false;
            this.groupBoxDocuments.Text = "Документы";
            // 
            // groupBoxTags
            // 
            this.groupBoxTags.Controls.Add(this.objectListViewTags);
            this.groupBoxTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTags.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTags.Name = "groupBoxTags";
            this.groupBoxTags.Size = new System.Drawing.Size(176, 322);
            this.groupBoxTags.TabIndex = 0;
            this.groupBoxTags.TabStop = false;
            this.groupBoxTags.Text = "Метки";
            // 
            // groupBoxChecks
            // 
            this.groupBoxChecks.Controls.Add(this.objectListViewChecks);
            this.groupBoxChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChecks.Location = new System.Drawing.Point(185, 3);
            this.groupBoxChecks.Name = "groupBoxChecks";
            this.groupBoxChecks.Size = new System.Drawing.Size(399, 322);
            this.groupBoxChecks.TabIndex = 1;
            this.groupBoxChecks.TabStop = false;
            this.groupBoxChecks.Text = "Проверки";
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.textBoxDescription);
            this.groupBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDescription.Location = new System.Drawing.Point(590, 3);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(185, 322);
            this.groupBoxDescription.TabIndex = 2;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Описание";
            // 
            // objectListViewDocumentTypes
            // 
            this.objectListViewDocumentTypes.CellEditUseWholeCell = false;
            this.objectListViewDocumentTypes.CheckBoxes = true;
            this.objectListViewDocumentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewDocumentTypes.HideSelection = false;
            this.objectListViewDocumentTypes.Location = new System.Drawing.Point(3, 16);
            this.objectListViewDocumentTypes.Name = "objectListViewDocumentTypes";
            this.objectListViewDocumentTypes.Size = new System.Drawing.Size(171, 135);
            this.objectListViewDocumentTypes.TabIndex = 0;
            this.objectListViewDocumentTypes.UseCompatibleStateImageBehavior = false;
            this.objectListViewDocumentTypes.View = System.Windows.Forms.View.Details;
            // 
            // objectListViewDocuments
            // 
            this.objectListViewDocuments.CellEditUseWholeCell = false;
            this.objectListViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewDocuments.HideSelection = false;
            this.objectListViewDocuments.Location = new System.Drawing.Point(3, 16);
            this.objectListViewDocuments.Name = "objectListViewDocuments";
            this.objectListViewDocuments.Size = new System.Drawing.Size(583, 135);
            this.objectListViewDocuments.TabIndex = 0;
            this.objectListViewDocuments.UseCompatibleStateImageBehavior = false;
            this.objectListViewDocuments.View = System.Windows.Forms.View.Details;
            // 
            // objectListViewTags
            // 
            this.objectListViewTags.CellEditUseWholeCell = false;
            this.objectListViewTags.CheckBoxes = true;
            this.objectListViewTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewTags.HideSelection = false;
            this.objectListViewTags.Location = new System.Drawing.Point(3, 16);
            this.objectListViewTags.Name = "objectListViewTags";
            this.objectListViewTags.Size = new System.Drawing.Size(170, 303);
            this.objectListViewTags.TabIndex = 0;
            this.objectListViewTags.UseCompatibleStateImageBehavior = false;
            this.objectListViewTags.View = System.Windows.Forms.View.Details;
            // 
            // objectListViewChecks
            // 
            this.objectListViewChecks.CellEditUseWholeCell = false;
            this.objectListViewChecks.CheckBoxes = true;
            this.objectListViewChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewChecks.HideSelection = false;
            this.objectListViewChecks.Location = new System.Drawing.Point(3, 16);
            this.objectListViewChecks.Name = "objectListViewChecks";
            this.objectListViewChecks.Size = new System.Drawing.Size(393, 303);
            this.objectListViewChecks.TabIndex = 0;
            this.objectListViewChecks.UseCompatibleStateImageBehavior = false;
            this.objectListViewChecks.View = System.Windows.Forms.View.Details;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(3, 16);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(179, 303);
            this.textBoxDescription.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanelDocumentsChecks);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программный комплекс для пакетной автоматизированной проверки офисной документаци" +
    "и";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanelDocumentsChecks.ResumeLayout(false);
            this.tableLayoutPanelTagsChecksDescriptions.ResumeLayout(false);
            this.tableLayoutPanelTypesDocuments.ResumeLayout(false);
            this.groupBoxDocumentTypes.ResumeLayout(false);
            this.groupBoxDocuments.ResumeLayout(false);
            this.groupBoxTags.ResumeLayout(false);
            this.groupBoxChecks.ResumeLayout(false);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocumentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewChecks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDocumentsChecks;
        private System.Windows.Forms.Button buttonPerform;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTagsChecksDescriptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTypesDocuments;
        private System.Windows.Forms.GroupBox groupBoxDocumentTypes;
        private System.Windows.Forms.GroupBox groupBoxDocuments;
        private System.Windows.Forms.GroupBox groupBoxTags;
        private System.Windows.Forms.GroupBox groupBoxChecks;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private BrightIdeasSoftware.ObjectListView objectListViewDocumentTypes;
        private BrightIdeasSoftware.ObjectListView objectListViewDocuments;
        private BrightIdeasSoftware.ObjectListView objectListViewTags;
        private BrightIdeasSoftware.ObjectListView objectListViewChecks;
        private System.Windows.Forms.TextBox textBoxDescription;
    }
}

