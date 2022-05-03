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
            opnLibr.Filter = "Libr Database|*.lib" + 
                             "|Archives Files|*.zip;*.rar" +
                             "|JSON FIles|*.json" +
                             "|All Files|*.*";
            if (opnLibr.ShowDialog() == DialogResult.OK)
            {
                databasePath = opnLibr.FileName;
                databaseName = opnLibr.SafeFileName;
                var dbProperty = new LIBRE_ENG.DatabaseProperties();
                dbProperty.SetNamePath(databasePath, databaseName);
                //MessageBox.Show(dbProperty.TestName);

                /*
                LibreEngine_Root.LibreEngine.Libre_databasePath = databasePath;
                MessageBox.Show(LibreEngine_Root.LibreEngine.Libre_databasePath);   

                */

                /*just test
                 * MessageBox.Show(databaseName); */

            }
  

        }
    }
}
