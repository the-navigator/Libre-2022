using Libre_2022.LIBRE_ENG.DatabaseProperties;
using System.Data;
using System.Data.SQLite;

namespace Libre_2022.LIBRE_ENG
{

    public class DatabaseConnection
    {

        public string databasePath { get; set; }

        public static string _databasePath;

        public static string DatabaseDirectory;
        private string databaseName { get; set; }


        public string TestName;

        //DATABASE

        public static string _cnString;

        static string connnectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
        public string _connectionString = connnectionString;
        SQLiteConnection libreDB = new SQLiteConnection(connnectionString);
        SQLiteCommand libredbCMD = new SQLiteCommand();
        SQLiteDataAdapter libreSQLDataAdapter = new SQLiteDataAdapter();
        public DataTable dt = new DataTable();



        public void SetNamePath()
        {
            _databasePath = databasePath;
            TestName = _databasePath;
            connnectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
            _connectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
            libreDB = new SQLiteConnection(_connectionString);


        }

        public void initializeLoad()
        {

            dt.Clear();
            libreDB.Open();

            libreSQLDataAdapter = new SQLiteDataAdapter("SELECT * FROM " + "[" + DatabaseTableInformation.GetTableName() + "]", libreDB); //change select command
            libreSQLDataAdapter.Fill(dt);



        }

    }
}
