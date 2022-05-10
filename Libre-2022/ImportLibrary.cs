using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Libre_2022
{
    public partial class ImportLibrary : Form
    {
        LIBRE_ENG.DatabaseConnection dbConnection = new LIBRE_ENG.DatabaseConnection();
        public static string databaseName;
        public static string databasePath;
        public ImportLibrary()
        {
            InitializeComponent();
        }

        private void ImportLibrary_Load(object sender, EventArgs e)
        {

        }

        private void btn_ImportLibrary_Click(object sender, EventArgs e)
        {
            Libre_Navigator dashboard = new Libre_Navigator();
            dashboard.Show();
            this.Hide();
        }
    }
}