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
        //variable for currently open child Form
        private Form openForm = null;
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
        }

        /// <summary>
        /// hides sibmenu elements
        /// </summary>
        private void hideSubMenu() {
            subMenuForms.Visible = false;
        }

        /// <summary>
        /// toggles submeny visibility
        /// </summary>
        /// <param name="subMenu"></param>
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
        
        /// <summary>
        /// opens child form corresponding to pressed button
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm) {
            //close current child form
            if (openForm != null) { 
                openForm.Close();
            }
            //assing new form
            openForm = childForm;
            //set properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //events for each for buttons on the panel
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
