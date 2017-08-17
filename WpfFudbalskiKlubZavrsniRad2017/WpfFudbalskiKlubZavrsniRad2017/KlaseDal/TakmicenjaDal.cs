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
    class TakmicenjaDal
    {
        public int DodajTakmicenja(Takmicenja t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DodajTakmicenja", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Naziv", t.Naziv);
                cmd.Parameters.AddWithValue("@Mesto", t.Mesto);
                cmd.Parameters.AddWithValue("@Tip", t.Tip);
                cmd.Parameters.AddWithValue("@Podloga", t.Podloga);

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

        public List<Takmicenja> PrikaziListuTakmicenja()
        {
            List<Takmicenja> listaTakmicenja = new List<Takmicenja>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM projekatbp_fk.takmicenja", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Takmicenja t = new Takmicenja();
                    t.RBr = read.GetInt32(0);
                    t.Naziv = read.GetString(1);
                    t.Mesto = read.GetString(2);
                    t.Tip = read.GetString(3);
                    t.Podloga = read.GetString(4);

                    listaTakmicenja.Add(t);
                }

                return listaTakmicenja;
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
        public List<IgraciKojiUcestvuju> PrikaziIgraceKojiUcestvuju()
        {
            List<IgraciKojiUcestvuju> listaIgraca = new List<IgraciKojiUcestvuju>();

            SqlConnection Sqlconn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PrikazUcestvovanja", Sqlconn);

            try
            {
                Sqlconn.Open();
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
                Sqlconn.Close();
            }
        }

        public int PromeniTakmicenja(Takmicenja t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("PromeniTakmicenja", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@RBr", t.RBr);
                cmd.Parameters.AddWithValue("@Naziv", t.Naziv);
                cmd.Parameters.AddWithValue("@Tip", t.Tip);
                cmd.Parameters.AddWithValue("@Mesto", t.Mesto);
                cmd.Parameters.AddWithValue("@Podloga", t.Podloga);

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

        public List<Takmicenja> FiltrirajTakmicenja(string Naziv)
        {
            List<Takmicenja> listaTakmicenja = new List<Takmicenja>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("Select * From projekatbp_fk.takmicenja WHERE Naziv LIKE @Naziv + '%'", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Naziv", Naziv);
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Takmicenja t = new Takmicenja();
                    t.RBr = read.GetInt32(0);
                    t.Naziv = read.GetString(1);
                    t.Mesto = read.GetString(2);
                    t.Tip = read.GetString(3);
                    t.Podloga = read.GetString(4);

                    listaTakmicenja.Add(t);
                }
                return listaTakmicenja;
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

        public int ObrisiTakmicenja(Takmicenja t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("ObrisiTakmicenja", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@RBr", t.RBr);

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
