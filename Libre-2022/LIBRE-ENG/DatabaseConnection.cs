using Libre_2022.LIBRE_ENG.DatabaseProperties;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System;

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
        public  string nice;

        static string connnectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
        public string _connectionString = connnectionString;
        public SQLiteConnection libreDB = new SQLiteConnection(connnectionString);
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
            libreDB.Close();



        }
        public void ExtractToFileStream(string _id)
        {
            SQLiteCommand cmd;
            SQLiteDataReader rdr;
            Int32 FileSize;
            byte[] RawData;
            FileStream fs;

            string PathToExtract = Environment.CurrentDirectory;
          

            try

            /**** NOTE
             * PLEASE EDIT ALL VARIABLES PARA MAGIN FLEXIBLE GAD SIYA
             * IEDIT ESPECIALLY AN SA PANGARAN SAN COLUMN NA GA HOLD SAN BLOB/FILESIZE -> ALSO UPDATE THE JSON FILE FOR THIS:
             *              string cmntext = "SELECT Blob, filesize FROM test_librResourceDB WHERE ID = " + _id;
             * > Find a way to know the file size from a Blob File
             *  rdr.GetInt32(rdr.GetOrdinal("filesize")); -> ini siya an gakuha data hali sa row
             *  
             * fs = new FileStream(@"D:\nice.mp3", FileMode.OpenOrCreate, FileAccess.Write);
             * -> i edit ini para mag extract sa kun hain la siya dapat mag extract bro...
             * System.Diagnostics.Process.Start(@"D:\nice.mp3");
             * -> same with this shit
             * 
             * ANYWAYS NICEEEEEE
             * ASYNC FOR THIS PROCESS PLEASE, THEN DISPLAY AL OADING INTERFACE
             * 
             * '
             * */
            {
                libreDB.Open();
                string cmntext = "SELECT Blob, filesize FROM test_librResourceDB WHERE ID = " + _id;
                SQLiteCommand getRes = new SQLiteCommand(cmntext, libreDB);
                getRes.CommandText = cmntext;
                rdr = getRes.ExecuteReader();

                rdr.Read();
                FileSize = rdr.GetInt32(rdr.GetOrdinal("filesize"));
                nice = FileSize.ToString();
                RawData = new byte[FileSize];

                rdr.GetBytes(rdr.GetOrdinal("Blob"), 0, RawData, 0, (int)FileSize);
                fs = new FileStream(@"D:\nice.mp3", FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(RawData, 0, (int)FileSize);
                fs.Close();
                System.Diagnostics.Process.Start(@"D:\nice.mp3");



            }
            finally
            {

            }
        }
    }
        

    public class OpenResource
    {
        static string iconnnectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
        SQLiteConnection getrescon = new SQLiteConnection(iconnnectionString);
        SQLiteConnection libreDB = new SQLiteConnection(iconnnectionString);
        public  string ResourceID;
        public  string ResourceName;

        public  void inputData(string _ID, string _Name)
        {
            //ResourceID = DatabaseTableInformation.tblclmn_ResourceID;
            ResourceID = _ID;
            ResourceName = _Name;
           // OpenFile();
        }
       
      
       
    }

  
}
