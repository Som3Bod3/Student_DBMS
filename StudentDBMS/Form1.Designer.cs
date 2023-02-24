namespace monke
{
    partial class Form1
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
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.subMenuForms = new System.Windows.Forms.Panel();
            this.btnListaKlasowa = new System.Windows.Forms.Button();
            this.btnKartaBadania = new System.Windows.Forms.Button();
            this.btnForms = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.subMenuForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(12)))));
            this.panelSideMenu.Controls.Add(this.btnHelp);
            this.panelSideMenu.Controls.Add(this.subMenuForms);
            this.panelSideMenu.Controls.Add(this.btnForms);
            this.panelSideMenu.Controls.Add(this.btnClasses);
            this.panelSideMenu.Controls.Add(this.btnStudents);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(185, 761);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(35)))), ((int)(((byte)(25)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnHelp.Location = new System.Drawing.Point(0, 219);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHelp.Size = new System.Drawing.Size(185, 45);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Pomoc";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // subMenuForms
            // 
            this.subMenuForms.Controls.Add(this.btnListaKlasowa);
            this.subMenuForms.Controls.Add(this.btnKartaBadania);
            this.subMenuForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenuForms.Location = new System.Drawing.Point(0, 135);
            this.subMenuForms.Name = "subMenuForms";
            this.subMenuForms.Size = new System.Drawing.Size(185, 84);
            this.subMenuForms.TabIndex = 3;
            // 
            // btnListaKlasowa
            // 
            this.btnListaKlasowa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnListaKlasowa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListaKlasowa.FlatAppearance.BorderSize = 0;
            this.btnListaKlasowa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaKlasowa.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnListaKlasowa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnListaKlasowa.Location = new System.Drawing.Point(0, 40);
            this.btnListaKlasowa.Name = "btnListaKlasowa";
            this.btnListaKlasowa.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnListaKlasowa.Size = new System.Drawing.Size(185, 40);
            this.btnListaKlasowa.TabIndex = 1;
            this.btnListaKlasowa.Text = "Lista klasowa";
            this.btnListaKlasowa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListaKlasowa.UseVisualStyleBackColor = false;
            this.btnListaKlasowa.Click += new System.EventHandler(this.btnListaKlasowa_Click);
            // 
            // btnKartaBadania
            // 
            this.btnKartaBadania.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnKartaBadania.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKartaBadania.FlatAppearance.BorderSize = 0;
            this.btnKartaBadania.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKartaBadania.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKartaBadania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnKartaBadania.Location = new System.Drawing.Point(0, 0);
            this.btnKartaBadania.Name = "btnKartaBadania";
            this.btnKartaBadania.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnKartaBadania.Size = new System.Drawing.Size(185, 40);
            this.btnKartaBadania.TabIndex = 0;
            this.btnKartaBadania.Text = "Karta badania";
            this.btnKartaBadania.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKartaBadania.UseVisualStyleBackColor = false;
            this.btnKartaBadania.Click += new System.EventHandler(this.btnKartaBadania_Click);
            // 
            // btnForms
            // 
            this.btnForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnForms.FlatAppearance.BorderSize = 0;
            this.btnForms.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.btnForms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(35)))), ((int)(((byte)(25)))));
            this.btnForms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForms.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnForms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnForms.Location = new System.Drawing.Point(0, 90);
            this.btnForms.Name = "btnForms";
            this.btnForms.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnForms.Size = new System.Drawing.Size(185, 45);
            this.btnForms.TabIndex = 2;
            this.btnForms.Text = "Formularze";
            this.btnForms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForms.UseVisualStyleBackColor = true;
            this.btnForms.Click += new System.EventHandler(this.btnForms_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClasses.FlatAppearance.BorderSize = 0;
            this.btnClasses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.btnClasses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(35)))), ((int)(((byte)(25)))));
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClasses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnClasses.Location = new System.Drawing.Point(0, 45);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClasses.Size = new System.Drawing.Size(185, 45);
            this.btnClasses.TabIndex = 5;
            this.btnClasses.Text = "Klasy";
            this.btnClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClasses.UseVisualStyleBackColor = true;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.btnStudents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(35)))), ((int)(((byte)(25)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.btnStudents.Location = new System.Drawing.Point(0, 0);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(185, 45);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Text = "Uczniowie";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(185, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1079, 761);
            this.panelChildForm.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelSideMenu.ResumeLayout(false);
            this.subMenuForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel subMenuForms;
        private System.Windows.Forms.Button btnListaKlasowa;
        private System.Windows.Forms.Button btnKartaBadania;
        private System.Windows.Forms.Button btnForms;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnClasses;
    }
}

