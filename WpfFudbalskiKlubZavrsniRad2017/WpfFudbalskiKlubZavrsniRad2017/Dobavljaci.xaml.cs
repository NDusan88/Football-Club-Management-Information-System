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
    /// Interaction logic for Dobavljaci.xaml
    /// </summary>
    public partial class Dobavljaci : Window
    {
        #region Klase Dal
        DobavljaciDal DDal = new DobavljaciDal();
        #endregion
        public Dobavljaci()
        {
            InitializeComponent();
        }

        #region Metoda za Prikaz Dobavljaca
        private void PrikaziDobavljace()
        {

            dataGridDobavljac.Items.Clear();
            List<Dobavljac> listaDobavljaca = DDal.PrikaziListuDobavljaca();

            foreach (Dobavljac lista in listaDobavljaca)
            {
                dataGridDobavljac.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Dodavanja Dobavljaca
        private void DodajDobavljaca()
        {
            Dobavljac d = new Dobavljac();
            d.Naziv = textBoxNaziv.Text.Trim();
            d.PIB = int.Parse(textBoxPib.Text.Trim());
            d.Delatnost = textBoxDelatnost.Text.Trim();
            d.Adresa = textBoxAdresa.Text.Trim();
            d.Telefon = textBoxTelefon.Text.Trim();

            int rezz = DDal.DodajDobavljaca(d);

            if (rezz == 0)
            {
                PrikaziDobavljace();
                MessageBox.Show("Dobavljac je uspesno sacuvan", "Poruka");
            }
            else
            {
                MessageBox.Show("Doslo je do greske", "Poruka");
            }
        }
        #endregion


        #region Metoda za Brisanje Dobavljaca
        private void ObrisiDobavljaca()
        {
            Dobavljac d = new Dobavljac();
            Dobavljac item = (Dobavljac)dataGridDobavljac.SelectedItem;
            d.DobavljaciId = item.DobavljaciId;

            int rezz = DDal.ObrisiDobavljaca(d);

            if (rezz == 0)
            {
                PrikaziDobavljace();
                MessageBox.Show("Uspenso obrisano", "Poruka");
            }
            else
            {
                MessageBox.Show("Doslo je do greske", "Poruka");
            }
        }
        #endregion


        #region Metoda za Validaciju podataka
        private bool Validacija()
        {
            int broj;
            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text))
            {
                MessageBox.Show("Unesite naziv","Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPib.Text))
            {
                MessageBox.Show("Unesite PIB", "Poruka");
                return false;
            }
            if (!int.TryParse(textBoxPib.Text, out broj))
            {

                MessageBox.Show("Unesite ceo broj", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDelatnost.Text))
            {
                MessageBox.Show("Unesite delatnost", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAdresa.Text))
            {
                MessageBox.Show("Unesite adresu", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
            {
                MessageBox.Show("Unesite Telefon", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Restovanje nakon unosa podataka
        private void Resetuj()
        {
            textBoxNaziv.Clear();
            textBoxPib.Clear();
            textBoxDelatnost.Clear();
            textBoxAdresa.Clear();
            textBoxTelefon.Clear();
            textBoxNaziv.Focus();
        }
        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziDobavljace();
        }
        #endregion


        #region Button za Dodavanje Dobavljaca
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                DodajDobavljaca();
                Resetuj();
            }
        }
        #endregion


        #region Button Nazad
        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion


        #region Button za Brisanje Dobavljaca
        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDobavljac.SelectedIndex > -1)
            {
                if (MessageBox.Show("Potvrdite brisanje?", "Obavestenje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    ObrisiDobavljaca();
                }
            }
            else
            {
                MessageBox.Show("Niste selektovalo dobavljaca", "Poruka");
            }
        }
        #endregion
    }
}
