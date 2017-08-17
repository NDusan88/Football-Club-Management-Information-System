using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfFudbalskiKlubZavrsniRad2017.Klase;

namespace WpfFudbalskiKlubZavrsniRad2017.KlaseDal
{
    class ClanoviDal
    {
        public int DodajClana(Clanovi c)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UbaciClana", SqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@JMBG", c.JMBG);
                cmd.Parameters.AddWithValue("@Prezime", c.Prezime);
                cmd.Parameters.AddWithValue("@ImeRoditelja", c.ImeRoditelja);
                cmd.Parameters.AddWithValue("@Ime", c.Ime);
                cmd.Parameters.AddWithValue("@Adresa", c.Adresa);
                cmd.Parameters.AddWithValue("@Telefon", c.Telefon);
                cmd.Parameters.AddWithValue("@Godiste", c.Godiste);
                cmd.Parameters.AddWithValue("@PosStatus", c.PosStatus);

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
        public List<Clanovi> PrikaziClanoveIgraca()
        {
            List<Clanovi> listaClanovaIgraca = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT C.BrCK, C.Ime, C.Prezime, c.PosStatus FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.igraci i ON c.BrCK = i.Clanovi_BrCK WHERE PosStatus = 'Igrac' AND Clanovi_BrCK IS NULL", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);
                    c.PosStatus = read.GetString(3);

                    listaClanovaIgraca.Add(c);
                }

                return listaClanovaIgraca;
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

        public List<Clanovi> PrikaziCLanoveTrenera()
        {
            List<Clanovi> listaClanovaTrenera = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, C.Ime, C.Prezime, c.PosStatus FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.treneri t ON c.BrCK = t.Clanovi_BrCK WHERE PosStatus = 'Trener' AND Clanovi_BrCK is NULL", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);
                    c.PosStatus = read.GetString(3);

                    listaClanovaTrenera.Add(c);
                }

                return listaClanovaTrenera;
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
        public List<Clanovi> PrikaziClanoveSudija()
        {
            List<Clanovi> listaClanovaSudija = new List<Clanovi>();

            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT c.BrCK, c.Ime, c.Prezime, c.PosStatus FROM projekatbp_fk.clanovi as c LEFT OUTER JOIN projekatbp_fk.sudije s ON c.BrCK = s.Clanovi_BrCK WHERE PosStatus = 'Sudija'AND Clanovi_BrCK is NULL", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);
                    c.PosStatus = read.GetString(3);

                    listaClanovaSudija.Add(c);
                }

                return listaClanovaSudija;
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

        public List<Clanovi> PrikaziBrCK()
        {
            List<Clanovi> listaBrck = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("Select top 1 BrCK From projekatbp_fk.clanovi Order by BrCK desc", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    listaBrck.Add(c);
                }

                return listaBrck;
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

        public List<Clanovi> PrikazSvihClanova()
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("Select * From projekatbp_fk.clanovi", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.JMBG = read.GetString(1);
                    c.Prezime = read.GetString(2);
                    c.ImeRoditelja = read.GetString(3);
                    c.Ime = read.GetString(4);
                    c.Adresa = read.GetString(5);
                    c.Telefon = read.GetString(6);
                    c.Godiste = read.GetInt32(7);
                    c.PosStatus = read.GetString(8);

                    listaClanova.Add(c);

                }

                return listaClanova;
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
        public List<Clanovi> PrikazIgraca()
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT BrCK, Ime, Prezime FROM projekatbp_fk.clanovi WHERE PosStatus = 'Igrac'", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);

                    listaClanova.Add(c);

                }

                return listaClanova;
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
        public List<Clanovi> PrikazSudija()
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT BrCK, Ime, Prezime FROM projekatbp_fk.clanovi WHERE PosStatus = 'Sudija'", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);

