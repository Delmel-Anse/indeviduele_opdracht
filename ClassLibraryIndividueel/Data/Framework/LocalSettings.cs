using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryIndividueel.Data.Framework
{
    internal class LocalSettings
    {
        public static string GetConnectionString()
        {
            string connectionString = "Trusted_Connection = True;";
            //string connectionString = "user id = pxluser;";
            //connectionString += "Password = pxluser;";
            connectionString += $@"Server=ANSE-DELMEL\SQLEXPRESS2;";
            connectionString += $"Database=TestRF;";
            return connectionString;
        }
    }
}
