using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Libre_2022.LIBRE_ENG.DatabaseProperties
{
    public class DatabaseInformation
    {
        public DatabaseInformation(string name, string description, string compiler, int version)
        {
            Name = name;
            Description = description;
            Compiler = compiler;
            Version = version;
        }

        public string Name { get; set; }
        public string Description { get; set; } 
        public string Compiler { get; set; }    
        public int Version { get; set; }


    }

    public class DatabaseTableInformation
    {
       public string TableName { get; set; }
       public string[] TableColumns { get; set; }

    }
}
