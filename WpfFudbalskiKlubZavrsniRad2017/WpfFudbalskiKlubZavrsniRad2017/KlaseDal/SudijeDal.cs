using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WpfFudbalskiKlubZavrsniRad2017.Klase;

namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class SudijeDal
    {
        public int DodajSudiju(Sudije s)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UbaciSudiju", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", s.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@DatumPolaganja", s.DatumPolaganja);
                cmd.Parameters.AddWithValue("@Rang", s.Rang);
                cmd.Parameters.AddWithValue("@Tip", s.Tip);

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

        public List<SudijaTR> PrikaziSudije()
        {
            List<SudijaTR> listaSudija = new List<SudijaTR>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime, c.Prezime, s.Tip, s.Rang, s.DatumPolaganja FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.sudije AS s ON c.BrCK = s.Clanovi_BrCK WHERE Tip IS NOT NULL", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    SudijaTR s = new SudijaTR();
                    s.BrCK = read.GetInt32(0);
                    s.Ime = read.GetString(1);
                    s.Prezime = read.GetString(2);
                    s.Tip = read.GetString(3);
                    s.Rang = read.GetString(4);
                    s.DatumPolaganja = read.GetDateTime(5);

                    listaSudija.Add(s);
                }

                return listaSudija;
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

        public int PromeniTipSudije(Sudije s)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.sudije SET Tip = @Tip WHERE Clanovi_BrCK = @Clanovi_BrCK", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", s.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Tip", s.Tip);

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

        public int PromeniRangSudije(Sudije s)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.sudije SET Rang = @Rang WHERE Clanovi_BrCK = @Clanovi_BrCK", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", s.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Rang", s.Rang);

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
    }
}
