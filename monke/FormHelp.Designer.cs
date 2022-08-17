namespace monke
{
    partial class FormHelp
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateCopy = new System.Windows.Forms.Button();
            this.btnRestoreCopy = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kopie zapasowe �";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // btnCreateCopy
            // 
            this.btnCreateCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(190)))), ((int)(((byte)(150)))));
            this.btnCreateCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnCreateCopy.FlatAppearance.BorderSize = 7;
            this.btnCreateCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateCopy.ForeColor = System.Drawing.Color.Black;
            this.btnCreateCopy.Location = new System.Drawing.Point(12, 55);
            this.btnCreateCopy.Name = "btnCreateCopy";
            this.btnCreateCopy.Size = new System.Drawing.Size(209, 55);
            this.btnCreateCopy.TabIndex = 9;
            this.btnCreateCopy.Text = "Utwórz kopię zapasową";
            this.btnCreateCopy.UseVisualStyleBackColor = false;
            this.btnCreateCopy.Click += new System.EventHandler(this.btnCreateCopy_Click);
            // 
            // btnRestoreCopy
            // 
            this.btnRestoreCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(190)))), ((int)(((byte)(150)))));
            this.btnRestoreCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(152)))), ((int)(((byte)(116)))));
            this.btnRestoreCopy.FlatAppearance.BorderSize = 7;
            this.btnRestoreCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestoreCopy.ForeColor = System.Drawing.Color.Black;
            this.btnRestoreCopy.Location = new System.Drawing.Point(237, 55);
            this.btnRestoreCopy.Name = "btnRestoreCopy";
            this.btnRestoreCopy.Size = new System.Drawing.Size(211, 55);
            this.btnRestoreCopy.TabIndex = 10;
            this.btnRestoreCopy.Text = "Odtwórz kopię zapasową";
            this.btnRestoreCopy.UseVisualStyleBackColor = false;
            this.btnRestoreCopy.Click += new System.EventHandler(this.btnRestoreCopy_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 35000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.btnRestoreCopy);
            this.Controls.Add(this.btnCreateCopy);
            this.Controls.Add(this.label1);
            this.Name = "FormHelp";
            this.Text = "FormHelp";
            this.Load += new System.EventHandler(this.FormHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateCopy;
        private System.Windows.Forms.Button btnRestoreCopy;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}