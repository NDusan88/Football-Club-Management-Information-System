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
    /// Interaction logic for PrikaziUcesnike.xaml
    /// </summary>
    public partial class PrikaziUcesnike : Window
    {
        TakmicenjaDal TDal = new TakmicenjaDal();
        UcestvovanjeDal UDal = new UcestvovanjeDal();
        ClanoviDal CDal = new ClanoviDal();
        public PrikaziUcesnike()
        {
            InitializeComponent();
        }
        private void PrikaziListuUcesnika()
        {
            List<IgraciKojiUcestvuju> listaIgraca = TDal.PrikaziIgraceKojiUcestvuju();

            dataGridListaIgraca.Items.Clear();
            foreach (IgraciKojiUcestvuju lista in listaIgraca)
            {
                dataGridListaIgraca.Items.Add(lista);
            }
        }
        private void ObrisiIgraca()
        {
            Ucestvovanje u = new Ucestvovanje();

            IgraciKojiUcestvuju i = (IgraciKojiUcestvuju)dataGridListaIgraca.SelectedItem;
            u.Igraci_Clanovi_BrCK = i.BrCK;

            int rezz = UDal.ObrisiIgraca(u);

            if (rezz != 0)
            {
                MessageBox.Show("Greska", "Poruka");
            }
            else
            {
                PrikaziListuUcesnika();
                MessageBox.Show("Uspesno obrisan", "Poruka");
            }
        }
        private void FiltrirajClana()
        {
            dataGridListaIgraca.Items.Clear();

            IgraciKojiUcestvuju c = new IgraciKojiUcestvuju();
            c.Ime = textBoxPronadji.Text;
            List<IgraciKojiUcestvuju> listaClanova = UDal.FiltrirajClana(textBoxPronadji.Text);
            foreach (IgraciKojiUcestvuju lista in listaClanova)
            {
                dataGridListaIgraca.Items.Add(lista);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziListuUcesnika();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListaIgraca.SelectedIndex > -1)
            {
                if (MessageBox.Show("Potvrdite brisanje?", "Obavestenje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    ObrisiIgraca();
                }
            }
            else
            {
                MessageBox.Show("Odaberite igraca za brisanje", "Poruka");
            }
        }

        private void buttonIzadji_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void textBoxPronadji_TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrirajClana();
        }
    }
}
