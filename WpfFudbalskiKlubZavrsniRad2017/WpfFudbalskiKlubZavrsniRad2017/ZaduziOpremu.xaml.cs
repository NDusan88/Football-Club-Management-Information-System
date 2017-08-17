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
using System.Windows.Shapes;
using WpfFudbalskiKlubZavrsniRad2017.Klase;
using WpfFudbalskiKlubZavrsniRad2017.KlaseDal;

namespace WpfFudbalskiKlubZavrsniRad2017
{
    /// <summary>
    /// Interaction logic for ZaduziOpremu.xaml
    /// </summary>
    public partial class ZaduziOpremu : Window
    {
        #region Klase Dal
        OpremaDal ODal = new OpremaDal();
        ClanoviDal CDal = new ClanoviDal();
        ZaduzujuDal ZDal = new ZaduzujuDal();
        NabavljaDal NDal = new NabavljaDal();
        #endregion
        public ZaduziOpremu()
        {
            InitializeComponent();
        }

        #region Metoda za Validaciju Unosa Podataka
        private bool Validacija()
        {
            int broj;
            if (dataGridClanoviIgraci.SelectedIndex < 0)
            {
                MessageBox.Show("Niste odabrali clana", "Poruka");
                return false;
            }
            if (dataGridListaOprema.SelectedIndex < 0)
            {
                MessageBox.Show("Niste odabrali opremu", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxKolicina.Text))
            {
                MessageBox.Show("Niste odabrali kolicinu", "Poruka");
                return false;
            }
            if (!int.TryParse(textBoxKolicina.Text, out broj))
            {
                MessageBox.Show("Kolicina mora biti ceo broj", "Poruka");
                return false;
            }
            if (dtp1.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Niste odabrali validan datum", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Prikaz Opreme
        private void PrikaziOpremu()
        {
            dataGridListaOprema.Items.Clear();
            List<Oprema> listaOprema = ODal.ListaOpremeZaZaduzivanje();

            foreach (Oprema lista in listaOprema)
            {
                dataGridListaOprema.Items.Add(lista);
            }
        }

        #endregion


        #region Metoda za Prikaz Igraca
        private void PrikaziIgrace()
        {
            dataGridClanoviIgraci.Items.Clear();
            List<Clanovi> ListaIgraca = CDal.PrikazIgraca();
            foreach (Clanovi lista in ListaIgraca)
            {
                dataGridClanoviIgraci.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Sudija
        private void PrikaziSudija()
        {
            dataGridClanoviIgraci.Items.Clear();
            List<Clanovi> ListaSudija = CDal.PrikazSudija();
            foreach (Clanovi lista in ListaSudija)
            {
                dataGridClanoviIgraci.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Prikaz Trenera
        private void PrikaziTrenere()
        {
            dataGridClanoviIgraci.Items.Clear();
            List<Clanovi> ListaTrenera = CDal.PrikazTrenera();
            foreach (Clanovi lista in ListaTrenera)
            {
                dataGridClanoviIgraci.Items.Add(lista);
            }
        }

        #endregion


        #region Metoda za Azuriranje Kolicine Nakon zaduzivanje Opreme
        private void AzurirajKolicinu()
        {
            Nabavlja n = new Nabavlja();
            Oprema o = (Oprema)dataGridListaOprema.SelectedItem;
            n.Kolicina = int.Parse(textBoxKolicina.Text.Trim());
            n.Oprema_SifOpreme = o.SifOpreme;

            int rezz = NDal.AzuriajOpremu(n);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do grekse", "Poruka");
            }         
        }
        #endregion


        #region Metoda za Zaduzivanje Opreme
        private void ZaduziOpreme()
        {
            Zaduzuju z = new Zaduzuju();
            Clanovi item = (Clanovi)dataGridClanoviIgraci.SelectedItem;
            Oprema items = (Oprema)dataGridListaOprema.SelectedItem;
            z.Clanovi_BRCK = item.BrCK;
            z.Oprema_SifOpreme = items.SifOpreme;
            z.Datum = (DateTime)dtp1.SelectedDate;
            z.Kolicina = int.Parse(textBoxKolicina.Text.Trim());

            int rezz = ZDal.ZaduziOpremu(z);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do grekse", "Poruka");
            }
            else
            {
                AzurirajKolicinu();
                PrikaziOpremu();
                MessageBox.Show($"Clan { item.Ime} je zaduzio opremu", "Poruka");
            }
        }

        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziOpremu();
            dtp1.SelectedDate = DateTime.Today;
        }
        #endregion


        #region ComboBox Selection change za Prikaz Igraca, Sudija, Trenera
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                PrikaziIgrace();
            }
            if (comboBox.SelectedIndex == 1)
            {
                PrikaziSudija();
            }
            if (comboBox.SelectedIndex == 2)
            {
                PrikaziTrenere();
            }
        }
        #endregion


        #region Button Zaduzi Opremu
        private void buttonZaduzi_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                ZaduziOpreme();
                textBoxKolicina.Clear();
            }
        }
        #endregion


        #region Button Nazad
        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}         
