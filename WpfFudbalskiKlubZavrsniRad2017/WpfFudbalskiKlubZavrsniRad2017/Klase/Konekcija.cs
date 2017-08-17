using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfFudbalskiKlubZavrsniRad2017.Klase
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder();
            cnnSb.DataSource = @"DESKTOP-J62H038\SQLEXPRESS";
            cnnSb.InitialCatalog = "FudbalskiKlub";
            cnnSb.IntegratedSecurity = true;

            SqlConnection konn = new SqlConnection(cnnSb.ToString());

            return konn;
        }
    }
}
