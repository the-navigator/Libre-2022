using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Libre_2022.LIBRE_ENG
{   

    public class DatabaseProperties
    {
       

        private string databasePath { get; set; }

        public static string _databasePath;
        private string databaseName { get; set; }

       // public  string TestName = "juj";

        public  void SetNamePath(string _path, string _name)
        {

            databasePath = _path;
            databaseName = _name;
            _databasePath = databasePath;
        }

    }

    public class DatabaseConnection
    {

        static string connnectionString = "DataSource=" + DatabaseProperties._databasePath;
        SQLiteConnection libreDB = new SQLiteConnection(connnectionString);
        SQLiteCommand libredbCMD = new SQLiteCommand();
        SQLiteDataAdapter libreSQLDataAdapter = new SQLiteDataAdapter();
        public DataTable dt = new DataTable();



 
    }
}
