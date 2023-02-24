using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monke
{
    public partial class FormHelp : Form
    {
        //string connecting DB
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        //User direcotry(UD) for file generation
        string userPath = "";


        public FormHelp()
        {
            //Reset UD
            //Properties.Settings.Default.UserPath = "";
            //Properties.Settings.Default.Save();

            InitializeComponent();
            //read app property UD into variable
            userPath = Properties.Settings.Default.UserPath;
            if (userPath == "")
            {
                userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Button event that creates a backup of localDB to user path directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCopy_Click(object sender, EventArgs e)
        {
            //generate a unique backup file name
            string fileBackupPath = MakeUnique(userPath + @"\Kopie_zapasowe\kopia_zapasowa.bak");

            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                //open connection and get database name
                connection.Open();
                string db = connection.Database.ToString();
                //MessageBox.Show(db);
                //backup query of localDB to userpath
                var query = String.Format(@"BACKUP DATABASE [{0}] TO DISK='{1}'",
                    db, fileBackupPath);

                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kopia zostala utworzona!");
                }
            }
        }

        /// <summary>
        /// Button event that restores localDB from a copy selected by user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreCopy_Click(object sender, EventArgs e)        
        {
            //open file dialog to choose backup
            using (var ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                //check if file was chosen correctly
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    string db = "";
                    string fileRestorePath = ofd.FileName;
                    //MessageBox.Show(fileRestorePath);

                    //get database name
                    var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);
                    using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                    {
                        connection.Open();
                        db = connection.Database.ToString();
                        MessageBox.Show(db);
                    }

                    //generate master connection string
                    string master_ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=Master;Integrated Security=True";

                    using (SqlConnection restoreConn = new SqlConnection())
                    {
                        //open connection to master
                        restoreConn.ConnectionString = master_ConnectionString;
                        restoreConn.Open();

                        using (SqlCommand restoredb_executioncomm = new SqlCommand())
                        {
                            restoredb_executioncomm.Connection = restoreConn;

                            //disconnect other connections to database
                            restoredb_executioncomm.CommandText = String.Format(@"ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", db);
                            restoredb_executioncomm.ExecuteNonQuery();

                            //restore database
                            restoredb_executioncomm.CommandText = String.Format(@"RESTORE DATABASE [{0}] FROM DISK='{1}'", db, fileRestorePath);                            
                            restoredb_executioncomm.ExecuteNonQuery();

                            //allow other connections to be made again
                            restoredb_executioncomm.CommandText = String.Format(@"ALTER DATABASE [{0}] SET MULTI_USER WITH ROLLBACK IMMEDIATE", db);
                            restoredb_executioncomm.ExecuteNonQuery();

                            MessageBox.Show("Baza danych zostala odtworzona!");
                        }
                        restoreConn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Function to make sure file has a unique path
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
                //MessageBox.Show(di.ToString());
            }

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                {
                    return path;
                }

                path = Path.Combine(dir, fileName + "_" + i.ToString() + fileExt);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Utwórz kopię zapasową bazy danych by zapobiec utracie danych. \n" +
                "Kopia zostanie zapisana w katalogu kopie zapasowe na pulpicie lub w wybranym miejscu. \n" +
                "W razie konieczności odtworzenia kopi zapasowej, wybierz jeden z zapisanych plików.bak. \n" +
                "Odtworzenie może potrwać kilka sekund.", label1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
