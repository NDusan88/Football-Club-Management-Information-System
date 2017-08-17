using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFudbalskiKlubZavrsniRad2017.Klase
{
    class Takmicenja
    {
        public int RBr { get; set; }
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string Tip { get; set; }
        public string Podloga { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", Naziv);
        }
    }
}
