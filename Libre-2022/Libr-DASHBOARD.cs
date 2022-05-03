using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libre_2022
{
    public partial class dashBoard : Form
    {
        private string databaseName;

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

        }
    }
}
