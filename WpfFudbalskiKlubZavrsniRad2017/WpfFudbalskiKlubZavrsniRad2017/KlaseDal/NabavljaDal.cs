using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WpfFudbalskiKlubZavrsniRad2017.Klase;

namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class NabavljaDal
    {
        public int NarucOpremu(Nabavlja n)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("NaruciOpremu", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Oprema_SifOpreme", n.Oprema_SifOpreme);
                cmd.Parameters.AddWithValue("@Dobavljaci_SifDobavljaca", n.Dobavljaci_SifDobavljaca);
                cmd.Parameters.AddWithValue("@Datum", n.Datum);
                cmd.Parameters.AddWithValue("@Kolicina", n.Kolicina);

                SqlConn.Open();

                cmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception)
            {
                throw;
                //return -1;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public int AzuriajOpremu(Nabavlja n)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.nabavlja set Kolicina = Kolicina - @Kolicina WHERE Oprema_SifOpreme = @Oprema_SifOpreme Delete from projekatbp_fk.nabavlja where Kolicina = 0", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Kolicina", n.Kolicina);
                cmd.Parameters.AddWithValue("@Oprema_SifOpreme", n.Oprema_SifOpreme);

                SqlConn.Open();

                cmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                SqlConn.Close();
            }
        }
     
    }
}
