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
using WpfFudbalskiKlubZavrsniRad2017.KlaseDal;
using WpfFudbalskiKlubZavrsniRad2017.Klase;

namespace WpfFudbalskiKlubZavrsniRad2017
{
    /// <summary>
    /// Interaction logic for PrikazTakmicenja.xaml
    /// </summary>
    public partial class PrikazTakmicenja : Window
    {

        #region Klase Dal
        TakmicenjaDal TaDal = new TakmicenjaDal();

        #endregion

        public PrikazTakmicenja()
        {
            InitializeComponent();
        }

        #region Metoda za Prikaz Takmicenja
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


        #region Metoda za Filtraciju Takmicenja
        private void FiltrirajTakmicenja()
        {
            dataGridListaTakmicenja.Items.Clear();

            Takmicenja t = new Takmicenja();
            t.Naziv = textBoxPronadji.Text;
            List<Takmicenja> listaTakmicenja = TaDal.FiltrirajTakmicenja(textBoxPronadji.Text);
            foreach (Takmicenja lista in listaTakmicenja)
            {
                dataGridListaTakmicenja.Items.Add(lista);
            }
        }

        #endregion


        #region Metoda za Azuriranje Takmicenja
        private void PromeniTakmicenja()
        {
            if (dataGridListaTakmicenja.SelectedIndex > -1)
            {
                Takmicenja t = (Takmicenja)dataGridListaTakmicenja.SelectedItem;

                t.RBr = t.RBr;
                t.Naziv = textBoNaziv.Text.Trim();
                t.Tip = textBoxTip.Text.Trim();
                t.Mesto = textBoxMesto.Text.Trim();
                t.Podloga = comboBoxPodloga.Text;

                int rezz = TaDal.PromeniTakmicenja(t);

                if (rezz != 0)
                {
                    MessageBox.Show("Greska", "Poruka");
                }
                else
                {
                    PrikaziListuTakmicenja();
                    MessageBox.Show("Uspesno Azuriranje", "Poruka");
                }
            }
        }

        #endregion


        #region Metoda za Brisanje Takmicenja
        private void ObrisiTakmicenja()
        {
            Takmicenja t = (Takmicenja)dataGridListaTakmicenja.SelectedItem;
            t.RBr = t.RBr;

            int rezz = TaDal.ObrisiTakmicenja(t);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziListuTakmicenja();
                MessageBox.Show("Uspesno obrisan", "Poruka");
            }
        }
        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziListuTakmicenja();
        }
        #endregion


        #region DataGrid SelectonChange 
        private void dataGridListaTakmicenja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridListaTakmicenja.SelectedIndex > -1)
            {
                Takmicenja t = (Takmicenja)dataGridListaTakmicenja.SelectedItem;

                textBoNaziv.Text = t.Naziv;
                textBoxTip.Text = t.Tip;
                textBoxMesto.Text = t.Mesto;
                comboBoxPodloga.Text = t.Podloga;
            }
        }
        #endregion


        #region Button za Promenu Takmicenja
        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaTakmicenja.SelectedIndex > -1)
            {
                PromeniTakmicenja();
            }
            else
            {
                MessageBox.Show("Odaberite listu za izmenu","Poruka");
            }
        }
        #endregion


        #region TextBox Selection Change za Filtraciju Takmicenja
        private void textBoxPronadji_TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrirajTakmicenja();
        }
        #endregion


        #region Button Obrisi Takmicenja
        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaTakmicenja.SelectedIndex > -1)
            {
                if (MessageBox.Show("Potvrdite brisanje?", "Obavestenje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    ObrisiTakmicenja();
                }
            }
            else
            {
                MessageBox.Show("Odaberite listu za brisanje", "Poruka");
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
