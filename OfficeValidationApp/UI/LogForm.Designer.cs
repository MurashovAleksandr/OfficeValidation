namespace OfficeValidationApp.UI
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.objectListViewLogs = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnSeverity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSender = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.saveFileDialogLog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(726, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::OfficeValidationApp.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "toolStripButton1";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // objectListViewLogs
            // 
            this.objectListViewLogs.AllColumns.Add(this.olvColumnSeverity);
            this.objectListViewLogs.AllColumns.Add(this.olvColumnMessage);
            this.objectListViewLogs.AllColumns.Add(this.olvColumnSender);
            this.objectListViewLogs.CellEditUseWholeCell = false;
            this.objectListViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnSeverity,
            this.olvColumnMessage,
            this.olvColumnSender});
            this.objectListViewLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewLogs.EmptyListMsg = "Проверка пройдена";
            this.objectListViewLogs.FullRowSelect = true;
            this.objectListViewLogs.GridLines = true;
            this.objectListViewLogs.HideSelection = false;
            this.objectListViewLogs.Location = new System.Drawing.Point(0, 25);
            this.objectListViewLogs.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.objectListViewLogs.Name = "objectListViewLogs";
            this.objectListViewLogs.ShowGroups = false;
            this.objectListViewLogs.Size = new System.Drawing.Size(726, 396);
            this.objectListViewLogs.TabIndex = 7;
            this.objectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.objectListViewLogs.UseFiltering = true;
            this.objectListViewLogs.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnSeverity
            // 
            this.olvColumnSeverity.Text = "Важность";
            this.olvColumnSeverity.Width = 118;
            // 
            // olvColumnMessage
            // 
            this.olvColumnMessage.FillsFreeSpace = true;
            this.olvColumnMessage.Text = "Сообщение";
            this.olvColumnMessage.Width = 340;
            // 
            // olvColumnSender
            // 
            this.olvColumnSender.Text = "Источник";
            this.olvColumnSender.Width = 153;
            // 
            // saveFileDialogLog
            // 
            this.saveFileDialogLog.Filter = "Log File|*.log";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 421);
            this.Controls.Add(this.objectListViewLogs);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал сообщений";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private BrightIdeasSoftware.ObjectListView objectListViewLogs;
        private BrightIdeasSoftware.OLVColumn olvColumnSeverity;
        private BrightIdeasSoftware.OLVColumn olvColumnMessage;
        private BrightIdeasSoftware.OLVColumn olvColumnSender;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLog;
    }
}