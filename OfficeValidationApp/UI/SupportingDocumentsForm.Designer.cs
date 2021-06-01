namespace OfficeValidationApp.UI
{
    partial class SupportingDocumentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportingDocumentsForm));
            this.objectListViewDocuments = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExtentions = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListViewDocuments
            // 
            this.objectListViewDocuments.AllColumns.Add(this.olvColumnType);
            this.objectListViewDocuments.AllColumns.Add(this.olvColumnExtentions);
            this.objectListViewDocuments.AllowDrop = true;
            this.objectListViewDocuments.CellEditUseWholeCell = false;
            this.objectListViewDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnType,
            this.olvColumnExtentions});
            this.objectListViewDocuments.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewDocuments.FullRowSelect = true;
            this.objectListViewDocuments.GridLines = true;
            this.objectListViewDocuments.HideSelection = false;
            this.objectListViewDocuments.Location = new System.Drawing.Point(0, 0);
            this.objectListViewDocuments.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.objectListViewDocuments.Name = "objectListViewDocuments";
            this.objectListViewDocuments.ShowGroups = false;
            this.objectListViewDocuments.Size = new System.Drawing.Size(726, 745);
            this.objectListViewDocuments.TabIndex = 8;
            this.objectListViewDocuments.UseCompatibleStateImageBehavior = false;
            this.objectListViewDocuments.UseFiltering = true;
            this.objectListViewDocuments.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnType
            // 
            this.olvColumnType.Text = "Тип";
            this.olvColumnType.Width = 100;
            // 
            // olvColumnExtentions
            // 
            this.olvColumnExtentions.FillsFreeSpace = true;
            this.olvColumnExtentions.Text = "Расширения";
            this.olvColumnExtentions.Width = 350;
            // 
            // SupportingDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 745);
            this.Controls.Add(this.objectListViewDocuments);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SupportingDocumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список поддерживаемых документов";
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListViewDocuments;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private BrightIdeasSoftware.OLVColumn olvColumnExtentions;
    }
}