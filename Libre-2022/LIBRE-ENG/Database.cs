using System.Data;
using System.Data.SQLite;

namespace Libre_2022.LIBRE_ENG
{

    public class DatabaseConnect
    {


        public string databasePath { get; set; }

        public static string _databasePath;
        private string databaseName { get; set; }

        public string TestName;

        //DATABASE

        public static string _cnString;

        static string connnectionString = @"Data Source=" + _databasePath + ";Version=3";
        public string _connectionString = connnectionString;
        SQLiteConnection libreDB = new SQLiteConnection(connnectionString);
        SQLiteCommand libredbCMD = new SQLiteCommand();
        SQLiteDataAdapter libreSQLDataAdapter = new SQLiteDataAdapter();
        public DataTable dt = new DataTable();



        public void SetNamePath(string _path, string _name)
        {

            databasePath = _path;
            databaseName = _name;
            _databasePath = databasePath;
            TestName = _databasePath;
            connnectionString = @"Data Source=" + _databasePath + ";Version=3";
            _connectionString = @"Data Source=" + _databasePath + ";Version=3";
            libreDB = new SQLiteConnection(_connectionString);
            

        }

        public void initializeLoad()
        {


            libreDB.Open();
           
            libreSQLDataAdapter = new SQLiteDataAdapter("SELECT * FROM [test_librResourceDB]", libreDB); //change select command
            libreSQLDataAdapter.Fill(dt);
           


        }

    }

    public class DatabaseConnection
    {



    }
}
