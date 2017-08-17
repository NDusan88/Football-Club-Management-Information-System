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
    class IgraciApDal
    {
        public List<IgraciApD> PrikaziAktivneIgrace()
        {

            List<IgraciApD> listaAktivnihIgraca = new List<IgraciApD>();
            SqlConnection Sqlconn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime, c.Prezime, i.Pozicija,i.BrojDresa, i.Status, i.Noga, u.Datum FROM projekatbp_fk.clanovi as c  LEFT OUTER JOIN projekatbp_fk.igraci i ON c.BrCK = i.Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.ucestvuju as u ON c.BrCK = u.Igraci_Clanovi_BrCK WHERE Status is not null AND Datum is null", Sqlconn);

            try
            {
                Sqlconn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    IgraciApD ig = new IgraciApD();

                    ig.BrCK = read.GetInt32(0);
                    ig.Ime = read.GetString(1);
                    ig.Prezime = read.GetString(2);
                    ig.Pozicija = read.GetString(3);
                    ig.BrojDresa = read.GetInt32(4);
                    ig.Status = read.GetString(5);
                    ig.Noga = read.GetString(6);

                    listaAktivnihIgraca.Add(ig);
                }

                return listaAktivnihIgraca;
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

        public List<IgraciApD> PrikaziIgraceBezTitule(string i)
        {

            List<IgraciApD> listagraca = new List<IgraciApD>();
            SqlConnection Sqlconn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime, c.Prezime, i.Pozicija,i.BrojDresa, i.Status, i.Noga, ta.Naziv, t.Dodelio  FROM projekatbp_fk.clanovi as c  LEFT OUTER JOIN projekatbp_fk.igraci i  ON c.BrCK = i.Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.titule as t ON c.BrCK = t.Ucestvuju_Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.ucestvuju as u ON c.BrCK = u.Igraci_Clanovi_BrCK LEFT OUTER JOIN projekatbp_fk.takmicenja as ta ON u.Takmicenja_RBr = ta.RBr where ta.Naziv = @Naziv and t.Dodelio is NULL", Sqlconn);

            try
            {
                cmd.Parameters.AddWithValue("@Naziv", i);
                Sqlconn.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    IgraciApD ig = new IgraciApD();

                    ig.BrCK = read.GetInt32(0);
                    ig.Ime = read.GetString(1);
                    ig.Prezime = read.GetString(2);
                    ig.Pozicija = read.GetString(3);
                    ig.BrojDresa = read.GetInt32(4);
                    ig.Status = read.GetString(5);
                    ig.Noga = read.GetString(6);

                    listagraca.Add(ig);
                }

                return listagraca;
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
