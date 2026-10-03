using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKY
{
    internal class Connection
    {
        //private static string stringConection = @"Data Source=DESKTOP-KJOBVLO\SQLEXPRESS;Initial Catalog=Quanlykhohang0312;Integrated Security=True;TrustServerCertificate=True";
        private static string stringConection = @"Data Source=DESKTOP-KJOBVLO\SQLEXPRESS;Initial Catalog=Quanlykhohangfinal;Integrated Security=True;TrustServerCertificate=True";


        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConection);
        }
    }
}
