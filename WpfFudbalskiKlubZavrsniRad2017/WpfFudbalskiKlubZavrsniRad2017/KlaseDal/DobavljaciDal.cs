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
    class DobavljaciDal
    {
        public List<Dobavljac> PrikaziListuDobavljaca()
        {
            List<Dobavljac> listaDobacljaca = new List<Dobavljac>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM projekatbp_fk.dobavljaci", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Dobavljac d = new Dobavljac();

                    d.DobavljaciId = read.GetInt32(0);
                    d.PIB = read.GetInt32(1);
                    d.Naziv = read.GetString(2);
                    d.Delatnost = read.GetString(3);
                    d.Adresa = read.GetString(4);
                    d.Telefon = read.GetString(5);

                    listaDobacljaca.Add(d);
                }

                return listaDobacljaca;
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

        public int DodajDobavljaca(Dobavljac d)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DodajDobavljaca", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@PIB", d.PIB);
                cmd.Parameters.AddWithValue("@Naziv", d.Naziv);
                cmd.Parameters.AddWithValue("@Delatnost", d.Delatnost);
                cmd.Parameters.AddWithValue("@Adresa", d.Adresa);
                cmd.Parameters.AddWithValue("@Telefon", d.Telefon);

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

        public int ObrisiDobavljaca(Dobavljac d)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("ObrisiDobavljaca", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@SifDobavljaca", d.DobavljaciId);
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
