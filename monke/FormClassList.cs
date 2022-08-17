using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monke
{
    public partial class FormClassList : Form
    {
        //string connecting DB
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";    
        //Variables for student info
        string classN, classL, year, idstudent, name, last_name, pesel, birth, gender, height, weight, bmi, pressure, eye, posture, posture_type, sees_colour, cover_test, light_reflect, archive;
        //User direcotry(UD) for file generation
        string userPath = "";
        //id of selected row
        int id;
        //table dataset
        DataSet ds = new DataSet();

        public FormClassList()
        {
            InitializeComponent();
            //Reset UD
            /*Properties.Settings.Default.UserPath = "";
            Properties.Settings.Default.Save();*/

            //assign empty string to avoid nulls            
            classN = classL = year = archive = idstudent = name = last_name = pesel = birth = gender = classN = classL = year = height = weight = bmi = pressure = eye = posture = posture_type = sees_colour = cover_test = light_reflect = archive = "";

            //read app property UD into variable
            userPath = Properties.Settings.Default.UserPath;
            //check if UD is set
            if (userPath == "")
            {
                //Display default path
                labelPath.Text = "Pliki zapisywane w katalogu na pulpicie";
            }
            else
            {
                //Display UD path
                labelPath.Text = userPath;
            }
        }

        /// <summary>
        /// Changes User Path variable where all files and backups are stored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePath_Click(object sender, EventArgs e)
        {
            //Opening file dialog
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                //Check if path has been selected
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //Overwrite User Path setting
                    Properties.Settings.Default.UserPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    userPath = fbd.SelectedPath;
                    //Display path to user
                    labelPath.Text = fbd.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Data display and search
        /// </summary>
        #region panelData

        /// <summary>
        /// Collects all data records from localDB and fills ds dataset
        /// </summary>
        private void loadDataGrid()
        {
            //SQL query
            var select = $"SELECT Id, CONCAT(classN, classL) AS klasa, CONCAT(year,'/',year+1) AS rocznik, archive FROM Classes;";
            //Open SQL connection
            using (var con = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(select, con);
                dataAdapter.Fill(ds);
                dataGridViewClasses.ReadOnly = true;
                dataGridViewClasses.DataSource = ds.Tables[0];
                dataGridViewClasses.Columns[1].HeaderText = "ID";
                dataGridViewClasses.Columns[2].HeaderText = "Klasa";
                dataGridViewClasses.Columns[3].HeaderText = "Rocznik";
                dataGridViewClasses.Columns[4].HeaderText = "Archiwum";
            }
        }
        
        /// <summary>
        /// Collects all data records compliant with search requirements and fills ds dataset
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
        #region events
        private void FormExaminationCard_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            reSearch();
        }
        private void dataGridViewClasses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    generateClassList();
                }
            }
        }
        #endregion
        #endregion

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        
        /// <summary>
        /// replaces all whitespaces from input string with a replacement string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }

        //Used to load comboBox values 
        private void FormClassList_Shown(object sender, EventArgs e)
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

        /// <summary>
        /// Generates a class list document for the selected class with student information
        /// </summary>
        private void generateClassList()
        {
            //SELECT query for all students info in selected class
            var select =
              "SELECT " +
              "k.Id, k.name, k.last_name, k.pesel, k.birth, k.gender, c.classN, c.classL, c.year, k.height, k.weight, k.bmi, k.pressure, k.eye, k.posture, k.posture_type, k.sees_colour, k.cover_test, k.light_reflect, k.archive " +
              "FROM " +
                  "Kids AS k " +
              "LEFT JOIN " +
                  "Classes AS c " +
              "ON (k.class_id = c.Id) WHERE c.Id = '" + id.ToString() + "';";

            //Create SQL DB connection
            using (var con = new SqlConnection(connectionString))
            {
                //open DB connection 
                con.Open();
                //create query
                SqlCommand cmd = new SqlCommand(select, con);     
                //execute query to see if class contains students
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Nie można wygenerowac pliku ponieważ klasa nie zawiera uczniów");
                    return;
                }
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                #region assign           
                classN = ReplaceWhitespace(dr["classN"].ToString(), "");
                classL = ReplaceWhitespace(dr["classL"].ToString(), "");
                year = ReplaceWhitespace(dr["year"].ToString(), "");               
                #endregion
                dr.Close();

                string templateFileName = "";
                string fileName = "";

                templateFileName = "listy_klasowe_arkusz_pracy.xlsx";
                fileName = "Lista klasowa";
                var yearInt = int.Parse(year);
                yearInt = yearInt - (int.Parse(classN) - 1);

                string templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", templateFileName);
                string newFileName = $"{ReplaceWhitespace(fileName, "_")}_kl_{classL}_({yearInt}_{yearInt+1}).xlsx";
                //check if use path has been set by user
                if (userPath == "")
                {
                    //assign default path to desktop
                    userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                //generate new file path
                string docPath = userPath + @"\Listy_klasowe\" + newFileName;
                
                //Create excelengine instance
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    //instantiate
                    IApplication application = excelEngine.Excel;

                    //Set excel version
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    //Open excel template
                    IWorkbook workbook = application.Workbooks.Open(templatePath);

                    //Open correct worksheet in doc
                    int row = 7;                    
                    int ws = int.Parse(classN) - 1;
                    IWorksheet worksheet = workbook.Worksheets[ws];

                    dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        #region assign                       
                        name = ReplaceWhitespace(dr["name"].ToString(), "");
                        last_name = ReplaceWhitespace(dr["last_name"].ToString(), "");
                        pesel = ReplaceWhitespace(dr["pesel"].ToString(), "");
                        gender = ReplaceWhitespace(dr["gender"].ToString(), "");
                        birth = ReplaceWhitespace(dr["birth"].ToString(), "");                       
                        height = ReplaceWhitespace(dr["height"].ToString(), "");
                        weight = ReplaceWhitespace(dr["weight"].ToString(), "");
                        bmi = ReplaceWhitespace(dr["bmi"].ToString(), "");
                        pressure = ReplaceWhitespace(dr["pressure"].ToString(), "");
                        eye = ReplaceWhitespace(dr["eye"].ToString(), "");
                        posture = ReplaceWhitespace(dr["posture"].ToString(), "");
                        posture_type = ReplaceWhitespace(dr["posture_type"].ToString(), "");
                        sees_colour = ReplaceWhitespace(dr["sees_colour"].ToString(), "");
                        cover_test = ReplaceWhitespace(dr["cover_test"].ToString(), "");
                        light_reflect = ReplaceWhitespace(dr["light_reflect"].ToString(), "");
                        archive = ReplaceWhitespace(dr["archive"].ToString(), "");                        
                        MessageBox.Show($"{idstudent} {name} {last_name} {pesel} {gender} {birth} {classN} {classL} {year} {height} {weight} {bmi} {pressure} {eye} {posture} {posture_type} {sees_colour} {cover_test} {light_reflect} {archive}");
                        #endregion
                        //Fill student info into cells
                        worksheet.Range["C" + row.ToString()].Text = last_name + " " + name;
                        worksheet.Range["D" + row.ToString()].Text = pesel;
                        worksheet.Range["E" + row.ToString()].Text = gender;
                        string pattern = "[0-1]?[0-9].[0-9]{2}.[0-9]{4}";
                        Match km = Regex.Match(birth, pattern);                        
                        worksheet.Range["F" + row.ToString()].Text = km.Value;                        
                        row++;
                    }
                    dr.Close();
                    
                    //Save excel doc to UD
                    workbook.SaveAs(docPath);
                    MessageBox.Show("Wygenerowano plik");
                }
            }
        }
    }
}
