using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFudbalskiKlubZavrsniRad2017.Klase
{
    class Dobavljac
    {
        public int DobavljaciId { get; set; }
        public int PIB { get; set; }
        public string Naziv { get; set; }
        public string Delatnost { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Naziv);
        }
    }
}
