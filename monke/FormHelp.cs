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
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO kids ( name, last_name, pesel, gender) VALUES ('Ahmed', 'Chazbijewicz', '123456789', 'male'),('Ahmedzik', 'Chazbijewiczus', '223456789', 'male');", con);
            //MessageBox.Show("Rows affected: " + cmd.ExecuteNonQuery().ToString());

            cmd.CommandText = "SELECT * FROM kids";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show(reader.GetValue(reader.GetOrdinal("last_name")).ToString());
            }
            reader.Close();
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {

        }
    }
}
