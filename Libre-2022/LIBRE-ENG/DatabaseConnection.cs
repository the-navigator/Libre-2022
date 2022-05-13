﻿using Libre_2022.LIBRE_ENG.DatabaseProperties;
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



        }

    }

    public class OpenResource
    {
        static string connnectionString = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
        SQLiteConnection libreDB = new SQLiteConnection(connnectionString);
        public  string ResourceID;
        public  string ResourceName;

        public  void inputData(string _ID)
        {
            //ResourceID = DatabaseTableInformation.tblclmn_ResourceID;
            ResourceID = _ID;
            //ResourceName = _Name;]
            OpenFile();
        }

        public void OpenFile()
        {
            string pathToExtract = Environment.CurrentDirectory;   
            string opncn = @"Data Source=" + DatabaseTableInformation.GetFullNamePath() + ";Version=3";
            SQLiteConnection opn = new SQLiteConnection(opncn);
            opn = new SQLiteConnection(opncn);
            opn.Open();
            SQLiteCommand openFile = new SQLiteCommand("SELECT * FROM " +DatabaseTableInformation.GetTableName()+ 
                " WHERE ID=" + ResourceID, opn);
            
           
            SQLiteDataReader openFileReader = openFile.ExecuteReader(System.Data.CommandBehavior.Default);

            try
            {
                while (openFileReader.Read())
                {
                    SQLiteBlob fileBlob = openFileReader.GetBlob(openFileReader.GetOrdinal(DatabaseTableInformation.tblclmn_ResourceBLOB), readOnly: true);
                    long fileSize = openFileReader.GetInt32(openFileReader.GetOrdinal(DatabaseTableInformation.tblclmn_ResourceBLOB));
                    byte[] fileData = new byte[fileSize];
                    openFileReader.GetBytes(openFileReader.GetInt32(openFileReader.GetOrdinal(DatabaseTableInformation.tblclmn_ResourceBLOB)), 0, fileData, 0, (int)fileSize);

                    string fileName = openFileReader.GetString(openFileReader.GetOrdinal(DatabaseTableInformation.tblclmn_ResourceName));
                    string fileExt = openFileReader.GetString(openFileReader.GetOrdinal(DatabaseTableInformation.tblclmn_ResourceExtension));
                    string fullPath = pathToExtract + "\\" + fileName + fileExt;
                    FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate);
                    fs.Write(fileData, 0, (int)fileSize);
                    System.Diagnostics.Process.Start(fullPath);
                }

         
            }
            catch
            {

            }
            
        }
    }
}
