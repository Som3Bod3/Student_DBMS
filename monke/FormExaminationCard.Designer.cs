namespace monke
{
    partial class FormExaminationCard
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
            this.panelNav = new System.Windows.Forms.Panel();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnChangePath = new System.Windows.Forms.Button();
            this.comboArchive = new System.Windows.Forms.ComboBox();
            this.checkBoxPESEL = new System.Windows.Forms.CheckBox();
            this.checkBoxImie = new System.Windows.Forms.CheckBox();
            this.checkBoxNazwisko = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.generate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelNav.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.panelNav.Controls.Add(this.labelPath);
            this.panelNav.Controls.Add(this.btnChangePath);
            this.panelNav.Controls.Add(this.comboArchive);
            this.panelNav.Controls.Add(this.checkBoxPESEL);
            this.panelNav.Controls.Add(this.checkBoxImie);
            this.panelNav.Controls.Add(this.checkBoxNazwisko);
            this.panelNav.Controls.Add(this.label1);
            this.panelNav.Controls.Add(this.tbxSearch);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1050, 97);
            this.panelNav.TabIndex = 5;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.labelPath.Location = new System.Drawing.Point(308, 73);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(85, 18);
            this.labelPath.TabIndex = 37;
            this.labelPath.Text = "labelPath";
            // 
            // btnChangePath
            // 
            this.btnChangePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnChangePath.FlatAppearance.BorderSize = 2;
            this.btnChangePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChangePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnChangePath.Location = new System.Drawing.Point(311, 9);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Size = new System.Drawing.Size(181, 55);
            this.btnChangePath.TabIndex = 36;
            this.btnChangePath.Text = "Zmień ścieżkę plików";
            this.btnChangePath.UseVisualStyleBackColor = false;
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
            // 
            // comboArchive
            // 
            this.comboArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArchive.FormattingEnabled = true;
            this.comboArchive.Location = new System.Drawing.Point(169, 9);
            this.comboArchive.Name = "comboArchive";
            this.comboArchive.Size = new System.Drawing.Size(121, 21);
            this.comboArchive.TabIndex = 35;
            this.comboArchive.SelectedValueChanged += new System.EventHandler(this.comboArchive_SelectedValueChanged);
            // 
            // checkBoxPESEL
            // 
            this.checkBoxPESEL.AutoSize = true;
            this.checkBoxPESEL.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxPESEL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.checkBoxPESEL.Location = new System.Drawing.Point(172, 70);
            this.checkBoxPESEL.Name = "checkBoxPESEL";
            this.checkBoxPESEL.Size = new System.Drawing.Size(71, 21);
            this.checkBoxPESEL.TabIndex = 7;
            this.checkBoxPESEL.Text = "PESEL";
            this.checkBoxPESEL.UseVisualStyleBackColor = true;
            this.checkBoxPESEL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxPESEL_MouseUp);
            // 
            // checkBoxImie
            // 
            this.checkBoxImie.AutoSize = true;
            this.checkBoxImie.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxImie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.checkBoxImie.Location = new System.Drawing.Point(110, 70);
            this.checkBoxImie.Name = "checkBoxImie";
            this.checkBoxImie.Size = new System.Drawing.Size(56, 21);
            this.checkBoxImie.TabIndex = 6;
            this.checkBoxImie.Text = "Imie";
            this.checkBoxImie.UseVisualStyleBackColor = true;
            this.checkBoxImie.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxImie_MouseUp);
            // 
            // checkBoxNazwisko
            // 
            this.checkBoxNazwisko.AutoSize = true;
            this.checkBoxNazwisko.Checked = true;
            this.checkBoxNazwisko.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNazwisko.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxNazwisko.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.checkBoxNazwisko.Location = new System.Drawing.Point(12, 70);
            this.checkBoxNazwisko.Name = "checkBoxNazwisko";
            this.checkBoxNazwisko.Size = new System.Drawing.Size(92, 21);
            this.checkBoxNazwisko.TabIndex = 5;
            this.checkBoxNazwisko.Text = "Nazwisko";
            this.checkBoxNazwisko.UseVisualStyleBackColor = true;
            this.checkBoxNazwisko.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxNazwisko_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wyszukaj ucznia:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxSearch.Location = new System.Drawing.Point(12, 41);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(278, 23);
            this.tbxSearch.TabIndex = 3;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDataGrid.Controls.Add(this.dataGridViewStudents);
            this.panelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGrid.Location = new System.Drawing.Point(0, 97);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1050, 553);
            this.panelDataGrid.TabIndex = 36;
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.generate});
            this.dataGridViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudents.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowTemplate.Height = 30;
            this.dataGridViewStudents.Size = new System.Drawing.Size(1050, 553);
            this.dataGridViewStudents.TabIndex = 1;
            this.dataGridViewStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellContentClick);
            // 
            // generate
            // 
            this.generate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.generate.HeaderText = "Generuj karte";
            this.generate.Name = "generate";
            this.generate.ReadOnly = true;
            this.generate.Text = "Generuj";
            this.generate.UseColumnTextForButtonValue = true;
            this.generate.Width = 77;
            // 
            // FormExaminationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelNav);
            this.Name = "FormExaminationCard";
            this.Text = "FormExaminationCard";
            this.Load += new System.EventHandler(this.FormExaminationCard_Load);
            this.Shown += new System.EventHandler(this.FormExaminationCard_Shown);
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.ComboBox comboArchive;
        private System.Windows.Forms.CheckBox checkBoxPESEL;
        private System.Windows.Forms.CheckBox checkBoxImie;
        private System.Windows.Forms.CheckBox checkBoxNazwisko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridViewButtonColumn generate;
        private System.Windows.Forms.Button btnChangePath;
        private System.Windows.Forms.Label labelPath;
    }
}