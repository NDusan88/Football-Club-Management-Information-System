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
    /// Interaction logic for NaruciOpremu.xaml
    /// </summary>
    public partial class NaruciOpremu : Window
    {
        #region Klase Dal
        NabavljaDal NDal = new NabavljaDal();
        DobavljaciDal DDal = new DobavljaciDal();
        OpremaDal ODal = new OpremaDal();
        #endregion
        public NaruciOpremu()
        {
            InitializeComponent();
        }
        
        #region Metoda za Prikazivanje Dobavljaca
        private void PrikaziDobavljace()
        {
            List<Dobavljac> listadobavljaca = DDal.PrikaziListuDobavljaca();

            foreach (Dobavljac lista in listadobavljaca)
            {
                comboBoxDobavljaci.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Narucivanje Opreme
        private void NaruciOpreme()
        {
            Nabavlja n = new Nabavlja();

            Dobavljac d = (Dobavljac)comboBoxDobavljaci.SelectedItem;
            Oprema o = (Oprema)dataGridListaOprema.SelectedItem;

            n.Oprema_SifOpreme = o.SifOpreme;
            n.Dobavljaci_SifDobavljaca = d.DobavljaciId;

            n.Datum = (DateTime)dtp1.SelectedDate;
            n.Kolicina = int.Parse(textBoxKolicina.Text.Trim());

            int rezz = NDal.NarucOpremu(n);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do grekse", "Poruka");
            }
            else
            {
                PrikaziOpreme();
                MessageBox.Show("Uspesno Dodato", "Poruka");
            }
        }
        #endregion


        #region Metoda za Validaciju unosa podataka
        private bool Validacija()
        {
            int broj;
            if (comboBoxDobavljaci.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite dobavljaca", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxKolicina.Text))
            {

                MessageBox.Show("Odaberite kolicinu", "Poruka");
                return false;
            }
            if (!int.TryParse(textBoxKolicina.Text, out broj))
            {

                MessageBox.Show("Mora biti ceo broj", "Poruka");
                return false;
            }
            if (!dtp1.SelectedDate.HasValue)
            {
                MessageBox.Show("Odaberite datum", "Poruka");
                return false;
            }
            if (dtp1.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Odaberite validan datum", "Poruka");
                return false;
            }
            if (dataGridListaOprema.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite opremu", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Prikaz Opreme u datagrid-u
        private void PrikaziOpreme()
        {
            dataGridListaOprema.Items.Clear();
            List<Oprema> listaOprema = ODal.ListaOpreme();
            foreach (Oprema lista in listaOprema)
            {
                dataGridListaOprema.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Resetovanje nakon unosa podataka
        private void Resetuj()
        {
            comboBoxDobavljaci.SelectedIndex = -1;
            textBoxKolicina.Clear();
        }
        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziDobavljace();
            PrikaziOpreme();
            dtp1.SelectedDate = DateTime.Today;
        }
        #endregion


        #region Button za Narucivanje Opreme
        private void buttonNaruci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                NaruciOpreme();
                Resetuj();
            }
        }
        #endregion


        #region Button za Nazad
        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}
