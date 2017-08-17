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
    /// Interaction logic for PrikazClanova.xaml
    /// </summary>
    public partial class PrikazClanova : Window
    {
        #region Klasa Dal
        ClanoviDal CDal = new ClanoviDal();        
        int broj;
        #endregion

        #region Metoda za Validaciju unosa podataka
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxIme.Text))
            {
                MessageBox.Show("Unesite ime", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Unesite Prezime", "Poruka");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAdresa.Text))
            {
                MessageBox.Show("Unesite Adresu", "Poruka");
                return false;
            }
            if (int.TryParse(textBoJMBG.Text, out broj))
            {
                MessageBox.Show("Morate uneti ceo broj", "Poruka");
                textBoJMBG.Clear();
                textBoJMBG.Focus();
                return false;
            }
            if (textBoJMBG.Text.Length < 13)
            {
                MessageBox.Show("JMBG mora imati 13 karaktera", "Poruka");
                textBoJMBG.Focus();
                return false;
            }
            if (textBoJMBG.Text.Length > 13)
            {
                MessageBox.Show("JMBG mora imati 13 karaktera", "Poruka");
                textBoJMBG.Focus();
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


        #region Metoda za Prikaz Clanova
        public PrikazClanova()
        {
            InitializeComponent();
        }
        #endregion


        #region Metoda za Prikazivanje Svh Clanova
        private void PrikaziSveClanove()
        {
            List<Clanovi> listaClanova = CDal.PrikazSvihClanova();
            dataGridClanoviIgraci.Items.Clear();

            foreach (Clanovi lista in listaClanova)
            {
                dataGridClanoviIgraci.Items.Add(lista);
            }
        }
        #endregion


        #region  Metoda za Azuriranje Clanova
        private void PromeniClana()
        {
            if (dataGridClanoviIgraci.SelectedIndex > -1)
            {
                Clanovi c = (Clanovi)dataGridClanoviIgraci.SelectedItem;
                c.Clanovi_BrCK = c.BrCK;
                c.PosStatus = comboBoxPozicija.Text;
                c.Ime = textBoxIme.Text;
                c.Prezime = textBoxPrezime.Text.Trim();
                c.JMBG = textBoJMBG.Text.Trim();
                c.Adresa = textBoxAdresa.Text.Trim();
                c.Telefon = textBoxTelefon.Text.Trim();

                int rezz = CDal.PromeniPoziciju(c);

                if (rezz == 0)
                {
                    PrikaziSveClanove();
                    MessageBox.Show("Clan je uspesno promenjen", "Poruka");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske", "Poruka");
                }
            }
        }
        #endregion


        #region Metoda za Brisanje Clanova
        //private void ObrisiClana()
        //{
        //    if (dataGridClanoviIgraci.SelectedIndex > -1)
        //    {
        //        Clanovi c = new Clanovi();
        //        Clanovi cl = (Clanovi)dataGridClanoviIgraci.SelectedItem;
        //        c.BrCK = cl.BrCK;
        //        c.Clanovi_BrCK = cl.BrCK;

        //        int rezz = CDal.ObrisiClana(c);

        //        if (rezz == 0)
        //        {
        //            PrikaziSveClanove();
        //            MessageBox.Show("Clan je uspesno obrisan", "Poruka");
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Clan ne moze biti obrisan jer ucetvuje na takmicenju ili ima Titulu igraca", "Poruka");
        //        }
        //    }
        //}
        #endregion


        #region Metoda za Pretragu Clanova po Imenu
        private void FiltrirajClana()
        {
            dataGridClanoviIgraci.Items.Clear();

            Clanovi c = new Clanovi();
            c.Ime = textBoxPronadji.Text;
            List<Clanovi> listaClanova = CDal.FiltrirajClana(textBoxPronadji.Text);
            foreach (Clanovi lista in listaClanova)
            {
                dataGridClanoviIgraci.Items.Add(lista);
            }
        }
        #endregion


        #region Windows_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziSveClanove();
        }
        #endregion


        #region Selection Changed Event za Prikaz Clanova
        private void dataGridClanoviIgraci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridClanoviIgraci.SelectedIndex > -1)
            {
                Clanovi c = (Clanovi)dataGridClanoviIgraci.SelectedItem;
                textBoxIme.Text = c.Ime;
                textBoxPrezime.Text = c.Prezime;
                textBoJMBG.Text = c.JMBG.ToString();
                textBoxTelefon.Text = c.Telefon;
                textBoxAdresa.Text = c.Adresa;
                comboBoxPozicija.Text = c.PosStatus;
            }
        }
        #endregion


        #region Button za Promenu Clanu
        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClanoviIgraci.SelectedIndex > -1)
            {
                if (Validacija() == true)
                {
                    PromeniClana();
                }
            }
            else
            {
                MessageBox.Show("Odaberite clana");
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


        #region TextBox Selection change za Filtraciju po Imenu
        private void textBoxPronadji_TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrirajClana();
        }
        #endregion
    }
}
