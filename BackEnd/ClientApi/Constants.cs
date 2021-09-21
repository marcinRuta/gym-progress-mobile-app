using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi
{
    public class Constants
    {
       // public const string dataBaseAddress = "http://localhost:49150/DataBase/";
        public static string dataBaseAddress = Environment.GetEnvironmentVariable("dataBaseAddress");

    }
}
