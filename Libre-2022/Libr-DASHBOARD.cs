using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreEngine_Root;
using Libre_2022.LIBRE_ENG;
using Newtonsoft.Json;



namespace Libre_2022
{
    public partial class LibreDashboard : Form
    {
        LIBRE_ENG.DatabaseConnection dbConnection = new LIBRE_ENG.DatabaseConnection();
        public static string databaseName;
        public static string databasePath;

        public LibreDashboard()
        {
            InitializeComponent();
        }


        private void DashBoard_importLib_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnLibr = new OpenFileDialog();
            opnLibr.Filter = "Libr Database|*.lib *.db" +
                             "|Archives Files|*.zip;*.rar" +
                             "|JSON FIles|*.json" +
                             "|All Files|*.*";
            if (opnLibr.ShowDialog() == DialogResult.OK)
            {
                databasePath = opnLibr.FileName;
                databaseName = opnLibr.SafeFileName;
    
                dbConnection.SetNamePath(databasePath, databaseName);
                //  dbConenction.initializeLoad();
                //   MessageBox.Show(dbProperty.databasePath);
                MessageBox.Show(dbConnection._connectionString);
                dbConnection.initializeLoad();
                loadData();
          
            }
  
        }

        private void loadData()
        {
            try
            {
                if (dbConnection.dt.Rows.Count > 0)   
                {
                    for(int i = 0; i < dbConnection.dt.Rows.Count; i++)
                    {
                        DataRow dr = dbConnection.dt.Rows[i];
                        ListViewItem DatabaseEntry = new ListViewItem(dr["ID"].ToString());
                        DatabaseEntry.SubItems.Add(dr["Name"].ToString());
                        // DatabaseEntry.SubItems.Add(dr["Name"].ToString());
                        ResourceList.Items.Add(DatabaseEntry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            };
        }

        private void JSONTEST_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnJSON = new OpenFileDialog();
            opnJSON.Filter = "JSON| *.json";
            if (opnJSON.ShowDialog() == DialogResult.OK)
            {
                string TestNameLoc = opnJSON.FileName;
                string TestName;

                dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(opnJSON.FileName));
                MessageBox.Show($"The name of db is: { jsonFile["Compiler"]}");


            }
        }
    }
}
