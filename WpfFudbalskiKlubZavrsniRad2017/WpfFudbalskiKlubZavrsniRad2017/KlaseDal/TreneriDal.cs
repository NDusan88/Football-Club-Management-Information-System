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
    class TreneriDal
    {
       public int DodajTrenera(Treneri t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UbaciTrenera",SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", t.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@DatumPolaganja", t.DatumPolaganja);
                cmd.Parameters.AddWithValue("@Tip", t.Tip);

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

        public int PromeniTrenera(Treneri t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DELETE FROM projekatbp_fk.treneri WHERE Clanovi_BrCK = @Clanovi_BrCK; ", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", t.Clanovi_BrCK);

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

        public int PromeniTipTrenera(Treneri t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.treneri SET Tip = @Tip WHERE Clanovi_BrCK = @Clanovi_BrCK", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", t.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Tip", t.Tip);

                SqlConn.Open();

                cmd.ExecuteNonQuery();

                return 0;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                SqlConn.Close();
            }
        }

        public List<TreneriA> PrikaziListuTrenera()
        {
            List<TreneriA> listaTrenera = new List<TreneriA>();
            SqlConnection Sqlconn = Konekcija.KreirajKonekciju();

            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime, c.Prezime, t.Tip FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.treneri as t ON c.BrCK = t.Clanovi_BrCK WHERE  Tip is not null", Sqlconn);

            try
            {
                Sqlconn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    TreneriA t = new TreneriA();
                    t.BrCK = read.GetInt32(0);
                    t.Ime = read.GetString(1);
                    t.Prezime = read.GetString(2);
                    t.Tip = read.GetString(3);

                    listaTrenera.Add(t);
                }

                return listaTrenera;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Sqlconn.Close();
            }
        }
    }
}