                    listaClanova.Add(c);

                }

                return listaClanova;
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
        public List<Clanovi> PrikazTrenera()
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("SELECT BrCK, Ime, Prezime FROM projekatbp_fk.clanovi WHERE PosStatus = 'Trener'", SqlConn);

            try
            {
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.Ime = read.GetString(1);
                    c.Prezime = read.GetString(2);

                    listaClanova.Add(c);

                }

                return listaClanova;
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

        public int PromeniPoziciju(Clanovi c)
        {
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("UPDATE projekatbp_fk.clanovi SET PosStatus = @PosStatus WHERE BrCK = @BrCK UPDATE projekatbp_fk.clanovi SET Ime = @Ime WHERE BrCK = @BrCK UPDATE projekatbp_fk.clanovi SET JMBG = @JMBG WHERE BrCK = @BrCK UPDATE projekatbp_fk.clanovi SET Prezime = @Prezime WHERE BrCK = @BrCK UPDATE projekatbp_fk.clanovi SET Adresa = @Adresa WHERE BrCK = @BrCK UPDATE projekatbp_fk.clanovi SET Telefon = @Telefon WHERE BrCK = @BrCK Delete projekatbp_fk.igraci WHERE Clanovi_BrCK = @Clanovi_BrCK  Delete projekatbp_fk.treneri WHERE Clanovi_BrCK = @Clanovi_BrCK  Delete projekatbp_fk.sudije WHERE Clanovi_BrCK = @Clanovi_BrCK", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@BrCK", c.BrCK);
                cmd.Parameters.AddWithValue("@PosStatus", c.PosStatus);
                cmd.Parameters.AddWithValue("@Clanovi_BrCK", c.Clanovi_BrCK);
                cmd.Parameters.AddWithValue("@Ime", c.Ime);
                cmd.Parameters.AddWithValue("@JMBG", c.JMBG);
                cmd.Parameters.AddWithValue("@Prezime", c.Prezime);
                cmd.Parameters.AddWithValue("@Telefon", c.Telefon);
                cmd.Parameters.AddWithValue("@Adresa", c.Adresa);

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

        //public int ObrisiClana(Clanovi c)
        //{
        //    SqlConnection SqlConn = Konekcija.KreirajKonekciju();
        //    SqlCommand cmd = new SqlCommand("ObrisiClana", SqlConn);
        //    SqlCommand cmd1 = new SqlCommand("ObrisiClanarinu", SqlConn);
        //    cmd1.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandType = CommandType.StoredProcedure;
           
        //    try
        //    {
        //        cmd1.Parameters.AddWithValue("@Clanovi_BrCK", c.Clanovi_BrCK);
        //        cmd.Parameters.AddWithValue("@BrCK", c.BrCK);
                        

        //        SqlConn.Open();

        //        cmd.ExecuteNonQuery();

        //        return 0;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //       // return -1;
        //    }
        //    finally
        //    {
        //        SqlConn.Close();
        //    }
        //}

        public List<Clanovi> FiltrirajClana(string Ime)
        {
            List<Clanovi> listaClanova = new List<Clanovi>();
            SqlConnection SqlConn = Konekcija.KreirajKonekciju();
            SqlCommand cmd = new SqlCommand("Select * From projekatbp_fk.clanovi WHERE Ime LIKE @Ime + '%'", SqlConn);

            try
            {
                cmd.Parameters.AddWithValue("@Ime", Ime);
                SqlConn.Open();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    Clanovi c = new Clanovi();

                    c.BrCK = read.GetInt32(0);
                    c.JMBG = read.GetString(1);
                    c.Prezime = read.GetString(2);
                    c.ImeRoditelja = read.GetString(3);
                    c.Ime = read.GetString(4);
                    c.Adresa = read.GetString(5);
                    c.Telefon = read.GetString(6);
                    c.Godiste = read.GetInt32(7);
                    c.PosStatus = read.GetString(8);

                    listaClanova.Add(c);
                }
                return listaClanova;
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
