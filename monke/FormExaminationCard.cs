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
using Xceed.Words.NET;

namespace monke
{
    public partial class FormExaminationCard : Form
    {
        //sql db connection
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        //current search field preferance 
        string field = "last_name";
        string idstudent, name, last_name, pesel, birth, gender, classN, classL, year, height, weight, bmi, pressure, eye, posture, posture_type, sees_colour, cover_test, light_reflect, archive;
        string userPath = "";

        /// <summary>
        /// Changes User Path directory to selected catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePath_Click(object sender, EventArgs e)
        {
            //opens folder dialog
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                //check if location is correctly selected
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //assign selected path
                    Properties.Settings.Default.UserPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    userPath = fbd.SelectedPath;
                    labelPath.Text = fbd.SelectedPath;
                }
            }
        }

        int id;
        DataSet ds = new DataSet();

        public FormExaminationCard()
        {
            InitializeComponent();
            //reset UD
            //Properties.Settings.Default.UserPath = "";
            //Properties.Settings.Default.Save();
            idstudent = name = last_name = pesel = birth = gender = classN = classL = year = height = weight = bmi = pressure = eye = posture = posture_type = sees_colour = cover_test = light_reflect = archive = "";
            //read user path from settings
            userPath = Properties.Settings.Default.UserPath;
            if (userPath == "")
            {
                labelPath.Text = "Pliki zapisywane w katalogu na pulpicie";
            }
            else {
                labelPath.Text = userPath;
            }
        }

        //Displays data in DataGrid widget, also is reliable for searching through data for specific keywords
        #region panelData
        private void FormExaminationCard_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        
        /// <summary>
        ///Collects data from db and fills ds dataset  
        /// </summary>
        private void loadDataGrid()
        {
            var select =
                "SELECT " +
                "k.Id, k.name, k.last_name, k.pesel, k.birth, k.gender, CONCAT(c.classN, c.classL, c.year, '/', c.year+1) AS class, k.height, k.weight, k.bmi, k.pressure, k.eye, k.posture, k.posture_type, k.sees_colour, k.cover_test, k.light_reflect, k.archive " +
                "FROM " +
                    "Kids AS k " +
                "LEFT JOIN " +
                    "Classes AS c " +
                "ON (k.class_id = c.Id);";
            using (var con = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(select, con);
                dataAdapter.Fill(ds);
                dataGridViewStudents.ReadOnly = true;
                dataGridViewStudents.DataSource = ds.Tables[0];
                dataGridViewStudents.Columns[1].HeaderText = "ID";
                dataGridViewStudents.Columns[2].HeaderText = "Imie";
                dataGridViewStudents.Columns[3].HeaderText = "Nazwisko";
                dataGridViewStudents.Columns[4].HeaderText = "PESEL";
                dataGridViewStudents.Columns[5].HeaderText = "Data urodzenia";
                dataGridViewStudents.Columns[6].HeaderText = "Płeć";
                dataGridViewStudents.Columns[7].HeaderText = "Klasa";
                dataGridViewStudents.Columns[8].HeaderText = "Wysokość";
                dataGridViewStudents.Columns[9].HeaderText = "Waga";
                dataGridViewStudents.Columns[10].HeaderText = "BMI";
                dataGridViewStudents.Columns[11].HeaderText = "Ostatnie ciśnienie";
                dataGridViewStudents.Columns[12].HeaderText = "Wzrok";
                dataGridViewStudents.Columns[13].HeaderText = "Postawa";
                dataGridViewStudents.Columns[14].HeaderText = "Rodzaj postawy";
                dataGridViewStudents.Columns[15].HeaderText = "Widzenie barw";
                dataGridViewStudents.Columns[16].HeaderText = "Cover test";
                dataGridViewStudents.Columns[17].HeaderText = "Odbicie światła w rogówkach";
                dataGridViewStudents.Columns[18].HeaderText = "Archiwum";
            }
        }
        
        /// <summary>
        /// CAll generate function and assigns correct id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {                
                if (e.ColumnIndex == 0)
                {                   
                    id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    generateExaminationCard();
                }               
            }
        }
       
        /// <summary>
        /// Collects data records from db that meet search requirements
        /// </summary>
        private void reSearch()
        {
            DataRowView drv = (DataRowView)comboArchive.SelectedItem;
            string fkof = drv["value"].ToString();

            var select =
                "SELECT " +
                    "k.Id, k.name, k.last_name, k.pesel, k.birth, k.gender,  CONCAT(c.classN, c.classL, c.year , '/', c.year+1) AS class, k.height, k.weight, k.bmi, k.pressure, k.eye, k.posture, k.posture_type, k.sees_colour, k.cover_test, k.light_reflect, k.archive " +
                "FROM " +
                    "Kids AS k " +
                "LEFT JOIN " +
                    "Classes AS c " +
                "ON (k.class_id = c.Id) " +
                    $"WHERE {fkof} AND k." + field + " LIKE '" + tbxSearch.Text + "%'";
            using (var con = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter(select, con);
                ds.Clear();
                dataAdapter.Fill(ds);
            }
        }
        
        #region events
        private void checkBoxNazwisko_MouseUp(object sender, MouseEventArgs e)
        {
            checkBoxNazwisko.Checked = true;
            field = "last_name";
            checkBoxImie.Checked = false;
            checkBoxPESEL.Checked = false;
            reSearch();
        }
        private void checkBoxImie_MouseUp(object sender, MouseEventArgs e)
        {
            checkBoxImie.Checked = true;
            field = "name";
            checkBoxNazwisko.Checked = false;
            checkBoxPESEL.Checked = false;
            reSearch();
        }
        private void checkBoxPESEL_MouseUp(object sender, MouseEventArgs e)
        {
            checkBoxPESEL.Checked = true;
            field = "pesel";
            checkBoxNazwisko.Checked = false;
            checkBoxImie.Checked = false;
            reSearch();
        }
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            reSearch();
        }
        #endregion
        #endregion

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        
        /// <summary>
        /// Replaces whitespaces from inpput string with replacement string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
        //event
        private void comboArchive_SelectedValueChanged(object sender, EventArgs e)
        {
            reSearch();
        }
        //event after form load, fills combobox values
        private void FormExaminationCard_Shown(object sender, EventArgs e)
        {
            DataTable dtArchive = new DataTable();
            dtArchive.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
            dtArchive.Rows.Add("k.archive = '0'", "Bez zarchiwizowanych");
            dtArchive.Rows.Add("k.archive = '1'", "Tylko zarchiwizowane");
            dtArchive.Rows.Add("k.archive = '0' OR k.archive = '1'", "Wszystkie");
            comboArchive.DataSource = dtArchive;
            comboArchive.DisplayMember = "name";
            comboArchive.ValueMember = "value";
            comboArchive.SelectedValue = "k.archive = '0'";
        }
        /// <summary>
        /// Generates Examination card based on a template file for a chosen student
        /// </summary>
        private void generateExaminationCard() {   
            //collect all student data
            var select =
              "SELECT " +
              "k.Id, k.name, k.last_name, k.pesel, k.birth, k.gender, c.classN, c.classL, c.year, k.height, k.weight, k.bmi, k.pressure, k.eye, k.posture, k.posture_type, k.sees_colour, k.cover_test, k.light_reflect, k.archive " +
              "FROM " +
                  "Kids AS k " +
              "LEFT JOIN " +
                  "Classes AS c " +
              "ON (k.class_id = c.Id) WHERE k.Id = '" + id.ToString() + "';";
            using (var con = new SqlConnection(connectionString))
            {
                //run query and collect data
                con.Open();
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                #region assign
                idstudent = ReplaceWhitespace(dr["id"].ToString(), "");
                name = ReplaceWhitespace(dr["name"].ToString(), "");
                last_name = ReplaceWhitespace(dr["last_name"].ToString(), "");
                pesel = ReplaceWhitespace(dr["pesel"].ToString(), "");
                gender = ReplaceWhitespace(dr["gender"].ToString(), "");
                birth = ReplaceWhitespace(dr["birth"].ToString(), "");
                classN = ReplaceWhitespace(dr["classN"].ToString(), "");
                classL = ReplaceWhitespace(dr["classL"].ToString(), "");
                year = ReplaceWhitespace(dr["year"].ToString(), "");
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
                #endregion
                //MessageBox.Show($"{idstudent} {name} {last_name} {pesel} {gender} {birth} {classN} {classL} {year} {height} {weight} {bmi} {pressure} {eye} {posture} {posture_type} {sees_colour} {cover_test} {light_reflect} {archive}");
                dr.Close();

                //Use new FormDialog to get template filename from user
                string templateFileName = "";
                string fileName = "";
                using (FormDialog formD = new FormDialog()) {
                    if (formD.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        if (formD.selectedDoc != "")
                        {
                            //assign file names 
                            templateFileName = formD.selectedDoc;
                            fileName = formD.selectedDocName;

                            //generate paths and file names
                            string templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", templateFileName);
                            string newFileName = $"{last_name}_{name}_kl_{classN}{classL}_{ReplaceWhitespace(fileName, "_")}.docx";
                            if (userPath == "") {
                                userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                            }
                            string docPath = MakeUnique(userPath + @"\Karty_Badan\" + newFileName);
                            //generate new docx file
                            DocX obj = DocX.Create(docPath);
                            obj.ApplyTemplate(templatePath);
                            #region replace
                            obj.ReplaceText("<name>", name);
                            obj.ReplaceText("<last_name>", last_name);
                            obj.ReplaceText("<gender>", gender);
                            string pattern = "[0-1]?[0-9].[0-9]{2}.[0-9]{4}";
                            Match km = Regex.Match(birth, pattern);
                            obj.ReplaceText("<birth>", km.Value);
                            obj.ReplaceText("<pesel>", pesel);
                            obj.ReplaceText("<height>", height);
                            obj.ReplaceText("<weight>", weight);
                            obj.ReplaceText("<bmi>", bmi);
                            obj.ReplaceText("<cover_test>", cover_test);
                            obj.ReplaceText("<light_reflect>", light_reflect);
                            obj.ReplaceText("<posture>", posture);
                            obj.ReplaceText("<posture_type>", posture_type);
                            obj.ReplaceText("<pressure>", pressure);
                            DateTime dataBadania = DateTime.Now.Date;
                            obj.ReplaceText("<date>", dataBadania.ToString("dd/MM/yyyy"));
                            #endregion
                            obj.Save();
                            MessageBox.Show("Wygenerowano plik");
                        }
                        else{
                            //file not chosen alert
                            MessageBox.Show("Wybierz plik");
                            return;
                        }
                    }
                }
                MessageBox.Show(templateFileName);      
            }
        }
        
        /// <summary>
        /// Makes unique file path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string MakeUnique(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);
            if (!Directory.Exists(dir))
            {
                DirectoryInfo di = Directory.CreateDirectory(dir);
                MessageBox.Show(di.ToString());
            }

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path)) {
                    return path;
                }

                path = Path.Combine(dir, fileName + "_" + i.ToString() + fileExt);
            }
        }
    }
}
