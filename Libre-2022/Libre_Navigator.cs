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
    public partial class Libre_Navigator : Form
    {
        LIBRE_ENG.DatabaseConnection dbConnection = new LIBRE_ENG.DatabaseConnection();
     
        LIBRE_ENG.OpenResource opnResource = new LIBRE_ENG.OpenResource();  
        public  string databaseName;
        public  string databasePath;

        public Libre_Navigator()
        {
            InitializeComponent();
        }

        public static string ResourceDisplayName { get; set; }
        public static void SetResourceDisplayName(string _ResourceDisplayName)
        {
            ResourceDisplayName = _ResourceDisplayName;
        }

        private void DashBoard_importLib_Click(object sender, EventArgs e)
        {

            ResourceList.Items.Clear();
            OpenFileDialog opnLibr = new OpenFileDialog();
            opnLibr.Filter = "JSON| *.json";
            if (opnLibr.ShowDialog() == DialogResult.OK)
            {
                string TestNameLoc = opnLibr.FileName;
                string Directory = Path.GetDirectoryName(opnLibr.FileName);
                LIBRE_ENG.DatabaseProperties.Methods.ReadData(TestNameLoc, Directory);
                dbConnection.SetNamePath();
               // MessageBox.Show(dbConnection._connectionString);
                dbConnection.initializeLoad();
                dashboard_placeHolder.Text = ResourceDisplayName;
                loadData();

            }


        }

        private void loadData()
        {
         
            try
            {
                if (dbConnection.dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dbConnection.dt.Rows.Count; i++)
                    {
                        DataRow dr = dbConnection.dt.Rows[i];
                        ListViewItem DatabaseEntry = new ListViewItem(dr[LIBRE_ENG.DatabaseProperties.DatabaseTableInformation.tblclmn_ResourceID].ToString());
                        // FIX THIS, PLEASE INPUT A VARIABLE DATA FOR THE TABLE TO ADJUST
                        DatabaseEntry.SubItems.Add(dr[LIBRE_ENG.DatabaseProperties.DatabaseTableInformation.tblclmn_ResourceName].ToString());
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
                string Directory = Path.GetDirectoryName(opnJSON.FileName);
                //MessageBox.Show(Directory);
                LIBRE_ENG.DatabaseProperties.Methods.ReadData(TestNameLoc, Directory);

                MessageBox.Show(LIBRE_ENG.DatabaseProperties.DatabaseTableInformation.GetFullNamePath());
                /*
             dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(opnJSON.FileName));
             MessageBox.Show($"The name of db is: { jsonFile["Compiler"]}");
             dashboard_placeHolder.Text = jsonFile["DatabaseName"];
                */


            }
        }

        private void Libre_Navigator_Load(object sender, EventArgs e)
        {
            loadData();
            dashboard_placeHolder.Text = ResourceDisplayName;

        }

        private void btn_OpenResource_Click(object sender, EventArgs e)
        {
            ListViewItem selectOpen = new ListViewItem();
            selectOpen = ResourceList.SelectedItems[0];
            string selectedID = selectOpen.SubItems[0].Text;
            string selectedName = selectOpen.SubItems[1].Text;
            // string selectedName = selectOpen.SubItems[2].Text;
            //MessageBox.Show(selectOpen.SubItems[0].Text);
            opnResource.inputData(selectedID, selectedName);
           // opnResource.OpenFile();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void tstopen_Click(object sender, EventArgs e)
        {
            ListViewItem nc = new ListViewItem();
            nc = ResourceList.SelectedItems[0];
            string selectid = nc.SubItems[0].Text;
            dbConnection.ExtractToFileStream(selectid);
            MessageBox.Show(dbConnection.nice);
        }
    }
}
