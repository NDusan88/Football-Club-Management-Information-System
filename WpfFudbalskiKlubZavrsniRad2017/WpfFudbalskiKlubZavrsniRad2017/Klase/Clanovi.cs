using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFudbalskiKlubZavrsniRad2017.Klase
{
    class Clanovi
    {
        public int Clanovi_BrCK { get; set; }
        public int BrCK { get; set; }
        public string JMBG { get; set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Ime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public int Godiste { get; set; }
        public string PosStatus { get; set; }
        public override string ToString()
        {
            return string.Format("{0}",BrCK);
        }
    }
}
