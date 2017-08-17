using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFudbalskiKlubZavrsniRad2017.Klase;
using System.Data.SqlClient;
using System.Data;

namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class UcestvovanjeDal
    {
        public int DodajUcestvovanja(Ucestvovanje u)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DodajUcestvovanja", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Igraci_Clanovi_BrCK", u.Igraci_Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Takmicenja_RBr", u.Takmicenja_RBr);
                cmd.Parameters.AddWithValue("@Datum", u.Datum);

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
        public int ObrisiIgraca(Ucestvovanje u)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("ObrisiIgracaUc", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Igraci_Clanovi_BrCK", u.Igraci_Clanovi_BrCK);
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
        public List<IgraciKojiUcestvuju> FiltrirajClana(string Ime)
        {
            List<IgraciKojiUcestvuju> listaIgraca = new List<IgraciKojiUcestvuju>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("Select * FROM PrikazUcestvovanja WHERE Ime LIKE @Ime + '%'", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Ime", Ime);
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    IgraciKojiUcestvuju i = new IgraciKojiUcestvuju();

                    i.BrCK = read.GetInt32(0);
                    i.Ime = read.GetString(1);
                    i.Prezime = read.GetString(2);
                    i.Pozicija = read.GetString(3);
                    i.BrojDresa = read.GetInt32(4);
                    i.Noga = read.GetString(5);
                    i.Naziv = read.GetString(6);
                    i.Mesto = read.GetString(7);
                    i.Tip = read.GetString(8);
                    i.Podloga = read.GetString(9);
                    i.Datum = read.GetDateTime(10);

                    listaIgraca.Add(i);
                }
                return listaIgraca;
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
