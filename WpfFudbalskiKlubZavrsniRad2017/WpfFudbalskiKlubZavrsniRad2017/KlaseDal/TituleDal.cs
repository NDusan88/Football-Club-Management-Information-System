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
    class TituleDal
    {
        public int DodajTitulu(Titule t)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DodajTitulu", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Ucestvuju_Igraci_Clanovi_BrCK", t.Ucestvuju_Igraci_Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Ucestvuju_Takmicenja_RBr", t.Ucestvuju_Takmicenja_RBr);
                cmd.Parameters.AddWithValue("@Naziv", t.Naziv);
                cmd.Parameters.AddWithValue("@Dodelio", t.Dodelio);

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
        public List<IgraciSaTitulom> PrikaziListuIgraca()
        {
            List<IgraciSaTitulom> listaIgraca = new List<IgraciSaTitulom>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime,c.Prezime, i.Pozicija,i.BrojDresa, t.Naziv, ta.Naziv FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.igraci as i ON c.BrCK = i.Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.ucestvuju as u ON i.Clanovi_BrCK = u.Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.titule as t ON u.Igraci_Clanovi_BrCK = t.Ucestvuju_Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.takmicenja as ta ON t.Ucestvuju_Takmicenja_RBr = ta.RBr WHERE Pozicija is not null and BrojDresa is not null and t.Naziv is not null and ta.Naziv is not null", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    IgraciSaTitulom i = new IgraciSaTitulom();

                    i.BrCK = read.GetInt32(0);
                    i.Ime = read.GetString(1);
                    i.Prezime = read.GetString(2);
                    i.Pozicija = read.GetString(3);
                    i.BrojDresa = read.GetInt32(4);
                    i.Naziv = read.GetString(5);
                    i.NazivKupa = read.GetString(6);

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

        public List<IgraciSaTitulom> FiltrirajIgraca(string ime)
        {
            List<IgraciSaTitulom> listaIgraca = new List<IgraciSaTitulom>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime,c.Prezime, i.Pozicija,i.BrojDresa, t.Naziv, ta.Naziv FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.igraci as i ON c.BrCK = i.Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.ucestvuju as u ON i.Clanovi_BrCK = u.Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.titule as t ON u.Igraci_Clanovi_BrCK = t.Ucestvuju_Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.takmicenja as ta ON t.Ucestvuju_Takmicenja_RBr = ta.RBr WHERE Pozicija is not null and BrojDresa is not null and t.Naziv is not null and ta.Naziv is not null and Ime LIKE @Ime + '%'", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Ime", ime);
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    IgraciSaTitulom i = new IgraciSaTitulom();

                    i.BrCK = read.GetInt32(0);
                    i.Ime = read.GetString(1);
                    i.Prezime = read.GetString(2);
                    i.Pozicija = read.GetString(3);
                    i.BrojDresa = read.GetInt32(4);
                    i.Naziv = read.GetString(5);
                    i.NazivKupa = read.GetString(6);

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

        public int ObrisiIgraca(IgraciSaTitulom i)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("ObrisiIgracaTitulu", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Ucestvuju_Igraci_Clanovi_BrCK", i.BrCK);
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
