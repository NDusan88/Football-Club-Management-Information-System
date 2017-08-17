using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WpfFudbalskiKlubZavrsniRad2017.Klase;

namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class ClanarineDal
    {
        public int UbaciClanarinu(Clanarine c)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UbaciClanarinu", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", c.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@BrojUplatnice", c.BrojUplatnice);
                cmd.Parameters.AddWithValue("@DatumPlacanja", c.DatumPlacanja);
                cmd.Parameters.AddWithValue("@Iznos", c.Iznos);
                cmd.Parameters.AddWithValue("@Mesec", c.Mesec);
                cmd.Parameters.AddWithValue("@Godina", c.Godina);

                SqlConn.Open();

                cmd.ExecuteNonQuery();

                return 0;

            }
            catch (Exception)
            {
                //throw;
                return -1;
            }
            finally
            {
                SqlConn.Close();
            }
        }
    }
}
