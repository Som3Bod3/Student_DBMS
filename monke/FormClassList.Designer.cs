namespace monke
{
    partial class FormClassList
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.comboArchive = new System.Windows.Forms.ComboBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnChangePath = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewClasses = new System.Windows.Forms.DataGridView();
            this.generate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelNav.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.panelNav.Controls.Add(this.label1);
            this.panelNav.Controls.Add(this.tbxSearch);
            this.panelNav.Controls.Add(this.comboArchive);
            this.panelNav.Controls.Add(this.labelPath);
            this.panelNav.Controls.Add(this.btnChangePath);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(1050, 97);
            this.panelNav.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Wyszukaj klase:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxSearch.Location = new System.Drawing.Point(12, 37);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(214, 23);
            this.tbxSearch.TabIndex = 39;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // comboArchive
            // 
            this.comboArchive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArchive.FormattingEnabled = true;
            this.comboArchive.Location = new System.Drawing.Point(12, 66);
            this.comboArchive.Name = "comboArchive";
            this.comboArchive.Size = new System.Drawing.Size(121, 21);
            this.comboArchive.TabIndex = 38;
            this.comboArchive.SelectedValueChanged += new System.EventHandler(this.comboArchive_SelectedValueChanged);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.labelPath.Location = new System.Drawing.Point(242, 69);
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
            this.btnChangePath.Location = new System.Drawing.Point(245, 9);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Size = new System.Drawing.Size(184, 51);
            this.btnChangePath.TabIndex = 36;
            this.btnChangePath.Text = "Zmień ścieżkę plików";
            this.btnChangePath.UseVisualStyleBackColor = false;
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dataGridViewClasses);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 553);
            this.panel1.TabIndex = 38;
            // 
            // dataGridViewClasses
            // 
            this.dataGridViewClasses.AllowUserToAddRows = false;
            this.dataGridViewClasses.AllowUserToDeleteRows = false;
            this.dataGridViewClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.generate});
            this.dataGridViewClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClasses.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewClasses.Name = "dataGridViewClasses";
            this.dataGridViewClasses.ReadOnly = true;
            this.dataGridViewClasses.RowTemplate.Height = 30;
            this.dataGridViewClasses.Size = new System.Drawing.Size(1050, 553);
            this.dataGridViewClasses.TabIndex = 1;
            this.dataGridViewClasses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasses_CellContentClick);
            // 
            // generate
            // 
            this.generate.HeaderText = "Generuj liste";
            this.generate.Name = "generate";
            this.generate.ReadOnly = true;
            this.generate.Text = "Generuj";
            this.generate.UseColumnTextForButtonValue = true;
            this.generate.Width = 71;
            // 
            // FormClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelNav);
            this.Name = "FormClassList";
            this.Text = "FormClassList";
            this.Load += new System.EventHandler(this.FormExaminationCard_Load);
            this.Shown += new System.EventHandler(this.FormClassList_Shown);
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnChangePath;
        private System.Windows.Forms.ComboBox comboArchive;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewClasses;
        private System.Windows.Forms.DataGridViewButtonColumn generate;
    }
}