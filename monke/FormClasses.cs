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
        //sql connection string
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";      
        //dataset for datapanel
        DataSet ds = new DataSet();
        //row id var
        int id;

        public FormClasses()
        {
            InitializeComponent();
        }

        //display and search through data records
        #region panelData
        //event
        private void FormClasses_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        //event
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            reSearch();
        }
        /// <summary>
        /// Collects all data records from sql
        /// </summary>
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
        /// <summary>
        /// Collects data compatible with search requirements
        /// </summary>
        private void reSearch()
        {         
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
        /// <summary>
        /// event that selects function based on column index and collects row id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //check for correct row
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

        //add class button functions
        #region addClass
        /// <summary>
        /// Diplays add class form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            //display add class form panel
            panelAddClass.Enabled = true;
            panelAddClass.Visible = true;
            //call function to fill combobox values
            populateComboBoxes(false);
        }
        /// <summary>
        /// Reads user input and adds new record to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmAddClass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //check class name syntax
                if (inputNumber.Text != "" && inputNumber.Text.Length == 2 && Char.IsDigit(inputNumber.Text[0]) && Char.IsLetter(inputNumber.Text[1]))
                {
                    //connect to db
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    //query selects identical records
                    cmd.CommandText = $"SELECT * FROM Classes WHERE classN = '{inputNumber.Text[0]}' AND classL = '{inputNumber.Text[1]}' AND year = '{inputYear.SelectedValue}'";
                    //check if identical records exist
                    if (cmd.ExecuteScalar() == null)
                    {
                        //insert query
                        cmd.CommandText = $"INSERT INTO Classes(classN, classL, year) VALUES ('{inputNumber.Text[0]}','{inputNumber.Text[1]}','{inputYear.SelectedValue}');";
                        MessageBox.Show(cmd.CommandText);
                        MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());
                    }
                    else
                    {
                        //class already exists alert
                        MessageBox.Show("Taka klasa juz istnieje!");
                    }

                }
                else
                {
                    //fill required fields alert
                    MessageBox.Show("Uzupelnij wszystkie wymagane pola (*) i upewnij sie że ich format jest poprawny!");
                }

            }
        }
        /// <summary>
        /// Function closes add panel and refreshes data in table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnACBack_Click(object sender, EventArgs e)
        {
            panelAddClass.Enabled = false;
            panelAddClass.Visible = false;
            reSearch();
            panelAddClass.Controls.ClearControls();
        }
        /// <summary>
        /// Function fills comboBox values 
        /// </summary>
        /// <param name="edit"></param>
        private void populateComboBoxes(bool edit)
        {
            //create data set
            DataTable dtYear = new DataTable();
            dtYear.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
            //get current calendar year
            var currentYear = DateTime.Now.Year;
            int margin = -15;
            //fill dataset with 30 years starting from 15 years back
            while (margin <= 15)
            {
                dtYear.Rows.Add(currentYear + margin, (currentYear + margin).ToString() + "/" + (currentYear + margin + 1).ToString());
                //inputYear.Items.Add(currentYear + margin);
                margin++;
            }
            
            //check if the comboboc thats being filled is in the edit class form
            if (edit)
            {
                //assign dataset to combobox
                inputYearE.DataSource = dtYear;
                inputYearE.DisplayMember = "name";
                inputYearE.ValueMember = "value";    
                //colect data of class from db and choose correst option in combobox
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
                //assign dataset to combobox
                inputYear.DataSource = dtYear;
                inputYear.DisplayMember = "name";
                inputYear.ValueMember = "value";
                inputYear.SelectedValue = currentYear;
            }
        }
        #endregion

        //edit class chosen from datapanel
        #region editClass
        /// <summary>
        /// Makes the edit panel visible
        /// </summary>
        private void panelEditClass()
        {
            panelEditClasss.Enabled = true;
            panelEditClasss.Visible = true;
            populateComboBoxes(true);
        }
        /// <summary>
        /// Collects edited data and updates record in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmEditClass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //check for correct syntax in class name
                if (inputNumberE.Text != "" && inputNumberE.Text.Length == 2 && Char.IsDigit(inputNumberE.Text[0]) && Char.IsLetter(inputNumberE.Text[1]))
                {
                    //open connection to db and select classes identical to new updated data
                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = $"SELECT * FROM Classes WHERE classN = '{inputNumberE.Text[0]}' AND classL = '{inputNumberE.Text[1]}' AND year = '{inputYearE.SelectedValue}' AND Id != '{id}'";
                    //check if such class doesnt exists
                    if (cmd.ExecuteScalar() == null)
                    {
                        //update record in db
                        cmd.CommandText = $"UPDATE Classes SET classN = '{inputNumberE.Text[0]}', classL = '{inputNumberE.Text[1]}', year = '{inputYearE.SelectedValue}' WHERE Id = '{id}';";
                        MessageBox.Show(cmd.CommandText);
                        MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());
                    }
                    else
                    {
                        //alert class already exists
                        MessageBox.Show("Taka klasa juz istnieje!");
                    }
                }
                else
                {
                    //alert fill required fields
                    MessageBox.Show("Uzupelnij wszystkie wymagane pola (*) i upewnij sie że ich format jest poprawny!");
                }
            }
        }
        /// <summary>
        /// Function closes panel and refreshes data in data panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnECBack_Click(object sender, EventArgs e)
        {
            panelEditClasss.Enabled = false;
            panelEditClasss.Visible = false;
            reSearch();
            panelEditClasss.Controls.ClearControls();
        }
        #endregion

        /// <summary>
        /// Deletes class from db
        /// </summary>
        private void panelDeleteClass()
        {
            string delete = "";
            string msg = "";
            //ask for simultanious delete of students in class
            DialogResult dialogResult2 = MessageBox.Show("Czy usunąć także uczniów tej klasy?", "Wybierz opcje usunięcia.", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                //query to delete class and students
                delete = $"DELETE FROM Classes WHERE Id = '{id}'; DELETE FROM Kids WHERE class_id = '{id}'";
                //confirm message
                msg = "Potwierdź usunięcie klasy o ID = " + id.ToString() + " oraz jej uczniów.";
                
            }
            else if (dialogResult2 == DialogResult.No)
            {
                //query to delete class
                delete = "DELETE FROM Classes WHERE Id = '" + id.ToString() + "';";
                //confirm message
                msg = "Potwierdź usunięcie klasy o ID = " + id.ToString() + ".";
            }
            else {
                return;
            }

            //Ask for delete confirmation
            DialogResult dialogResult1 = MessageBox.Show( msg , "Wybierz opcje usunięcia.", MessageBoxButtons.YesNo);
            if (dialogResult1 == DialogResult.Yes)
            {                
                using (var con = new SqlConnection(connectionString))
                {
                    //run delete query
                    con.Open();
                    SqlCommand cmd = new SqlCommand(delete, con);
                    int p = cmd.ExecuteNonQuery();
                    MessageBox.Show("Pomyślnie usunięto klase " + p.ToString());
                    reSearch();
                }
            }
        }
       
        /// <summary>
        /// Promotes class to next year, if passes class 8 then gets archived
        /// </summary>
        private void panelPromoteClass()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {   
                //gather data about selected class for promotion
                var update = "";
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);                
                cmd.CommandText = $"SELECT * FROM Classes WHERE Id = '{id}'";                
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (int.Parse(dr["classN"].ToString()) < 8) {
                    var nextClass = int.Parse(dr["classN"].ToString()) + 1;
                    var nextYear = int.Parse(dr["year"].ToString()) + 1;
                    var nextClassL = dr["classL"].ToString();
                    dr.Close();
                    //check if there isnt any another class with the same properties
                    cmd.CommandText = $"SELECT * FROM Classes WHERE classN = '{nextClass}' AND classL = '{nextClassL}' AND year = '{nextYear}'";
                    if (cmd.ExecuteScalar() != null)
                    {
                        //alert class already exists
                        MessageBox.Show("Nie mozna awansowac tej klasy poniewaz istnieje klasa identyczna do awansowanej klasy.");
                        return;
                    }
                    //ask for class promotion confirmation
                    DialogResult dialogResult2 = MessageBox.Show($"Czy chcesz awansować klasę o ID = {id}?", "Potwierdź awans.", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        //update query if yes
                        update = $"UPDATE Classes SET classN = '{nextClass}', year = '{nextYear}' WHERE Id = '{id}';";                 
                    }
                    else
                    {                        
                        return;
                    }
                }
                else {
                    panelArchiveClass();
                    dr.Close();
                    return;
                }
                
                //run update
                cmd.CommandText = update;
                MessageBox.Show(update);
                MessageBox.Show(cmd.ExecuteNonQuery().ToString());
                reSearch();
            }
        }
        
        /// <summary>
        /// Archives class and students if selected
        /// </summary>
        private void panelArchiveClass()
        {            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //get data about selected class
                DialogResult dialogResult1 = DialogResult.No;
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandText = $"SELECT * FROM Classes WHERE Id = '{id}'";
                var update = "";
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                //check if class isnt archived
                if (dr["archive"].ToString() == "False")
                {
                    //ask to archive students as well
                    DialogResult dialogResult2 = MessageBox.Show("Czy zarchiwizować także uczniów tej klasy?", "Wybierz opcje archiwizacji.", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        //query and confirm message with students
                        update = $"UPDATE Classes SET archive = '1' WHERE Id = '{id}'; UPDATE Kids SET archive = '1' WHERE class_id = '{id}'";
                        dialogResult1 = MessageBox.Show($"Potwierdz archiwizacje klasy o ID = {id} oraz jej uczniów", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);
                        

                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        //query and confirm message
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
                    //ask tu un archive students of this class as well
                    DialogResult dialogResult2 = MessageBox.Show("Czy cofnąć także archiwizacje uczniów tej klasy?", "Wybierz opcje archiwizacji.", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        //query and confirm message with students
                        update = $"UPDATE Classes SET archive = '0' WHERE Id = '{id}'; UPDATE Kids SET archive = '0' WHERE class_id = '{id}'";
                        dialogResult1 = MessageBox.Show($"Potwierdz cofnięcie archiwizacji klasy o ID = {id} oraz jej uczniów", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);


                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        //query and confirm message
                        update = $"UPDATE Classes SET archive = '0' WHERE Id = '{id}';";
                        dialogResult1 = MessageBox.Show($"Potwierdz cofnięcie archiwizacji klasy o ID = {id}", "Potwierdź archiwizacje.", MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        return;
                    }
                }
                dr.Close();
                //run query in affermative
                if (dialogResult1 == DialogResult.Yes) {
                    cmd.CommandText = update;
                    MessageBox.Show(update);
                    MessageBox.Show(cmd.ExecuteNonQuery().ToString());
                    reSearch();
                }
            }
        }
        
        //not used
        private void comboArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reSearch();
        }
        
        /// <summary>
        /// Load combox values after form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        //event
        private void comboArchive_SelectedValueChanged(object sender, EventArgs e)
        {
            reSearch();
        }
    }
}
