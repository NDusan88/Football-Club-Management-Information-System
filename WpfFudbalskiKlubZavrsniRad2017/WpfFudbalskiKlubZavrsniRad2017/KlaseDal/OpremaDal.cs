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
    class OpremaDal
    {
        public int DodajOpremu(Oprema o)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("DodajOpremu", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@Tip", o.Tip);
                cmd.Parameters.AddWithValue("@Proizvodjac", o.Proizvodjac);
                cmd.Parameters.AddWithValue("@Broj", o.Broj);
                cmd.Parameters.AddWithValue("@Boja", o.Boja);

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

        public List<Oprema> ListaOpreme()
        {

            List<Oprema> lista = new List<Oprema>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT o.SifOpreme, o.Tip, o.Proizvodjac, o.Broj, o.Boja FROM projekatbp_fk.oprema as o  LEFT OUTER JOIN projekatbp_fk.nabavlja as n ON o.SifOpreme = n.Oprema_SifOpreme WHERE n.Kolicina is Null", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Oprema o = new Oprema();

                    o.SifOpreme = read.GetInt32(0);
                    o.Tip = read.GetString(1);
                    o.Proizvodjac = read.GetString(2);
                    o.Broj = read.GetInt32(3);
                    o.Boja = read.GetString(4);

                    lista.Add(o);
                }

                return lista;
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

        public List<Oprema> ListaOpremeZaZaduzivanje()
        {

            List<Oprema> lista = new List<Oprema>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT o.SifOpreme, o.Tip, o.Proizvodjac, o.Broj, o.Boja, n.Kolicina FROM projekatbp_fk.oprema as o  LEFT OUTER JOIN projekatbp_fk.nabavlja as n ON o.SifOpreme = n.Oprema_SifOpreme WHERE Kolicina > 0", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Oprema o = new Oprema();

                    o.SifOpreme = read.GetInt32(0);
                    o.Tip = read.GetString(1);
                    o.Proizvodjac = read.GetString(2);
                    o.Broj = read.GetInt32(3);
                    o.Boja = read.GetString(4);
                    o.Kolicina = read.GetInt32(5);

                    lista.Add(o);
                }

                return lista;
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
