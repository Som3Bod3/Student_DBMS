using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monke
{
    public partial class FormDialog : Form
    {
        //filePath
        public string selectedDoc { get; set; }
        
        //approximate easily readable name
        public string selectedDocName { get; set; }
        public FormDialog()
        {
            InitializeComponent();

            //Fill combobox with values and display members
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
            dt.Rows.Add("", "-wybierz-");
            dt.Rows.Add("0._karta_badania_profilaktycznego_kl_0.docx", "Karta badania profilaktycznego klasa 0");
            dt.Rows.Add("1._karta_badania_profilaktycznego_kl_3.docx", "Karta badania profilaktycznego klasa 3");
            dt.Rows.Add("2._karta_badania_przesiewowego_kl_5.docx", "Karta badania przesiewowego klasa 5");
            dt.Rows.Add("3._karta_badania_profilaktycznego_kl_7.docx", "Karta badania profilaktycznego klasa 7");
            comboBoxDoc.DataSource = dt;
            comboBoxDoc.DisplayMember = "name";
            comboBoxDoc.ValueMember = "value";
        }

        /// <summary>
        /// Assigns variable values after button send click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            selectedDoc = comboBoxDoc.SelectedValue.ToString();
            selectedDocName = comboBoxDoc.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
