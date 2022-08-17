namespace monke
{
    partial class FormClasses
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
            this.comboArchive = new System.Windows.Forms.ComboBox();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.dataGridViewClasses = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.promote = new System.Windows.Forms.DataGridViewButtonColumn();
            this.archive = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelAddClass = new System.Windows.Forms.Panel();
            this.btnConfirmAddClass = new System.Windows.Forms.Button();
            this.inputYear = new System.Windows.Forms.ComboBox();
            this.inputNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnACBack = new System.Windows.Forms.Button();
            this.panelEditClasss = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputNumberE = new System.Windows.Forms.TextBox();
            this.inputYearE = new System.Windows.Forms.ComboBox();
            this.btnConfirmEditClass = new System.Windows.Forms.Button();
            this.btnECBack = new System.Windows.Forms.Button();
            this.panelNav.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
            this.panelAddClass.SuspendLayout();
            this.panelEditClasss.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.panelNav.Controls.Add(this.comboArchive);
            this.panelNav.Controls.Add(this.btnAddClass);
            this.panelNav.Controls.Add(this.label1);
            this.panelNav.Controls.Add(this.tbxSearch);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1063, 97);
            this.panelNav.TabIndex = 5;
            // 
            // comboArchive
            // 
            this.comboArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArchive.FormattingEnabled = true;
            this.comboArchive.Location = new System.Drawing.Point(12, 65);
            this.comboArchive.Name = "comboArchive";
            this.comboArchive.Size = new System.Drawing.Size(121, 21);
            this.comboArchive.TabIndex = 34;
            this.comboArchive.SelectedIndexChanged += new System.EventHandler(this.comboArchive_SelectedIndexChanged);
            this.comboArchive.SelectedValueChanged += new System.EventHandler(this.comboArchive_SelectedValueChanged);
            // 
            // btnAddClass
            // 
            this.btnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnAddClass.FlatAppearance.BorderSize = 2;
            this.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnAddClass.Location = new System.Drawing.Point(243, 9);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(146, 50);
            this.btnAddClass.TabIndex = 8;
            this.btnAddClass.Text = "Dodaj klase";
            this.btnAddClass.UseVisualStyleBackColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wyszukaj klase:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxSearch.Location = new System.Drawing.Point(12, 36);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(214, 23);
            this.tbxSearch.TabIndex = 3;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDataGrid.Controls.Add(this.dataGridViewClasses);
            this.panelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGrid.Location = new System.Drawing.Point(0, 97);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1063, 625);
            this.panelDataGrid.TabIndex = 9;
            // 
            // dataGridViewClasses
            // 
            this.dataGridViewClasses.AllowUserToAddRows = false;
            this.dataGridViewClasses.AllowUserToDeleteRows = false;
            this.dataGridViewClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edit,
            this.promote,
            this.archive,
            this.delete});
            this.dataGridViewClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClasses.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewClasses.Name = "dataGridViewClasses";
            this.dataGridViewClasses.ReadOnly = true;
            this.dataGridViewClasses.RowTemplate.Height = 30;
            this.dataGridViewClasses.Size = new System.Drawing.Size(1063, 625);
            this.dataGridViewClasses.TabIndex = 1;
            this.dataGridViewClasses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasses_CellContentClick);
            // 
            // edit
            // 
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.edit.HeaderText = "Edytuj klase";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Edytuj";
            this.edit.UseColumnTextForButtonValue = true;
            this.edit.Width = 63;
            // 
            // promote
            // 
            this.promote.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.promote.HeaderText = "Awansuj klase";
            this.promote.Name = "promote";
            this.promote.ReadOnly = true;
            this.promote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.promote.Text = "Awansuj";
            this.promote.UseColumnTextForButtonValue = true;
            this.promote.Width = 73;
            // 
            // archive
            // 
            this.archive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.archive.HeaderText = "Archiwizuj klase";
            this.archive.Name = "archive";
            this.archive.ReadOnly = true;
            this.archive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.archive.Text = "Archiwizuj";
            this.archive.UseColumnTextForButtonValue = true;
            this.archive.Width = 79;
            // 
            // delete
            // 
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.delete.HeaderText = "Usuń klase";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Usuń";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 60;
            // 
            // panelAddClass
            // 
            this.panelAddClass.AutoScroll = true;
            this.panelAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panelAddClass.Controls.Add(this.btnConfirmAddClass);
            this.panelAddClass.Controls.Add(this.inputYear);
            this.panelAddClass.Controls.Add(this.inputNumber);
            this.panelAddClass.Controls.Add(this.label6);
            this.panelAddClass.Controls.Add(this.label2);
            this.panelAddClass.Controls.Add(this.btnACBack);
            this.panelAddClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddClass.Enabled = false;
            this.panelAddClass.Location = new System.Drawing.Point(0, 97);
            this.panelAddClass.Name = "panelAddClass";
            this.panelAddClass.Size = new System.Drawing.Size(1063, 625);
            this.panelAddClass.TabIndex = 9;
            this.panelAddClass.Visible = false;
            // 
            // btnConfirmAddClass
            // 
            this.btnConfirmAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmAddClass.Location = new System.Drawing.Point(905, 537);
            this.btnConfirmAddClass.Name = "btnConfirmAddClass";
            this.btnConfirmAddClass.Size = new System.Drawing.Size(146, 76);
            this.btnConfirmAddClass.TabIndex = 32;
            this.btnConfirmAddClass.Text = "Dodaj";
            this.btnConfirmAddClass.UseVisualStyleBackColor = true;
            this.btnConfirmAddClass.Click += new System.EventHandler(this.btnConfirmAddClass_Click);
            // 
            // inputYear
            // 
            this.inputYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputYear.FormattingEnabled = true;
            this.inputYear.Location = new System.Drawing.Point(94, 39);
            this.inputYear.Name = "inputYear";
            this.inputYear.Size = new System.Drawing.Size(143, 21);
            this.inputYear.TabIndex = 20;
            // 
            // inputNumber
            // 
            this.inputNumber.Location = new System.Drawing.Point(94, 9);
            this.inputNumber.Name = "inputNumber";
            this.inputNumber.Size = new System.Drawing.Size(143, 20);
            this.inputNumber.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rocznik: *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Klasa: *";
            // 
            // btnACBack
            // 
            this.btnACBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnACBack.Location = new System.Drawing.Point(961, 11);
            this.btnACBack.Name = "btnACBack";
            this.btnACBack.Size = new System.Drawing.Size(90, 47);
            this.btnACBack.TabIndex = 0;
            this.btnACBack.Text = "Cofnij";
            this.btnACBack.UseVisualStyleBackColor = true;
            this.btnACBack.Click += new System.EventHandler(this.btnACBack_Click);
            // 
            // panelEditClasss
            // 
            this.panelEditClasss.AutoScroll = true;
            this.panelEditClasss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.panelEditClasss.Controls.Add(this.label4);
            this.panelEditClasss.Controls.Add(this.label3);
            this.panelEditClasss.Controls.Add(this.inputNumberE);
            this.panelEditClasss.Controls.Add(this.inputYearE);
            this.panelEditClasss.Controls.Add(this.btnConfirmEditClass);
            this.panelEditClasss.Controls.Add(this.btnECBack);
            this.panelEditClasss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditClasss.Enabled = false;
            this.panelEditClasss.Location = new System.Drawing.Point(0, 97);
            this.panelEditClasss.Name = "panelEditClasss";
            this.panelEditClasss.Size = new System.Drawing.Size(1063, 625);
            this.panelEditClasss.TabIndex = 10;
            this.panelEditClasss.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Klasa: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Rocznik: *";
            // 
            // inputNumberE
            // 
            this.inputNumberE.Location = new System.Drawing.Point(94, 8);
            this.inputNumberE.Name = "inputNumberE";
            this.inputNumberE.Size = new System.Drawing.Size(150, 20);
            this.inputNumberE.TabIndex = 34;
            // 
            // inputYearE
            // 
            this.inputYearE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputYearE.FormattingEnabled = true;
            this.inputYearE.Location = new System.Drawing.Point(94, 32);
            this.inputYearE.Name = "inputYearE";
            this.inputYearE.Size = new System.Drawing.Size(150, 21);
            this.inputYearE.TabIndex = 33;
            // 
            // btnConfirmEditClass
            // 
            this.btnConfirmEditClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmEditClass.Location = new System.Drawing.Point(905, 537);
            this.btnConfirmEditClass.Name = "btnConfirmEditClass";
            this.btnConfirmEditClass.Size = new System.Drawing.Size(146, 76);
            this.btnConfirmEditClass.TabIndex = 32;
            this.btnConfirmEditClass.Text = "Edytuj";
            this.btnConfirmEditClass.UseVisualStyleBackColor = true;
            this.btnConfirmEditClass.Click += new System.EventHandler(this.btnConfirmEditClass_Click);
            // 
            // btnECBack
            // 
            this.btnECBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnECBack.Location = new System.Drawing.Point(961, 9);
            this.btnECBack.Name = "btnECBack";
            this.btnECBack.Size = new System.Drawing.Size(90, 46);
            this.btnECBack.TabIndex = 0;
            this.btnECBack.Text = "Cofnij";
            this.btnECBack.UseVisualStyleBackColor = true;
            this.btnECBack.Click += new System.EventHandler(this.btnECBack_Click);
            // 
            // FormClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 722);
            this.Controls.Add(this.panelAddClass);
            this.Controls.Add(this.panelEditClasss);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelNav);
            this.Name = "FormClasses";
            this.Text = "FormClasses";
            this.Load += new System.EventHandler(this.FormClasses_Load);
            this.Shown += new System.EventHandler(this.FormClasses_Shown);
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
            this.panelAddClass.ResumeLayout(false);
            this.panelAddClass.PerformLayout();
            this.panelEditClasss.ResumeLayout(false);
            this.panelEditClasss.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.DataGridView dataGridViewClasses;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn promote;
        private System.Windows.Forms.DataGridViewButtonColumn archive;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.Panel panelAddClass;
        private System.Windows.Forms.Button btnConfirmAddClass;
        private System.Windows.Forms.ComboBox inputYear;
        private System.Windows.Forms.TextBox inputNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnACBack;
        private System.Windows.Forms.Panel panelEditClasss;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputNumberE;
        private System.Windows.Forms.ComboBox inputYearE;
        private System.Windows.Forms.Button btnConfirmEditClass;
        private System.Windows.Forms.Button btnECBack;
        private System.Windows.Forms.ComboBox comboArchive;
    }
}