using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfFudbalskiKlubZavrsniRad2017.KlaseDal;
using WpfFudbalskiKlubZavrsniRad2017.Klase;


namespace WpfFudbalskiKlubZavrsniRad2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region KlaseDal
        ClanoviDal CDal = new ClanoviDal();
        ClanarineDal ClDal = new ClanarineDal();
        IgraciDal IDal = new IgraciDal();
        TreneriDal TDal = new TreneriDal();
        SudijeDal SDal = new SudijeDal();
        IgraciApDal IgDal = new IgraciApDal();
        TakmicenjaDal TaDal = new TakmicenjaDal();
        UcestvovanjeDal UDal = new UcestvovanjeDal();
        TituleDal TiDal = new TituleDal();
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Metoda za Validaciju Clanova
        private bool ValidacijaClanova()
        {
            Int64 broj;
            int brojj;

            if (string.IsNullOrWhiteSpace(textBoxJMBG.Text))
            {
                MessageBox.Show("Morate uneti Jmbg", "Poruka");
                textBoxJMBG.Clear();
                textBoxJMBG.Focus();
                return false;
            }

            if (!Int64.TryParse(textBoxJMBG.Text, out broj))
            {
                MessageBox.Show("Morate uneti ceo broj", "Poruka");
                textBoxJMBG.Clear();
                textBoxJMBG.Focus();
                return false;
            }
            if (textBoxJMBG.Text.Length < 13)
            {
                MessageBox.Show("JMBG mora imati 13 karaktera", "Poruka");
                textBoxJMBG.Focus();
                return false;
            }
            if (textBoxJMBG.Text.Length > 13)
            {
                MessageBox.Show("JMBG mora imati 13 karaktera", "Poruka");
                textBoxJMBG.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxIme.Text))
            {
                MessageBox.Show("Morate uneti Ime", "Poruka");
                textBoxIme.Clear();
                textBoxIme.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxImeR.Text))
            {
                MessageBox.Show("Morate uneti Ime roditelja", "Poruka");
                textBoxImeR.Clear();
                textBoxImeR.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Morate uneti Prezime", "Poruka");
                textBoxPrezime.Clear();
                textBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAdresa.Text))
            {
                MessageBox.Show("Morate uneti Adresu", "Poruka");
                textBoxAdresa.Clear();
                textBoxAdresa.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
            {
                MessageBox.Show("Morate uneti Telefon", "Poruka");
                textBoxTelefon.Clear();
                textBoxTelefon.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGodiste.Text))
            {
                MessageBox.Show("Morate uneti Godiste", "Poruka");
                textBoxGodiste.Clear();
                textBoxGodiste.Focus();
                return false;
            }

            if (!int.TryParse(textBoxGodiste.Text, out brojj))
            {
                MessageBox.Show("Morate uneti ceo broj", "Poruka");
                textBoxGodiste.Clear();
                textBoxGodiste.Focus();
                return false;
            }
            if (textBoxGodiste.Text.Length < 4)
            {
                MessageBox.Show("Godiste mora imati 4 karaktera", "Poruka");
                textBoxGodiste.Clear();
                textBoxGodiste.Focus();
                return false;
            }
            if (textBoxGodiste.Text.Length > 4)
            {
                MessageBox.Show("Godiste mora imati 4 karaktera", "Poruka");
                textBoxGodiste.Clear();
                textBoxGodiste.Focus();
                return false;
            }
            if (comboBoxPozicija.SelectedIndex < 0)
            {
                MessageBox.Show("Morate uneti zeljenu poziciju", "Poruka");
                return false;
            }

            if (!dtp1.SelectedDate.HasValue)
            {
                MessageBox.Show("Morate uneti tacan datum", "Poruka");
                return false;
            }
            if (comboBoxMesec.SelectedIndex < 0)
            {
                MessageBox.Show("Morate uneti Mesec", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxIznos.Text))
            {
                MessageBox.Show("Morate uneti iznos", "Poruka");
                textBoxIznos.Clear();
                textBoxIznos.Focus();
                return false;
            }
            if (!int.TryParse(textBoxIznos.Text, out brojj))
            {
                MessageBox.Show("Morate uneti ceo broj", "Poruka");
                textBoxIznos.Clear();
                textBoxIznos.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGodina.Text))
            {
                MessageBox.Show("Morate uneti Godinu", "Poruka");
                textBoxGodina.Clear();
                textBoxGodina.Focus();
                return false;
            }
            if (!int.TryParse(textBoxGodina.Text, out brojj))
            {
                MessageBox.Show("Morate uneti ceo broj", "Poruka");
                textBoxGodina.Clear();
                textBoxGodina.Focus();
                return false;
            }
            if (textBoxGodina.Text.Length < 4)
            {
                MessageBox.Show("Godina mora imati 4 karaktera", "Poruka");
                textBoxGodina.Clear();
                textBoxGodina.Focus();
                return false;
            }
            if (textBoxGodina.Text.Length > 4)
            {
                MessageBox.Show("Godina mora imati 4 karaktera", "Poruka");
                textBoxGodina.Clear();
                textBoxGodina.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxUplatnica.Text))
            {
                MessageBox.Show("Morate uneti broj uplatnice", "Poruka");
                textBoxUplatnica.Clear();
                textBoxUplatnica.Focus();
                return false;
            }

            return true;
        }

        #endregion


        #region Metoda za Validaciju Igraca
        private bool ValidacijaIgraca()
        {
            int broj;
            if (dataGridClanoviIgraci.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite clana", "Poruka");
                return false;
            }
            if (comboBoxStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite status", "Poruka");
                return false;
            }
            if (comboBoxPozicijaIgraca.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite poziciju", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxBrDresa.Text))
            {
                MessageBox.Show("Odaberite broj dresa", "Poruka");
                return false;
            }

            if (!int.TryParse(textBoxBrDresa.Text, out broj))
            {
                MessageBox.Show("Odaberite ceo broj", "Poruka");
                return false;
            }
            if (comboBoxNoga.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite nogu", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Validaciju Trenera
        private bool ValidacijaTrenera()
        {
            if (dataGridClanoviTreneri.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite trenera", "Poruka");
                return false;
            }
            if (!dtp2.SelectedDate.HasValue)
            {
                MessageBox.Show("Odaberite validni datum", "Poruka");
                return false;
            }
            if (comboBoxTipTrenera.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite tip trenera", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Validaciju Sudija
        private bool ValidacijaSudije()
        {
            if (dataGridClanoviSudija.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite sudiju", "Poruka");
                return false;
            }
            if (!dtp3.SelectedDate.HasValue)
            {
                MessageBox.Show("Odaberite validni datum", "Poruka");
                return false;
            }
            if (comboBoxSudijaRang.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite rang sudije", "Poruka");
                return false;
            }
            if (comboBoxSudijaTip.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite tip sudije", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Validaciju Igraca za promenu statusa
        private bool ValidacijaIgracaStatusa()
        {
            if (dataGridListaIgraca.SelectedIndex < 0)
            {

                MessageBox.Show("Odaberite zelejnog igraca", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Validaciju Takmicenja
        private bool ValidacijaTakmicenja()
        {
            if (string.IsNullOrWhiteSpace(textBoxNazivTakmicenja.Text))
            {
                MessageBox.Show("Unesite naziv", "Poruka");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxMestoTakmicenja.Text))
            {
                MessageBox.Show("Unesite mesto", "Poruka");
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxTip.Text))
            {
                MessageBox.Show("Unesite tip", "Poruka");
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxPodloga.Text))
            {
                MessageBox.Show("Unesite podlogu", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Validacija za Ucestovanje
        private bool ValidacijaUcestvovanja()
        {
            if (dataGridListaIgraca.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati igraca", "Poruka");
                return false;
            }
            if (dataGridListaTakmicenjaIgraca.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati takmicenje", "Poruka");
                return false;
            }
            if (dtp4.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Morate odabrati vaildno vreme", "Poruka");
                return false;
            }
            if (!dtp4.SelectedDate.HasValue)
            {
                MessageBox.Show("Odaberite validni datum", "Poruka");
                return false;
            }

            return true;
        }
        #endregion


        #region Metoda za Validaciju Titula
        private bool ValidacijaTitula()
        {
            if (dataGridListaSudija.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati sudiju", "Poruka");
                return false;
            }
            if (dataGridDodajTitulu.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati igraca", "Poruka");
                return false;
            }
            if (comboBoxListaTakmicenja.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati takmicenje", "Poruka");
                return false;
            }
            if (comboBoxTitule.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati titulu", "Poruka");
                return false;
            }
            return true;
        }

        #endregion


        #region Metoda za Dodavanje Clanova iz KlaseDal
        private void DodajClana()
        {
            Clanovi c = new Clanovi();
            c.JMBG = textBoxJMBG.Text.Trim();
            c.Prezime = textBoxPrezime.Text.Trim();
            c.ImeRoditelja = textBoxImeR.Text.Trim();
            c.Ime = textBoxIme.Text.Trim();
            c.Adresa = textBoxAdresa.Text.Trim();
            c.Telefon = textBoxTelefon.Text.Trim();
            c.Godiste = int.Parse(textBoxGodiste.Text.Trim());
            c.PosStatus = comboBoxPozicija.Text;

            int rezz = CDal.DodajClana(c);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do greske", "Poruka");
            }
            else
            {
                DodajClanarinu();
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                PrikaziPoslednjiBRCK();
                Resetuj();
                MessageBox.Show("Clan i clanarina su dodati", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Clanova u Clanarinu
        private void DodajClanarinu()
        {
            Clanarine cl = new Clanarine();
            cl.Clanovi_BrCK = int.Parse(textBoxBrckZadnji.Text.Trim());
            cl.BrojUplatnice = textBoxUplatnica.Text.Trim();
            cl.DatumPlacanja = (DateTime)dtp1.SelectedDate;
            cl.Iznos = int.Parse(textBoxIznos.Text.Trim());
            cl.Mesec = comboBoxMesec.Text;
            cl.Godina = int.Parse(textBoxGodina.Text.Trim());

            int rezz = ClDal.UbaciClanarinu(cl);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do greske", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Igraca
        private void DodajIgraca()
        {
            Igraci i = new Igraci();

            Clanovi c = (Clanovi)dataGridClanoviIgraci.SelectedItem;
            i.Clanovi_BrCK = c.BrCK;
            i.Status = comboBoxStatus.Text;
            i.Pozicija = comboBoxPozicijaIgraca.Text;
            i.BrojDresa = int.Parse(textBoxBrDresa.Text.Trim());
            i.Noga = comboBoxNoga.Text;

            int rezz = IDal.DodajIgraca(i);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                MessageBox.Show("Igrac je dodat", "Poruka");
            }
        }
        #endregion


        #region Metode za Dodavenje Trenera
        private void DodajTrenera()
        {
            Treneri t = new Treneri();
            Clanovi c = (Clanovi)dataGridClanoviTreneri.SelectedItem;
            t.Clanovi_BrCK = c.BrCK;
            t.DatumPolaganja = (DateTime)dtp2.SelectedDate;
            t.Tip = comboBoxTipTrenera.Text;

            int rezz = TDal.DodajTrenera(t);
            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                MessageBox.Show("Trener je dodat", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Sudija
        private void DodajSudiju()
        {
            Sudije s = new Sudije();
            Clanovi c = (Clanovi)dataGridClanoviSudija.SelectedItem;
            s.Clanovi_BrCK = c.BrCK;
            s.DatumPolaganja = (DateTime)dtp3.SelectedDate;
            s.Rang = comboBoxSudijaRang.Text;
            s.Tip = comboBoxSudijaTip.Text;

            int rezz = SDal.DodajSudiju(s);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziSudije();
                MessageBox.Show("Sudija je dodat", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Takmicenja
        private void DodajTakmicenja()
        {
            Takmicenja t = new Takmicenja();
            t.Naziv = textBoxNazivTakmicenja.Text.Trim();
            t.Mesto = textBoxMestoTakmicenja.Text.Trim();
            t.Tip = comboBoxTip.Text;
            t.Podloga = comboBoxPodloga.Text;

            int rezz = TaDal.DodajTakmicenja(t);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziListuTakmicenja();
                PrikaziListuTakmicenjaIgraca();
                ResetujTakmicenja();
                MessageBox.Show("Dodato", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Igraca za Ucestovanje
        private void DodajUcestovanja()
        {
            Ucestvovanje u = new Ucestvovanje();
            IgraciApD item = (IgraciApD)dataGridListaIgraca.SelectedItem;
            Takmicenja t = (Takmicenja)dataGridListaTakmicenjaIgraca.SelectedItem;
            u.Igraci_Clanovi_BrCK = item.BrCK;
            u.Takmicenja_RBr = t.RBr;
            u.Datum = (DateTime)dtp4.SelectedDate;

            int rezz = UDal.DodajUcestvovanja(u);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do greske", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                PrikaziPoslednjiBRCK();
                Resetuj();
                MessageBox.Show("Igrac je uspesno dodat za turnir", "Poruka");
            }
        }
        #endregion


        #region Metoda za Dodavanje Titula
        private void DodajTitulu()
        {
            Titule t = new Titule();
            IgraciApD ig = (IgraciApD)dataGridDodajTitulu.SelectedItem;
            SudijaTR su = (SudijaTR)dataGridListaSudija.SelectedItem;
            Takmicenja tr = (Takmicenja)comboBoxListaTakmicenja.SelectedItem;
            t.Ucestvuju_Igraci_Clanovi_BrCK = ig.BrCK;
            t.Ucestvuju_Takmicenja_RBr = tr.RBr;
            t.Naziv = comboBoxTitule.Text;
            t.Dodelio = su.Ime;

            int rezz = TiDal.DodajTitulu(t);

            if (rezz != 0)
            {

                MessageBox.Show("Doslo je do greske", "Poruka");
            }
            else
            {
                PrikaziIgraceBezTitula();
                MessageBox.Show("Titula je uspesno dodata igracu", "Poruka");
            }

        }
        #endregion


        #region Metoda za Prikaz Clanova Igraca
        private void PrikaziClanoveIgraca()
        {
            dataGridClanoviIgraci.Items.Clear();
            List<Clanovi> listaClanovaIgraca = CDal.PrikaziClanoveIgraca();

            foreach (Clanovi list in listaClanovaIgraca)
            {
                dataGridClanoviIgraci.Items.Add(list);
            }
        }
        #endregion


        #region Metoda za Prikaz Clanova Trenera
        private void PrikaziClanoveTrenera()
        {
            dataGridClanoviTreneri.Items.Clear();
            List<Clanovi> listaClanovaTrenera = CDal.PrikaziCLanoveTrenera();

            foreach (Clanovi list in listaClanovaTrenera)
            {
                dataGridClanoviTreneri.Items.Add(list);
            }
        }
        #endregion


        #region Metoda za Prikaz Clanova Sudija
        private void PrikaziClanoveSudija()
        {
            dataGridClanoviSudija.Items.Clear();
            List<Clanovi> ListaSudija = CDal.PrikaziClanoveSudija();
            foreach (Clanovi lista in ListaSudija)
            {
                dataGridClanoviSudija.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Aktivnih Igraca
        private void PrikaziIgrace()
        {
            dataGridListaIgraca.Items.Clear();
            List<IgraciApD> listaAktivnihIgraca = IgDal.PrikaziAktivneIgrace();

            foreach (IgraciApD lista in listaAktivnihIgraca)
            {
                dataGridListaIgraca.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Promenu Statusa Igraca
        private void PromeniStatusIgraca()
        {
            if (dataGridListaIgraca.SelectedIndex > -1)
            {
                Igraci i = new Igraci();

                IgraciApD ig = (IgraciApD)dataGridListaIgraca.SelectedItem;

                i.Clanovi_BrCK = ig.BrCK;
                i.Status = comboBoxPromeniStatusIgraca.Text;

                int rezz = IDal.PromeniStatus(i);

                if (rezz != 0)
                {
                    MessageBox.Show("Greska", "Poruka");
                }
                else
                {
                    PrikaziClanoveIgraca();
                    PrikaziClanoveTrenera();
                    PrikaziClanoveSudija();
                    PrikaziIgrace();
                    MessageBox.Show("Status je promenjen", "Poruka");
                }
            }
        }
        #endregion


        #region Metoda za Promenu Igraca
        private void PromeniIgraca()
        {
            if (dataGridListaIgraca.SelectedIndex > -1)
            {
                Igraci i = new Igraci();

                IgraciApD ig = (IgraciApD)dataGridListaIgraca.SelectedItem;

                i.Clanovi_BrCK = ig.BrCK;

                int rezz = IDal.PromeniIgraca(i);

                if (rezz != 0)
                {
                    MessageBox.Show("Greska", "Poruka");
                }
                else
                {
                    PrikaziClanoveIgraca();
                    PrikaziClanoveTrenera();
                    PrikaziClanoveSudija();
                    PrikaziIgrace();
                    MessageBox.Show("Status je promenjen", "Poruka");
                }
            }
        }
        #endregion


        #region Metoda za Promenu Tip Trenera
        private void PromeniTipTrenera()
        {
            Treneri t = new Treneri();

            TreneriA tr = (TreneriA)dataGridListaTrenera.SelectedItem;

            t.Clanovi_BrCK = tr.BrCK;
            t.Tip = comboBoxPromeniTipTrenera.Text;

            int rezz = TDal.PromeniTipTrenera(t);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                MessageBox.Show("Tip trenera je promenjen", "Poruka");
            }
        }
        #endregion


        #region Metoda za Promeni Tipa Sudije
        private void PromeniTipSudije()
        {
            Sudije s = new Sudije();

            SudijaTR tr = (SudijaTR)dataGridListaSudija.SelectedItem;

            s.Clanovi_BrCK = tr.BrCK;
            s.Tip = comboBoxSudijaTipLista.Text;

            int rezz = SDal.PromeniTipSudije(s);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                PrikaziSudije();
                MessageBox.Show("Tip sudije je promenjen", "Poruka");
            }
        }
        #endregion


        #region Metoda za Promenu Ranga Sudije
        private void PromeniRangSudije()
        {
            Sudije s = new Sudije();

            SudijaTR tr = (SudijaTR)dataGridListaSudija.SelectedItem;

            s.Clanovi_BrCK = tr.BrCK;
            s.Rang = comboBoxSudijaRangLista.Text;

            int rezz = SDal.PromeniRangSudije(s);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();
                PrikaziIgrace();
                PrikaziTrenere();
                PrikaziSudije();
                MessageBox.Show("Rang sudije je promenjen", "Poruka");
            }
        }
        #endregion


        #region Metoda za Prikazivanje Trenera
        private void PrikaziTrenere()
        {
            dataGridListaTrenera.Items.Clear();
            List<TreneriA> listaTrenera = TDal.PrikaziListuTrenera();

            foreach (TreneriA lista in listaTrenera)
            {
                dataGridListaTrenera.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Sudija
        private void PrikaziSudije()
        {

            List<SudijaTR> listaSudija = SDal.PrikaziSudije();
            dataGridListaSudija.Items.Clear();
            foreach (SudijaTR item in listaSudija)
            {
                dataGridListaSudija.Items.Add(item);
            }
        }
        #endregion


        #region Metoda za Prikazivanje Poslednjeg ID Clana
        private void PrikaziPoslednjiBRCK()
        {
            textBoxBrckZadnji.Clear();
            List<Clanovi> listaBrck = CDal.PrikaziBrCK();

            foreach (Clanovi lista in listaBrck)
            {
                textBoxBrckZadnji.Text = lista.ToString();
            }
        }
        #endregion


        #region Metoda za Prikaz Listu Takmicenja
        private void PrikaziListuTakmicenja()
        {
            dataGridListaTakmicenja.Items.Clear();
            List<Takmicenja> listaTakmicenja = TaDal.PrikaziListuTakmicenja();

            foreach (Takmicenja lista in listaTakmicenja)
            {
                dataGridListaTakmicenja.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Liste Takmicenja Igraca
        private void PrikaziListuTakmicenjaIgraca()
        {
            dataGridListaTakmicenjaIgraca.Items.Clear();
            comboBoxListaTakmicenja.Items.Clear();
            List<Takmicenja> listaTakmicenja = TaDal.PrikaziListuTakmicenja();

            foreach (Takmicenja lista in listaTakmicenja)
            {
                dataGridListaTakmicenjaIgraca.Items.Add(lista);
                comboBoxListaTakmicenja.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Igraca Bez Titule
        private void PrikaziIgraceBezTitula()
        {
            dataGridDodajTitulu.Items.Clear();
            List<IgraciApD> listaigraca = IgDal.PrikaziIgraceBezTitule(comboBoxListaTakmicenja.SelectedItem.ToString());
            foreach (IgraciApD list in listaigraca)
            {
                dataGridDodajTitulu.Items.Add(list);
            }
        }
        #endregion


        #region Metoda za Resetovanje Nakon Unosa
        private void Resetuj()
        {
            textBoxJMBG.Clear();
            textBoxIme.Clear();
            textBoxImeR.Clear();
            textBoxPrezime.Clear();
            textBoxAdresa.Clear();
            textBoxTelefon.Clear();
            textBoxGodiste.Clear();
            textBoxUplatnica.Clear();
            textBoxIznos.Clear();
            comboBoxPozicija.SelectedIndex = -1;
            comboBoxMesec.SelectedIndex = -1;
        }
        #endregion


        #region Metoda za Resetovanje Nakon Unosa Takmicenja
        private void ResetujTakmicenja()
        {
            textBoxNazivTakmicenja.Clear();
            textBoxMestoTakmicenja.Clear();
            comboBoxTip.SelectedIndex = -1;
            comboBoxPodloga.SelectedIndex = -1;
        }
        #endregion


        #region Windows Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziClanoveIgraca();
            PrikaziClanoveTrenera();
            PrikaziClanoveSudija();
            PrikaziIgrace();
            PrikaziTrenere();
            PrikaziSudije();
            PrikaziPoslednjiBRCK();
            PrikaziListuTakmicenja();
            PrikaziListuTakmicenjaIgraca();
            //PrikaziIgraceBezTitula();

            dtp1.SelectedDate = DateTime.Today;
            dtp2.SelectedDate = DateTime.Today;
            dtp3.SelectedDate = DateTime.Today;
            dtp4.SelectedDate = DateTime.Today;
            textBoxGodina.Text = DateTime.Today.ToString("yyyy");
        }
        #endregion


        #region Dugme Uclani Clana
        private void buttonUclani_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaClanova() == true)
            {
                DodajClana();
            }
        }
        #endregion


        #region Dugme Dodaj Igraca
        private void buttonDodajIgraca_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaIgraca() == true)
            {             
                DodajIgraca();
                comboBoxStatus.SelectedIndex = -1;
                comboBoxPozicijaIgraca.SelectedIndex = -1;
                textBoxBrDresa.Clear();
                comboBoxNoga.SelectedIndex = -1;
            }
        }
        #endregion


        #region Dugme Dodaj Trenera
        private void buttonDodajTrenera_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaTrenera() == true)
            {
                DodajTrenera();
                comboBoxTipTrenera.SelectedIndex = -1;
            }
        }
        #endregion


        #region Dugme Dodaj Sudiju
        private void buttonDodajSudiju_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaSudije() == true)
            {
                DodajSudiju();
                comboBoxSudijaRang.SelectedIndex = -1;
                comboBoxSudijaTip.SelectedIndex = -1;
            }
        }
        #endregion


        #region Dugme Promeni Status Igraca
        private void buttonPromeniStatusIgraca_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaIgracaStatusa() == true)
            {
                PromeniStatusIgraca();
            }
        }
        #endregion


        #region Dugme za Promenu Pozicije Igraca
        private void buttonPromeniPoziciju_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaIgracaStatusa() == true)
            {
                PromeniIgraca();
            }
        }
        #endregion


        #region Dugme za Promenu Tipa Trenera
        private void buttonPromeniTIpTrenera_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaTrenera.SelectedIndex > -1)
            {
                PromeniTipTrenera();
            }
            else
            {
                MessageBox.Show("Odaberite trenera", "Poruka");
            }
        }
        #endregion


        #region Dugme za Promenu Tip Sudije
        private void buttonPromeniTipSudije_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaSudija.SelectedIndex > -1)
            {
                PromeniTipSudije();
            }
            else
            {
                MessageBox.Show("Odaberite sudiju sa liste", "Poruke");
            }
        }
        #endregion


        #region Dugme za Promenu Ranga Sudije
        private void buttonPromeniRangSudije_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaSudija.SelectedIndex > -1)
            {
                PromeniRangSudije();
            }
            else
            {
                MessageBox.Show("Odaberite sudiju sa liste", "Poruke");
            }
        }
        #endregion


        #region Dugme za Dodavanje Takmicenja
        private void buttonDodajTakmicenja_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaTakmicenja() == true)
            {
                DodajTakmicenja();
            }
        }
        #endregion


        #region Dugme za Prikazivanje svih clanova
        private void buttonPrikazSvihClanova_Click(object sender, RoutedEventArgs e)
        {
            PrikazClanova pr = new PrikazClanova();

            if (pr.ShowDialog() == true)
            {
                PrikaziIgrace();
                PrikaziSudije();
                PrikaziTrenere();
                PrikaziClanoveIgraca();
                PrikaziClanoveTrenera();
                PrikaziClanoveSudija();

            }
        }
        #endregion


        #region Dugme za Promenu Takmicenja
        private void buttonPromeniTakmicenja_Click(object sender, RoutedEventArgs e)
        {
            PrikazTakmicenja pt = new PrikazTakmicenja();

            if (pt.ShowDialog() == true)
            {
                PrikaziListuTakmicenja();
                PrikaziListuTakmicenjaIgraca();
            }
        }
        #endregion


        #region Event za Tab Kontrolu
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IgraciTab.IsSelected = true;
        }
        #endregion


        #region Event za Selekciju Listu Igraca
        private void dataGridListaTakmicenjaIgraca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridListaTakmicenjaIgraca.SelectedIndex > -1)
            {
                buttonOdrediIgrace.IsEnabled = true;
            }
        }
        #endregion


        #region Dugme za Dodavanje Igraca za Ucestovanje
        private void buttonOdrediIgrace_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaUcestvovanja() == true)
            {
                DodajUcestovanja();
            }
        }
        #endregion


        #region Dugme za Prikazivanje Igraca koji Ucestuju na Turniru
        private void buttonPrikaziUcesnike_Click(object sender, RoutedEventArgs e)
        {
            PrikaziUcesnike Pu = new PrikaziUcesnike();

            if (Pu.ShowDialog() == true)
            {
                PrikaziIgrace();
                PrikaziClanoveIgraca();
                PrikaziListuTakmicenja();
                PrikaziListuTakmicenjaIgraca();
            }
        }
        #endregion


        #region Dugme za Dodelivanje Titule Igracu
        private void buttonDodeli_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacijaTitula() == true)
            {
                DodajTitulu();
            }
        }
        #endregion


        #region Event za Promenu Tab Kontrole
        private void TabItem_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            SudijeTab.IsSelected = true;
        }
        #endregion


        #region Event za Selekciju Igraca bez Titule
        private void comboBoxListaTakmicenja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxListaTakmicenja.SelectedIndex > -1)
            {
                PrikaziIgraceBezTitula();
            }
        }
        #endregion


        #region Dugme za Prikaz Igraca sa Titulom
        private void buttonPrikazIgraca_Click(object sender, RoutedEventArgs e)
        {
            PrikaziIgraceSaTitulom prs = new PrikaziIgraceSaTitulom();

            if (prs.ShowDialog() == true)
            {
                comboBoxListaTakmicenja.SelectedIndex = -1;
                comboBoxTitule.SelectedIndex = -1;
            }
        }
        #endregion


        #region Dugme za Otvaranje Prozora za unos Dobavljaca
        private void buttonDobavljaci_Click(object sender, RoutedEventArgs e)
        {
            Dobavljaci d = new Dobavljaci();
            d.ShowDialog();
        }
        #endregion


        #region Dugme za Otvaranje Prozora za unos Nabavke
        private void buttonDodajNabavka_Click(object sender, RoutedEventArgs e)
        {
            OpremaZaNabavku op = new OpremaZaNabavku();
            op.ShowDialog();
        }
        #endregion


        #region Dugme za Otvaranje Prozora za Narucivanje Opreme
        private void buttonNaruciOpremu_Click(object sender, RoutedEventArgs e)
        {
            NaruciOpremu op = new NaruciOpremu();
            op.ShowDialog();
        }
        #endregion


        #region Dugme za Otvaranje Prozora za Zaduzivanje Opreme
        private void buttonZaduziOpremu_Click(object sender, RoutedEventArgs e)
        {
            ZaduziOpremu zo = new ZaduziOpremu();
            zo.ShowDialog();
        }
    }
}
#endregion