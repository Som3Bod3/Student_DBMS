using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monke
{
    public partial class FormStudents : Form
    {
        //ograniczenie pol tekstowych co do znakow(optional)
        //oddzielne sprawdzenie poprawnosci PESEL
        //zrobienie archiwizacji (dodanie kolumny bool) (mozliwosc wyswietlenia uczniow zarchiwizowanych nie lub all) (automatycznie archiwizuje albo nie)
        
        //mozliwosc awansu calej klasy do nowej
        //mozliwosc archiwizacji calej klasy
        //zrobienie awansowania pojedynczych uczniow do kolejnych klas
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        string field = "last_name";
        int id;
        DataSet ds = new DataSet();

        public FormStudents()
        {
            InitializeComponent();                
        }

        //Displays data in DataGrid widget, also is reliable for searching through data for specific keywords
        #region panelData
        private void FormStudents_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }
        private void loadDataGrid() {
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
                dataGridViewStudents.Columns[4].HeaderText = "ID";
                dataGridViewStudents.Columns[5].HeaderText = "Imie";
                dataGridViewStudents.Columns[6].HeaderText = "Nazwisko";
                dataGridViewStudents.Columns[7].HeaderText = "PESEL";
                dataGridViewStudents.Columns[8].HeaderText = "Data urodzenia";
                dataGridViewStudents.Columns[9].HeaderText = "Płeć";
                dataGridViewStudents.Columns[10].HeaderText = "Klasa";
                dataGridViewStudents.Columns[11].HeaderText = "Wysokość";
                dataGridViewStudents.Columns[12].HeaderText = "Waga";
                dataGridViewStudents.Columns[13].HeaderText = "BMI";
                dataGridViewStudents.Columns[14].HeaderText = "Ostatnie ciśnienie";
                dataGridViewStudents.Columns[15].HeaderText = "Wzrok";
                dataGridViewStudents.Columns[16].HeaderText = "Postawa";
                dataGridViewStudents.Columns[17].HeaderText = "Rodzaj postawy";
                dataGridViewStudents.Columns[18].HeaderText = "Widzenie barw";
                dataGridViewStudents.Columns[19].HeaderText = "Cover test";
                dataGridViewStudents.Columns[20].HeaderText = "Odbicie światła w rogówkach";
                dataGridViewStudents.Columns[21].HeaderText = "Archiwum";
            }
        }
        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    id = int.Parse(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                    panelEditStudentOpen(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else if (e.ColumnIndex == 3)
                {
                    deleteStudentById(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else if (e.ColumnIndex == 1) {
                    MessageBox.Show("Awans");
                }
                else if (e.ColumnIndex == 2) {
                    MessageBox.Show("Arch");
                }
            }
        }
        private void reSearch()
        {
            var select =
                "SELECT " +
                    "k.Id, k.name, k.last_name, k.pesel, k.birth, k.gender,  CONCAT(c.classN, c.classL, c.year , '/', c.year+1) AS class, k.height, k.weight, k.bmi, k.pressure, k.eye, k.posture, k.posture_type, k.sees_colour, k.cover_test, k.light_reflect, k.archive " +
                "FROM " +
                    "Kids AS k " +
                "LEFT JOIN " +
                    "Classes AS c " +
                "ON (k.class_id = c.Id) " +
                    "WHERE k." + field + " LIKE '" + tbxSearch.Text + "%'";
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

        //Displays a form and is responsible for succesfully adding a student to DB
        #region panelAddStudent
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            panelAddStudent.Enabled = true;
            panelAddStudent.Visible = true;
            populateComboBoxes(false);           
        }
        private void btnASBack_Click(object sender, EventArgs e)
        {
            panelAddStudent.Enabled = false;
            panelAddStudent.Visible = false;
            reSearch();
            panelAddStudent.Controls.ClearControls();
        }
        private void btnConfirmAddStudent_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (inputName.Text != "" && inputLastName.Text != "" && inputPESEL.Text != "" && inputGender.SelectedValue.ToString() != "" && inputPESEL.Text.Length == 11)
                {
                    string[][] input = new string[][]
                    {
                        new string[]{ "'" + inputName.Text+"',", "name," },
                        new string[]{ "'" + inputLastName.Text + "',", "last_name," },
                        new string[]{ "'" + inputPESEL.Text + "',", "pesel," },                        
                        new string[]{ "'" + inputGender.SelectedValue.ToString() + "'", "gender" }, //4-3
                        new string[]{ ",'" + inputBirth.Text + "'", ",birth" }, //gender 3-4
                        new string[]{ ",'" + inputClassB.SelectedValue.ToString() + "'", ",class_id" },
                        new string[]{ ",'" + inputHeight.Text + "'", ",height" },
                        new string[]{ ",'" + inputWeight.Text + "'", ",weight" },
                        new string[]{ ",'" + inputBMI.Text + "'", ",bmi" },
                        new string[]{ ",'" + inputPressure.Text + "'", ",pressure" },
                        new string[]{ ",'" + inputEye.SelectedValue.ToString() + "'", ",eye" },
                        new string[]{ ",'" + inputPosture.SelectedValue.ToString() + "'", ",posture" },
                        new string[]{ ",'" + inputPostureType.SelectedValue.ToString() + "'", ",posture_type" },
                        new string[]{ ",'" + inputSeesColour.SelectedValue.ToString() + "'", ",sees_colour" },
                        new string[]{ ",'" + inputCoverTest.SelectedValue.ToString() + "'", ",cover_test" },
                        new string[]{ ",'" + inputLightReflect.SelectedValue.ToString() + "'", ",light_reflect" }
                    };

                    
                    for (int i = 0; i < 16; i++) {
                        if (input[i][0] == "''," || input[i][0] == ",''")
                        {
                            input[i][0] = "";
                            input[i][1] = "";
                        }
                    }

                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = $"INSERT INTO kids({input[0][1]}{input[1][1]}{input[2][1]}{input[3][1]}{input[4][1]}{input[5][1]}{input[6][1]}{input[7][1]}{input[8][1]}{input[9][1]}{input[10][1]}{input[11][1]}{input[12][1]}{input[13][1]}{input[14][1]}{input[15][1]}) VALUES({input[0][0]}{input[1][0]}{input[2][0]}{input[3][0]}{input[4][0]}{input[5][0]}{input[6][0]}{input[7][0]}{input[8][0]}{input[9][0]}{input[10][0]}{input[11][0]}{input[12][0]}{input[13][0]}{input[14][0]}{input[15][0]});";
                    
                    
                    MessageBox.Show(cmd.CommandText);
                    MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());                    
                }
                else {
                    MessageBox.Show("uzupelnij wszystkie wymagane * pola");                    
                }
               
            }
        }
        private void inputPosture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inputPosture.SelectedValue.ToString() == "N")
            {
                inputPostureType.Visible = true;
            }
            else
            {
                inputPostureType.Visible = false;
            }
        }
        private void populateComboBoxes(bool edit) {
            if (edit)
            {
                inputBirthE.CustomFormat = "yyyy-MM-dd";
                inputBirthE.Format = DateTimePickerFormat.Custom;

                DataTable dtGender = new DataTable();
                dtGender.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtGender.Rows.Add("", "-wybierz-");
                dtGender.Rows.Add("K", "Kobieta(K)");
                dtGender.Rows.Add("M", "Mężczyzna(M)");
                inputGenderE.DataSource = dtGender;
                inputGenderE.DisplayMember = "name";
                inputGenderE.ValueMember = "value";

                DataTable dtEye = new DataTable();
                dtEye.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtEye.Rows.Add("", "-wybierz-");
                dtEye.Rows.Add("P", "Poprawny(P)");
                dtEye.Rows.Add("N", "Niepoprawny(N)");
                inputEyeE.DataSource = dtEye;
                inputEyeE.DisplayMember = "name";
                inputEyeE.ValueMember = "value";

                DataTable dtPosture = new DataTable();
                dtPosture.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtPosture.Rows.Add("", "-wybierz-");
                dtPosture.Rows.Add("P", "Poprawny(P)");
                dtPosture.Rows.Add("N", "Niepoprawny(N)");
                inputPostureE.DataSource = dtPosture;
                inputPostureE.DisplayMember = "name";
                inputPostureE.ValueMember = "value";

                DataTable dtPostureType = new DataTable();
                dtPostureType.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtPostureType.Rows.Add("", "-wybierz-");
                dtPostureType.Rows.Add("S", "Skolioza(S)");
                dtPostureType.Rows.Add("PL", "Plaskostopie(PŁ)");
                dtPostureType.Rows.Add("KK", "Koślawe kolana(KK)");
                dtPostureType.Rows.Add("KP", "Kifoza piersiowa(KF)");
                inputPostureTypeE.DataSource = dtPostureType;
                inputPostureTypeE.DisplayMember = "name";
                inputPostureTypeE.ValueMember = "value";                

                DataTable dtSC = new DataTable();
                dtSC.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtSC.Rows.Add("", "-wybierz-");
                dtSC.Rows.Add("P", "Poprawny(P)");
                dtSC.Rows.Add("N", "Niepoprawny(N)");
                inputSeesColourE.DataSource = dtSC;
                inputSeesColourE.DisplayMember = "name";
                inputSeesColourE.ValueMember = "value";

                DataTable dtCT = new DataTable();
                dtCT.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtCT.Rows.Add("", "-wybierz-");
                dtCT.Rows.Add("P", "Poprawny(P)");
                dtCT.Rows.Add("N", "Niepoprawny(N)");
                inputCoverTestE.DataSource = dtCT;
                inputCoverTestE.DisplayMember = "name";
                inputCoverTestE.ValueMember = "value";

                DataTable dtLR = new DataTable();
                dtLR.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtLR.Rows.Add("", "-wybierz-");
                dtLR.Rows.Add("P", "Poprawny(P)");
                dtLR.Rows.Add("N", "Niepoprawny(N)");
                inputLightReflectE.DataSource = dtLR;
                inputLightReflectE.DisplayMember = "name";
                inputLightReflectE.ValueMember = "value";

                DataTable dtClass = new DataTable();
                dtClass.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtClass.Rows.Add("", "-wybierz-");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Classes;", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var year = int.Parse(dr["year"].ToString());
                        dtClass.Rows.Add(dr["Id"].ToString(), dr["classN"].ToString() + dr["classL"].ToString() + " " + year.ToString() + "/" + (year + 1).ToString());
                    }
                    dr.Close();
                }
                inputClassBE.DataSource = dtClass;
                inputClassBE.DisplayMember = "name";
                inputClassBE.ValueMember = "value";

            }
            else 
            {
                DataTable dtClass = new DataTable();
                dtClass.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtClass.Rows.Add("", "-wybierz-");
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Classes;",con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        var year = int.Parse(dr["year"].ToString());
                        dtClass.Rows.Add(dr["Id"].ToString(), dr["classN"].ToString() + dr["classL"].ToString() + " " + year.ToString() + "/" + (year+1).ToString());
                    }
                    dr.Close();
                }
                inputClassB.DataSource = dtClass;
                inputClassB.DisplayMember = "name";
                inputClassB.ValueMember = "value";

                inputBirth.CustomFormat = "yyyy-MM-dd";
                inputBirth.Format = DateTimePickerFormat.Custom;

                DataTable dtGender = new DataTable();
                dtGender.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtGender.Rows.Add("", "-wybierz-");
                dtGender.Rows.Add("K", "Kobieta(K)");
                dtGender.Rows.Add("M", "Mężczyzna(M)");
                inputGender.DataSource = dtGender;
                inputGender.DisplayMember = "name";
                inputGender.ValueMember = "value";

                DataTable dtEye = new DataTable();
                dtEye.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtEye.Rows.Add("", "-wybierz-");
                dtEye.Rows.Add("P", "Poprawny(P)");
                dtEye.Rows.Add("N", "Niepoprawny(N)");
                inputEye.DataSource = dtEye;
                inputEye.DisplayMember = "name";
                inputEye.ValueMember = "value";

                DataTable dtPosture = new DataTable();
                dtPosture.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtPosture.Rows.Add("", "-wybierz-");
                dtPosture.Rows.Add("P", "Poprawny(P)");
                dtPosture.Rows.Add("N", "Niepoprawny(N)");
                inputPosture.DataSource = dtPosture;
                inputPosture.DisplayMember = "name";
                inputPosture.ValueMember = "value";

                DataTable dtPostureType = new DataTable();
                dtPostureType.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtPostureType.Rows.Add("", "-wybierz-");
                dtPostureType.Rows.Add("S", "Skolioza(S)");
                dtPostureType.Rows.Add("PL", "Plaskostopie(PŁ)");
                dtPostureType.Rows.Add("KK", "Koślawe kolana(KK)");
                dtPostureType.Rows.Add("KK", "Kifoza piersiowa(KF)");
                inputPostureType.DataSource = dtPostureType;
                inputPostureType.DisplayMember = "name";
                inputPostureType.ValueMember = "value";
                inputPostureType.Visible = false;

                DataTable dtSC = new DataTable();
                dtSC.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtSC.Rows.Add("", "-wybierz-");
                dtSC.Rows.Add("P", "Poprawny(P)");
                dtSC.Rows.Add("N", "Niepoprawny(N)");
                inputSeesColour.DataSource = dtSC;
                inputSeesColour.DisplayMember = "name";
                inputSeesColour.ValueMember = "value";

                DataTable dtCT = new DataTable();
                dtCT.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtCT.Rows.Add("", "-wybierz-");
                dtCT.Rows.Add("P", "Poprawny(P)");
                dtCT.Rows.Add("N", "Niepoprawny(N)");
                inputCoverTest.DataSource = dtCT;
                inputCoverTest.DisplayMember = "name";
                inputCoverTest.ValueMember = "value";

                DataTable dtLR = new DataTable();
                dtLR.Columns.AddRange(new DataColumn[] { new DataColumn("value", typeof(string)), new DataColumn("name", typeof(string)) });
                dtLR.Rows.Add("", "-wybierz-");
                dtLR.Rows.Add("P", "Poprawny(P)");
                dtLR.Rows.Add("N", "Niepoprawny(N)");
                inputLightReflect.DataSource = dtLR;
                inputLightReflect.DisplayMember = "name";
                inputLightReflect.ValueMember = "value";
            }            
        }
        private void inputBirth_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(inputBirth.Value.Date.ToString());
        }
        private void inputHeight_TextChanged(object sender, EventArgs e)
        {
            calculateBMI();
        }
        private void inputWeight_TextChanged(object sender, EventArgs e)
        {
            calculateBMI();
        }
        private void calculateBMI()
        {
            if (inputHeight.Text != "" && inputWeight.Text != "")
            {
                inputBMI.Text = string.Format("{0:N2}", double.Parse(inputWeight.Text) / Math.Pow(double.Parse(inputHeight.Text) / 100, 2.0D));
                string old = inputBMI.Text;
                string neww = old.Replace(',', '.');
                inputBMI.Text = neww;
            }
        }
        #endregion

        private void deleteStudentById(string id) {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz trwale usunąć ucznia o ID = " + id + "?", "Potwierdź usunięcie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                var delete = "DELETE FROM kids WHERE Id = '" + int.Parse(id) + "';";
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(delete, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pomyślnie usunięto ucznia");
                    reSearch();
                }
            }
        }

        #region editStudent
        private void panelEditStudentOpen(string id)
        {
            panelEditStudent.Enabled = true;
            panelEditStudent.Visible = true;
            populateComboBoxes(true);
            fillStudentInfo(id);
            calculateBMIE();
        }       
        private void btnESBack_Click(object sender, EventArgs e)
        {
            panelEditStudent.Enabled = false;
            panelEditStudent.Visible = false;
            reSearch();
            panelEditStudent.Controls.ClearControls();
        }
        private void btnConfirmEditStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (inputNameE.Text != "" && inputLastNameE.Text != "" && inputPESELE.Text != "" && inputGenderE.SelectedValue.ToString() != "" && inputPESELE.Text.Length == 11)
                {
                    string[] input = 
                    {
                        "name = '" + inputNameE.Text + "',",
                        "last_name = '" + inputLastNameE.Text + "',",
                        "pesel = '" + inputPESELE.Text + "',",
                        "gender = '"  + inputGenderE.SelectedValue.ToString() + "'",
                        ", birth = '"  + inputBirthE.Text + "'",
                        ", class_id = '"  + inputClassBE.SelectedValue.ToString() + "'",
                        ", height = '" + inputHeightE.Text + "'",
                        ", weight = '" + inputWeightE.Text + "'",
                        ", bmi = '" + inputBMIE.Text + "'",
                        ", pressure = '" + inputPressureE.Text + "'",
                        ", eye = '" + inputEyeE.SelectedValue.ToString() + "'",
                        ", posture = '" + inputPostureE.SelectedValue.ToString() + "'",
                        ", posture_type = '" + inputPostureTypeE.SelectedValue.ToString() + "'",
                        ", sees_colour = '" + inputSeesColourE.SelectedValue.ToString() + "'",
                        ", cover_test = '" + inputCoverTestE.SelectedValue.ToString() + "'",
                        ", light_reflect = '" + inputLightReflectE.SelectedValue.ToString() + "'"
                    };

                    
                    for (int i = 0; i < 16; i++)
                    {
                        if (Regex.IsMatch(input[i], @"[a-zA-Z_]+\s=\s'',") || Regex.IsMatch(input[i], @",\s[a-zA-Z_]+\s=\s''") || Regex.IsMatch(input[i], @"[a-zA-Z_]+\s=\s''"))
                        {
                            input[i] = "";
                        }
                    }

                    con.Open();
                    SqlCommand cmd = new SqlCommand("", con);
                    cmd.CommandText = $"UPDATE kids SET {input[0]}{input[1]}{input[2]}{input[3]}{input[4]}{input[5]}{input[6]}{input[7]}{input[8]}{input[9]}{input[10]}{input[11]}{input[12]}{input[13]}{input[14]}{input[15]} WHERE Id = '{id}';";

                    MessageBox.Show(cmd.CommandText);
                    MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());
                }
                else
                {
                    MessageBox.Show("uzupelnij wszystkie wymagane * pola");
                }
            }
        }
        private void fillStudentInfo(string id) {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
              

                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM kids WHERE Id = '{id}';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                inputNameE.Text = dr["name"].ToString();
                inputLastNameE.Text = dr["last_name"].ToString();
                inputPESELE.Text = dr["pesel"].ToString();
                inputGenderE.SelectedValue = dr["gender"].ToString();
                inputBirthE.Text = dr["birth"].ToString();
                inputClassBE.SelectedValue = dr["class_id"].ToString();
                inputHeightE.Text = dr["height"].ToString();
                inputWeightE.Text = dr["weight"].ToString();
                inputBMIE.Text = dr["bmi"].ToString();
                inputPressureE.Text = dr["pressure"].ToString();
                inputEyeE.SelectedValue = dr["eye"].ToString();
                inputPostureE.SelectedValue = dr["posture"].ToString();
                inputPostureTypeE.SelectedValue = dr["posture_type"].ToString();
                inputSeesColourE.SelectedValue = dr["sees_colour"].ToString();
                inputCoverTestE.SelectedValue = dr["cover_test"].ToString();
                inputLightReflectE.SelectedValue = dr["light_reflect"].ToString();

                MessageBox.Show(cmd.CommandText);
                dr.Close();
               
            }
        }
        private void calculateBMIE()
        {
            if (inputHeightE.Text != "" && inputWeightE.Text != "")
            {
                inputBMIE.Text = string.Format("{0:N2}", double.Parse(inputWeightE.Text) / Math.Pow(double.Parse(inputHeightE.Text) / 100, 2.0D));
                string old = inputBMIE.Text;
                string neww = old.Replace(',', '.');
                inputBMIE.Text = neww;
            }
        }
        private void inputHeightE_TextChanged(object sender, EventArgs e)
        {
            calculateBMIE();
        }
        private void inputWeightE_TextChanged(object sender, EventArgs e)
        {
            calculateBMIE();
        }
        #endregion
    }

    public static class extenstions
    {
        private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() {
            {typeof(TextBox), c => ((TextBox)c).Clear()},
            {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
            {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
            {typeof(Panel), c => ((Panel)c).Controls.ClearControls()}
    };

        private static void FindAndInvoke(Type type, Control control)
        {
            if (controldefaults.ContainsKey(type))
            {
                controldefaults[type].Invoke(control);
            }
        }

        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                FindAndInvoke(control.GetType(), control);
            }
        }

        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
        {
            if (!controldefaults.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control.GetType().Equals(typeof(T)))
                {
                    FindAndInvoke(typeof(T), control);
                }
            }

        }

    }

}

