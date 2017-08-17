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
    /// Interaction logic for OpremaZaNabavku.xaml
    /// </summary>
    public partial class OpremaZaNabavku : Window
    {
        #region Klasa Dal
        OpremaDal ODal = new OpremaDal();
        #endregion
        public OpremaZaNabavku()
        {
            InitializeComponent();
        }


        #region Metoda za Validaciju unosa podataka
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxTip.Text))
            {
                MessageBox.Show("Unesite Tip Opreme", "Poruka");
                return false;
            }
            if (comboBoxProizvodjac.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite proizvodjaca", "Poruka");
                return false;
            }
            if (comboBoxBroj.SelectedIndex < 0)
            {

                MessageBox.Show("Odaberite broj", "Poruka");
                return false;
            }
            if (comboBoxBoja.SelectedIndex < 0)
            {

                MessageBox.Show("Odaberite boju", "Poruka");
                return false;
            }
            return true;
        }
        #endregion


        #region Metoda za Dodavanje Opreme
        private void DodajOpremu()
        {
            Oprema o = new Oprema();
            o.Tip = textBoxTip.Text.Trim();
            o.Proizvodjac = comboBoxProizvodjac.Text;
            o.Broj = int.Parse(comboBoxBroj.Text);
            o.Boja = comboBoxBoja.Text;

            int rezz = ODal.DodajOpremu(o);

            if (rezz != 0)
            {
                MessageBox.Show("Doslo je do grekse", "Poruka");
            }
            else
            {
                PrikaziListu();
                MessageBox.Show("Uspesno Dodato", "Poruka");
            }
        }
        #endregion


        #region Metoda za Prikazivanje Liste Opreme
        private void PrikaziListu()
        {
            dataGridListaOprema.Items.Clear();
            List<Oprema> ListaOpreme = ODal.ListaOpreme();

            foreach (Oprema Lista in ListaOpreme)
            {
                dataGridListaOprema.Items.Add(Lista);
            }
        }
        #endregion


        #region Metoda za Resetovanje nakon unosa podataka
        private void Resetuj()
        {
            textBoxTip.Clear();
            comboBoxProizvodjac.SelectedIndex = -1;
            comboBoxBroj.SelectedIndex = -1;
            comboBoxBoja.SelectedIndex = -1;
            textBoxTip.Clear();
        }
        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziListu();
        }
        #endregion


        #region Button za Dodavanje Opreme
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                DodajOpremu();
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
