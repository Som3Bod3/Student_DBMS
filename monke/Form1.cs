using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Xceed.Words.NET;

namespace monke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
          
          /*  string docPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/monke/test.docx";
            string templatePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/monke/document1.docx";
            DocX obj = DocX.Create(docPath);
            obj.ApplyTemplate(templatePath);
            obj.ReplaceText("<name>", "Chazbijewicz Ahmed");
            obj.Save();
            MessageBox.Show("done");*/

            
        }

        private void hideSubMenu() {
            subMenuForms.Visible = false;
        }

        private void showSubMenu(Panel subMenu) {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else { 
                subMenu.Visible = false;
            }
        }
        private Form openForm = null;
        private void openChildForm(Form childForm) {
            if (openForm != null) { 
                openForm.Close();
            }
            openForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #region Students
        private void btnStudents_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FormStudents());
        }
        #endregion

        #region Forms
        private void btnForms_Click(object sender, EventArgs e)
        {            
            showSubMenu(subMenuForms);
        }
        private void btnKartaBadania_Click(object sender, EventArgs e)
        {
            openChildForm(new FormExaminationCard());
        }

        private void btnListaKlasowa_Click(object sender, EventArgs e)
        {
            openChildForm(new FormClassList());
        }
        #endregion

        #region Help
        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FormHelp());
        }
        #endregion

        #region Classes
        private void btnClasses_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new FormClasses());
        }
        #endregion
    }
}
