using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreEngine_Root;
using Libre_2022.LIBRE_ENG;



namespace Libre_2022
{
    public partial class dashBoard : Form
    {
        LIBRE_ENG.DatabaseConnect dbProperty = new LIBRE_ENG.DatabaseConnect();
       // LIBRE_ENG.DatabaseConnection dbConenction = new LIBRE_ENG.DatabaseConnection();
        public static string databaseName;
        public static string databasePath;

        public dashBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           // shadowForm_dashBoard.SetShadowForm(this);



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
    
                dbProperty.SetNamePath(databasePath, databaseName);
                //  dbConenction.initializeLoad();
                //   MessageBox.Show(dbProperty.databasePath);
                MessageBox.Show(dbProperty._connectionString);
                dbProperty.initializeLoad();
                loadData();
                /*
                LibreEngine_Root.LibreEngine.Libre_databasePath = databasePath;
                MessageBox.Show(LibreEngine_Root.LibreEngine.Libre_databasePath);   

                */

                /*just test
                 * MessageBox.Show(databaseName); */

            }
  
        }

        private void loadData()
        {
            try
            {
                if (dbProperty.dt.Rows.Count > 0)   
                {
                    for(int i = 0; i < dbProperty.dt.Rows.Count; i++)
                    {
                        DataRow dr = dbProperty.dt.Rows[i];
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
    }
}
