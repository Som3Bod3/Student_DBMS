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

namespace monke
{
    public partial class FormClasses : Form
    {
        
        //dodac automatyczne awansowanie klasy do kolejnego roku, przy 9 klasie automatycznie archiwizowac
        
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";      
        DataSet ds = new DataSet();
        int id;

        public FormClasses()
        {
            InitializeComponent();
        }

        #region panelData
        private void FormClasses_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            reSearch();
        }
        private void loadDataGrid()
        {
            var select = $"SELECT Id, CONCAT(classN, classL) AS klasa, CONCAT(year,'/',year+1) AS rocznik, archive FROM Classes;";
            using (var con = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(select, con);
                dataAdapter.Fill(ds);
                dataGridViewClasses.ReadOnly = true;
                dataGridViewClasses.DataSource = ds.Tables[0];
                dataGridViewClasses.Columns[4].HeaderText = "ID";
                dataGridViewClasses.Columns[5].HeaderText = "Klasa";
                dataGridViewClasses.Columns[6].HeaderText = "Rocznik";
                dataGridViewClasses.Columns[7].HeaderText = "Archiwum";
            }      
        }
        private void reSearch()
        {//o co kurwa chodzi           
            DataRowView drv = (DataRowView)comboArchive.SelectedItem;
            string fkof = drv["value"].ToString();            
            var select = $"SELECT Id, CONCAT(classN, classL) AS klasa, CONCAT(year,'/',year+1) AS rocznik, archive FROM Classes WHERE {fkof} AND (classN LIKE '%{tbxSearch.Text}%' OR classL LIKE '%{tbxSearch.Text}%' OR year LIKE '%{tbxSearch.Text}%') ";  
            using (var con = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(select, con);
                ds.Clear();
                dataAdapter.Fill(ds);
            }
        }
        private void dataGridViewClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                if (e.ColumnIndex == 0)
                {
                    panelEditClass();
                }
                else if (e.ColumnIndex == 1)
                {
                    panelPromoteClass();
                }
                else if (e.ColumnIndex == 2)
                {
                    panelArchiveClass();
                }
                else if (e.ColumnIndex == 3)
                {
                    panelDeleteClass();
                }
            }
        }
        #endregion

        #region addClass
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            panelAddClass.Enabled = true;
            panelAddClass.Visible = true;
            populateComboBoxes(false);
        }
        private void btnConfirmAddClass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (inputNumber.Text != "" && inputNumber.Text.Length == 2 && Char.IsDigit(inputNumber.Text[0]) && Char.IsLetter(inputNumber.Text[1]))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = $"SELECT * FROM Classes WHERE classN = '{inputNumber.Text[0]}' AND classL = '{inputNumber.Text[1]}' AND year = '{inputYear.SelectedValue}'";
                    if (cmd.ExecuteScalar() == null)
                    {
                        cmd.CommandText = $"INSERT INTO Classes(classN, classL, year) VALUES ('{inputNumber.Text[0]}','{inputNumber.Text[1]}','{inputYear.SelectedValue}');";

                        MessageBox.Show(cmd.CommandText);
                        MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());
                    }
                    else
                    {
                        MessageBox.Show("Taka klasa juz istnieje!");
                    }

                }
                else
                {
                    MessageBox.Show("Uzupelnij wszystkie wymagane pola (*) i upewnij sie że ich format jest poprawny!");
                }

            }
        }
        private void btnACBack_Click(object sender, EventArgs e)
        {
            panelAddClass.Enabled = false;
            panelAddClass.Visible = false;
            reSearch();
            panelAddClass.Controls.ClearControls();
        }
        private void populateComboBoxes(bool edit)
        {
            DataTable dtYear = new DataTable();
            dtYear.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
            var currentYear = DateTime.Now.Year;
            int margin = -15;
            while (margin <= 15)
            {
                dtYear.Rows.Add(currentYear + margin, (currentYear + margin).ToString() + "/" + (currentYear + margin + 1).ToString());
                //inputYear.Items.Add(currentYear + margin);
                margin++;
            }
            
            if (edit)
            {
                inputYearE.DataSource = dtYear;
                inputYearE.DisplayMember = "name";
                inputYearE.ValueMember = "value";                
                var select = $"SELECT * FROM Classes WHERE Id = '{id}';";
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(select, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    inputYearE.SelectedValue = dr["year"].ToString();
                    var old = dr["classN"].ToString() + dr["classL"].ToString();
                    inputNumberE.Text = old.Substring(0, 2);
                    dr.Close();
                }
            }
            else {
                inputYear.DataSource = dtYear;
                inputYear.DisplayMember = "name";
                inputYear.ValueMember = "value";
                inputYear.SelectedValue = currentYear;
            }
        }
        #endregion

        #region editClass
        private void panelEditClass()
        {
            panelEditClasss.Enabled = true;
            panelEditClasss.Visible = true;
            populateComboBoxes(true);
        }
        private void btnConfirmEditClass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (inputNumberE.Text != "" && inputNumberE.Text.Length == 2 && Char.IsDigit(inputNumberE.Text[0]) && Char.IsLetter(inputNumberE.Text[1]))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = $"SELECT * FROM Classes WHERE classN = '{inputNumberE.Text[0]}' AND classL = '{inputNumberE.Text[1]}' AND year = '{inputYearE.SelectedValue}' AND Id != '{id}'";
                    if (cmd.ExecuteScalar() == null)
                    {
                        cmd.CommandText = $"UPDATE Classes SET classN = '{inputNumberE.Text[0]}', classL = '{inputNumberE.Text[1]}', year = '{inputYearE.SelectedValue}' WHERE Id = '{id}';";

                        MessageBox.Show(cmd.CommandText);
                        MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());
                    }
                    else
                    {
                        MessageBox.Show("Taka klasa juz istnieje!");
                    }

                }
                else
                {
                    MessageBox.Show("Uzupelnij wszystkie wymagane pola (*) i upewnij sie że ich format jest poprawny!");
                }

            }
        }
        private void btnECBack_Click(object sender, EventArgs e)
        {
            panelEditClasss.Enabled = false;
            panelEditClasss.Visible = false;
            reSearch();
            panelEditClasss.Controls.ClearControls();
        }
        #endregion

        private void panelDeleteClass()
        {
            string delete = "";
            string msg = "";
            DialogResult dialogResult2 = MessageBox.Show("Czy usunąć także uczniów tej klasy?", "Wybierz opcje usunięcia.", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                delete = $"DELETE FROM Classes WHERE Id = '{id}'; DELETE FROM Kids WHERE class_id = '{id}'";
                msg = "Potwierdź usunięcie klasy o ID = " + id.ToString() + " oraz jej uczniów.";
                
            }
            else if (dialogResult2 == DialogResult.No)
            {
                delete = "DELETE FROM Classes WHERE Id = '" + id.ToString() + "';";
                msg = "Potwierdź usunięcie klasy o ID = " + id.ToString() + ".";
            }
            else {
                return;
            }

            DialogResult dialogResult1 = MessageBox.Show( msg , "Wybierz opcje usunięcia.", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {                
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(delete, con);
                    int p = cmd.ExecuteNonQuery();
                    MessageBox.Show("Pomyślnie usunięto klase " + p.ToString());
                    reSearch();
                }
            }
        }
        private void panelPromoteClass()
        {
            MessageBox.Show("awanms");
        }
        private void panelArchiveClass()
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DialogResult dialogResult1 = DialogResult.No;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = $"SELECT * FROM Classes WHERE Id = '{id}'";
                var update = "";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr["archive"].ToString() == "False")
                {
                    DialogResult dialogResult2 = MessageBox.Show("Czy zarchiwizować także uczniów tej klasy?", "Wybierz opcje archiwizacji.", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        update = $"UPDATE Classes SET archive = '1' WHERE Id = '{id}'; UPDATE Kids SET archive = '1' WHERE class_id = '{id}'";
                        dialogResult1 = MessageBox.Show($"Potwierdz archiwizacje klasy o ID = {id} oraz jej uczniów", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);
                        

                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        update = $"UPDATE Classes SET archive = '1' WHERE Id = '{id}';";
                        dialogResult1 = MessageBox.Show($"Potwierdz archiwizacje klasy o ID = {id}", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        return;
                    }
                }
                else if(dr["archive"].ToString() == "True")
                {
                    DialogResult dialogResult2 = MessageBox.Show("Czy cofnąć także archiwizacje uczniów tej klasy?", "Wybierz opcje archiwizacji.", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        update = $"UPDATE Classes SET archive = '0' WHERE Id = '{id}'; UPDATE Kids SET archive = '0' WHERE class_id = '{id}'";
                        dialogResult1 = MessageBox.Show($"Potwierdz cofnięcie archiwizacji klasy o ID = {id} oraz jej uczniów", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);


                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        update = $"UPDATE Classes SET archive = '0' WHERE Id = '{id}';";
                        dialogResult1 = MessageBox.Show($"Potwierdz cofnięcie archiwizacji klasy o ID = {id}", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        return;
                    }
                }
                dr.Close();
                if (dialogResult1 == DialogResult.Yes) {
                    cmd.CommandText = update;
                    MessageBox.Show(update);
                    MessageBox.Show(cmd.ExecuteNonQuery().ToString());
                    reSearch();
                }
            }
        }
        private void comboArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reSearch();
        }
        private void FormClasses_Shown(object sender, EventArgs e)
        {
            DataTable dtArchive = new DataTable();
            dtArchive.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
            dtArchive.Rows.Add("archive = '0'", "Bez zarchiwizowanych");
            dtArchive.Rows.Add("archive = '1'", "Tylko zarchiwizowane");
            dtArchive.Rows.Add("archive = '0' OR archive = '1'", "Wszystkie");
            comboArchive.DataSource = dtArchive;
            comboArchive.DisplayMember = "name";
            comboArchive.ValueMember = "value";
            comboArchive.SelectedValue = "archive = '0'";
        }
        private void comboArchive_SelectedValueChanged(object sender, EventArgs e)
        {
            reSearch();
        }
    }
}
