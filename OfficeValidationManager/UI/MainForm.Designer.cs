
namespace OfficeValidationManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerDocumentFactoryNamesAndOther = new System.Windows.Forms.SplitContainer();
            this.groupBoxDocumentFactoryNames = new System.Windows.Forms.GroupBox();
            this.checkedListBoxDocumentFactoryNames = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSaveCancel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDocumentFactoryNamesAndOther)).BeginInit();
            this.splitContainerDocumentFactoryNamesAndOther.Panel1.SuspendLayout();
            this.splitContainerDocumentFactoryNamesAndOther.SuspendLayout();
            this.groupBoxDocumentFactoryNames.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelSaveCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerDocumentFactoryNamesAndOther
            // 
            this.splitContainerDocumentFactoryNamesAndOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDocumentFactoryNamesAndOther.Location = new System.Drawing.Point(3, 3);
            this.splitContainerDocumentFactoryNamesAndOther.Name = "splitContainerDocumentFactoryNamesAndOther";
            // 
            // splitContainerDocumentFactoryNamesAndOther.Panel1
            // 
            this.splitContainerDocumentFactoryNamesAndOther.Panel1.Controls.Add(this.groupBoxDocumentFactoryNames);
            this.splitContainerDocumentFactoryNamesAndOther.Size = new System.Drawing.Size(794, 390);
            this.splitContainerDocumentFactoryNamesAndOther.SplitterDistance = 166;
            this.splitContainerDocumentFactoryNamesAndOther.TabIndex = 0;
            // 
            // groupBoxDocumentFactoryNames
            // 
            this.groupBoxDocumentFactoryNames.Controls.Add(this.checkedListBoxDocumentFactoryNames);
            this.groupBoxDocumentFactoryNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDocumentFactoryNames.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDocumentFactoryNames.Name = "groupBoxDocumentFactoryNames";
            this.groupBoxDocumentFactoryNames.Size = new System.Drawing.Size(166, 390);
            this.groupBoxDocumentFactoryNames.TabIndex = 0;
            this.groupBoxDocumentFactoryNames.TabStop = false;
            this.groupBoxDocumentFactoryNames.Text = "Типы документов";
            // 
            // checkedListBoxDocumentFactoryNames
            // 
            this.checkedListBoxDocumentFactoryNames.CheckOnClick = true;
            this.checkedListBoxDocumentFactoryNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxDocumentFactoryNames.FormattingEnabled = true;
            this.checkedListBoxDocumentFactoryNames.Location = new System.Drawing.Point(3, 16);
            this.checkedListBoxDocumentFactoryNames.Name = "checkedListBoxDocumentFactoryNames";
            this.checkedListBoxDocumentFactoryNames.Size = new System.Drawing.Size(160, 371);
            this.checkedListBoxDocumentFactoryNames.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.splitContainerDocumentFactoryNamesAndOther, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelSaveCancel, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.22222F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.77778F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelSaveCancel
            // 
            this.tableLayoutPanelSaveCancel.ColumnCount = 2;
            this.tableLayoutPanelSaveCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSaveCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSaveCancel.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanelSaveCancel.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutPanelSaveCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSaveCancel.Location = new System.Drawing.Point(3, 399);
            this.tableLayoutPanelSaveCancel.Name = "tableLayoutPanelSaveCancel";
            this.tableLayoutPanelSaveCancel.RowCount = 1;
            this.tableLayoutPanelSaveCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSaveCancel.Size = new System.Drawing.Size(794, 48);
            this.tableLayoutPanelSaveCancel.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(391, 42);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(400, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(391, 42);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер конфигурации";
            this.splitContainerDocumentFactoryNamesAndOther.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDocumentFactoryNamesAndOther)).EndInit();
            this.splitContainerDocumentFactoryNamesAndOther.ResumeLayout(false);
            this.groupBoxDocumentFactoryNames.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelSaveCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerDocumentFactoryNamesAndOther;
        private System.Windows.Forms.GroupBox groupBoxDocumentFactoryNames;
        private System.Windows.Forms.CheckedListBox checkedListBoxDocumentFactoryNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSaveCancel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}

