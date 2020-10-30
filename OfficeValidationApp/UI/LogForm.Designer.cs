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
            this.objectListViewLogs = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnSeverity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSender = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(645, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
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
            this.objectListViewLogs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.objectListViewLogs.Name = "objectListViewLogs";
            this.objectListViewLogs.ShowGroups = false;
            this.objectListViewLogs.Size = new System.Drawing.Size(645, 296);
            this.objectListViewLogs.TabIndex = 7;
            this.objectListViewLogs.UseCompatibleStateImageBehavior = false;
            this.objectListViewLogs.UseFiltering = true;
            this.objectListViewLogs.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnSeverity
            // 
            this.olvColumnSeverity.Text = "Важность";
            this.olvColumnSeverity.Width = 75;
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
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 321);
            this.Controls.Add(this.objectListViewLogs);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LogForm";
            this.Text = "Журнал сообщений";
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
    }
}