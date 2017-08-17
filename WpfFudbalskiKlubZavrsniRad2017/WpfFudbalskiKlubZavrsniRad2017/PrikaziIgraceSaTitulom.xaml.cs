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
    /// Interaction logic for PrikaziIgraceSaTitulom.xaml
    /// </summary>
    public partial class PrikaziIgraceSaTitulom : Window
    {
        #region Klasa Dal
        TituleDal TDal = new TituleDal();
        #endregion
        public PrikaziIgraceSaTitulom()
        {
            InitializeComponent();
        }

        #region Metoda za Prikazivanje Listu Igraca sa Titulom
        private void PrikaziListuIgraca()
        {

            dataGridIgraciSaTitulom.Items.Clear();
            List<IgraciSaTitulom> listaIgraca = TDal.PrikaziListuIgraca();

            foreach (IgraciSaTitulom lista in listaIgraca)
            {
                dataGridIgraciSaTitulom.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Filtraciju Igraca po Imenu
        private void Filtriraj()
        {
            dataGridIgraciSaTitulom.Items.Clear();

            IgraciSaTitulom i = new IgraciSaTitulom();
            i.Ime = textBoxPronadji.Text;
            List<IgraciSaTitulom> listaClanova = TDal.FiltrirajIgraca(textBoxPronadji.Text);
            foreach (IgraciSaTitulom lista in listaClanova)
            {
                dataGridIgraciSaTitulom.Items.Add(lista);
            }
        }
        #endregion


        #region Metoda za Brisanje Titule sa Igraca
        private void Obrisi()
        {
            IgraciSaTitulom i = new IgraciSaTitulom();

            IgraciSaTitulom ig = (IgraciSaTitulom)dataGridIgraciSaTitulom.SelectedItem;

            i.BrCK = ig.BrCK;

            int rezz = TDal.ObrisiIgraca(i);

            if (rezz != 0)
            {               
                MessageBox.Show("Doslo je do grekse", "Poruka");
            }
            else
            {
                PrikaziListuIgraca();
                MessageBox.Show("Uspesno obrisano", "Poruka");
            }
        }

        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziListuIgraca();
        }
        #endregion


        #region TextBox Selection Change za Filtraciju po Imenu
        private void textBoxPronadji_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtriraj();
        }
        #endregion


        #region Button Obrisi
        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridIgraciSaTitulom.SelectedIndex > -1)
            {
                if (MessageBox.Show("Potvrdite brisanje?", "Obavestenje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    Obrisi();
                }
            }
            else
            {
                MessageBox.Show("Odaberite Igraca", "Poruka");
            }
        }
        #endregion


        #region Button Nazad
        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        #endregion
    }
}
