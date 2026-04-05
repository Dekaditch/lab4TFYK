namespace lab1.Forms
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colMatchedText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCharPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.grpSearchOptions = new System.Windows.Forms.GroupBox();
            this.grpSearchMethod = new System.Windows.Forms.GroupBox();
            this.radAutomaton = new System.Windows.Forms.RadioButton();
            this.radRegex = new System.Windows.Forms.RadioButton();
            this.chkMultiline = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.grpSearchOptions.SuspendLayout();
            this.grpSearchMethod.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Идентификаторы (буква, $ или _, затем буквы)",
            "Российские номера телефонов (+7 или 8, код, номер)",
            "Пути к файлам Windows (C:\\folder\\file.txt)"});
            this.cmbSearchType.Location = new System.Drawing.Point(120, 25);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(450, 24);
            this.cmbSearchType.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(580, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(686, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(6, 28);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(92, 17);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Найдено: 0";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatchedText,
            this.colLineNumber,
            this.colCharPosition,
            this.colLength});
            this.dgvResults.Location = new System.Drawing.Point(9, 48);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(772, 320);
            this.dgvResults.TabIndex = 4;
            // 
            // colMatchedText
            // 
            this.colMatchedText.HeaderText = "Найденная подстрока";
            this.colMatchedText.Name = "colMatchedText";
            this.colMatchedText.ReadOnly = true;
            // 
            // colLineNumber
            // 
            this.colLineNumber.HeaderText = "Строка";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.ReadOnly = true;
            // 
            // colCharPosition
            // 
            this.colCharPosition.HeaderText = "Позиция";
            this.colCharPosition.Name = "colCharPosition";
            this.colCharPosition.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "Длина";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblStatus.Location = new System.Drawing.Point(6, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(775, 30);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Готов к поиску";
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchType.Location = new System.Drawing.Point(6, 28);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(98, 17);
            this.lblSearchType.TabIndex = 6;
            this.lblSearchType.Text = "Тип поиска:";
            // 
            // grpSearchOptions
            // 
            this.grpSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchOptions.Controls.Add(this.grpSearchMethod);
            this.grpSearchOptions.Controls.Add(this.chkMultiline);
            this.grpSearchOptions.Controls.Add(this.chkIgnoreCase);
            this.grpSearchOptions.Controls.Add(this.lblSearchType);
            this.grpSearchOptions.Controls.Add(this.cmbSearchType);
            this.grpSearchOptions.Controls.Add(this.btnSearch);
            this.grpSearchOptions.Controls.Add(this.btnClear);
            this.grpSearchOptions.Location = new System.Drawing.Point(12, 12);
            this.grpSearchOptions.Name = "grpSearchOptions";
            this.grpSearchOptions.Size = new System.Drawing.Size(794, 130);
            this.grpSearchOptions.TabIndex = 7;
            this.grpSearchOptions.TabStop = false;
            this.grpSearchOptions.Text = "Параметры поиска";
            // 
            // grpSearchMethod
            // 
            this.grpSearchMethod.Controls.Add(this.radAutomaton);
            this.grpSearchMethod.Controls.Add(this.radRegex);
            this.grpSearchMethod.Location = new System.Drawing.Point(9, 85);
            this.grpSearchMethod.Name = "grpSearchMethod";
            this.grpSearchMethod.Size = new System.Drawing.Size(250, 35);
            this.grpSearchMethod.TabIndex = 12;
            this.grpSearchMethod.TabStop = false;
            this.grpSearchMethod.Text = "Метод поиска (для телефонов)";
            // 
            // radAutomaton
            // 
            this.radAutomaton.AutoSize = true;
            this.radAutomaton.Location = new System.Drawing.Point(120, 14);
            this.radAutomaton.Name = "radAutomaton";
            this.radAutomaton.Size = new System.Drawing.Size(120, 17);
            this.radAutomaton.TabIndex = 11;
            this.radAutomaton.Text = "Конечный автомат";
            this.radAutomaton.UseVisualStyleBackColor = true;
            // 
            // radRegex
            // 
            this.radRegex.AutoSize = true;
            this.radRegex.Checked = true;
            this.radRegex.Location = new System.Drawing.Point(6, 14);
            this.radRegex.Name = "radRegex";
            this.radRegex.Size = new System.Drawing.Size(147, 17);
            this.radRegex.TabIndex = 10;
            this.radRegex.TabStop = true;
            this.radRegex.Text = "Регулярные выражения";
            this.radRegex.UseVisualStyleBackColor = true;
            // 
            // chkMultiline
            // 
            this.chkMultiline.AutoSize = true;
            this.chkMultiline.Checked = true;
            this.chkMultiline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMultiline.Location = new System.Drawing.Point(190, 60);
            this.chkMultiline.Name = "chkMultiline";
            this.chkMultiline.Size = new System.Drawing.Size(176, 17);
            this.chkMultiline.TabIndex = 9;
            this.chkMultiline.Text = "Многострочный режим (^ и $)";
            this.chkMultiline.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(9, 60);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(141, 17);
            this.chkIgnoreCase.TabIndex = 8;
            this.chkIgnoreCase.Text = "Игнорировать регистр";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.btnSelectAll);
            this.grpResults.Controls.Add(this.btnExport);
            this.grpResults.Controls.Add(this.lblCount);
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Controls.Add(this.lblStatus);
            this.grpResults.Location = new System.Drawing.Point(12, 148);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(794, 488);
            this.grpResults.TabIndex = 8;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Результаты поиска";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(9, 415);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(146, 30);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = "Выделить всё в тексте";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(635, 415);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(146, 30);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Экспорт в файл";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 648);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpSearchOptions);
            this.MinimumSize = new System.Drawing.Size(834, 687);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск с использованием регулярных выражений";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.grpSearchOptions.ResumeLayout(false);
            this.grpSearchOptions.PerformLayout();
            this.grpSearchMethod.ResumeLayout(false);
            this.grpSearchMethod.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.GroupBox grpSearchOptions;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.CheckBox chkMultiline;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatchedText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.GroupBox grpSearchMethod;
        private System.Windows.Forms.RadioButton radAutomaton;
        private System.Windows.Forms.RadioButton radRegex;
    }
}