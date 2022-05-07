using Newtonsoft.Json;
using System.IO;


namespace Libre_2022.LIBRE_ENG.DatabaseProperties
{
    public static class DatabaseInformation
    {
        /*
        public DatabaseInformation(string name, string description, string compiler, int version)
        {
            Name = name;
            Description = description;
            Compiler = compiler;
            Version = version;
        }
        */

        //JSON VALUES
        public static string Name { get; set; }

                public static string GetName()
        {
            return Name;
        }
        public static string Description { get; set; }
        public static string Compiler { get; set; }
        public static int Version { get; set; }


    }

    public static class DatabaseTableInformation
    {

        public static string DatabasePath { get; set; }
        public static string databaseName { get; set; }

        public static string FullNamePath { get; set; }

                public static string GetFullNamePath()
                {
                    return FullNamePath;
                }
                public static string GetDatabaseName()
                {
                    return databaseName;
                }

                public static void SetDatabaseName(string value)
                {
                    databaseName = value;
                }
        public static string TableName { get; set; }

                public static string GetTableName()
                {
                    return TableName;
                }

        public static string[] TableColumns { get; set; }



    }

    public static class Methods
    {
        public static void ReadData(string JSONLocation, string DirectoryPath)
        {

            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(JSONLocation));
            // Set Properties:
            DatabaseInformation.Name = jsonFile["DatabaseName"];
            DatabaseTableInformation.databaseName = jsonFile["DatabaseName_Loc"];
            DatabaseTableInformation.TableName = jsonFile["TableName"];
            DatabaseTableInformation.FullNamePath = DirectoryPath + "\\" + DatabaseTableInformation.databaseName;
            DatabaseConnection._databasePath = JSONLocation;
            DatabaseConnection.DatabaseDirectory = DirectoryPath;

            Libre_Navigator.SetResourceDisplayName(DatabaseInformation.GetName());

            // DatabaseTableInformation.SetDatabaseName(jsonFile["DatabaseName"]);
        }
    }
}
