using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFudbalskiKlubZavrsniRad2017.Klase;


namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class ZaduzujuDal
    {
        public int ZaduziOpremu(Zaduzuju z)
        {
            SqlConnection SqlCOnn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("ZaduziOpremu", SqlCOnn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", z.Clanovi_BRCK);
                cmd.Parameters.AddWithValue("@Oprema_SifOpreme", z.Oprema_SifOpreme);
                cmd.Parameters.AddWithValue("@Kolicinu", z.Kolicina);
                cmd.Parameters.AddWithValue("@Datum", z.Datum);

                SqlCOnn.Open();

                cmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception)
            {
                 return -1;
            }
            finally
            {
                SqlCOnn.Close();
            }
        }
    }
}
