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
    class IgraciDal
    {
        public int DodajIgraca(Igraci i)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UbaciIgraca",SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", i.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Status", i.Status);
                cmd.Parameters.AddWithValue("@Pozicija", i.Pozicija);
                cmd.Parameters.AddWithValue("@BrojDresa", i.BrojDresa);
                cmd.Parameters.AddWithValue("@Noga", i.Noga);

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

        public int PromeniStatus(Igraci i)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.igraci SET Status = @Status WHERE Clanovi_BrCK = @Clanovi_BrCK", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", i.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Status", i.Status);
                
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

        public int PromeniIgraca(Igraci i)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DELETE FROM projekatbp_fk.igraci WHERE Clanovi_BrCK = @Clanovi_BrCK; ", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", i.Clanovi_BrCK);

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
