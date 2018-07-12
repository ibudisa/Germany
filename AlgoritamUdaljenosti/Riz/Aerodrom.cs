using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Riz
{
    public class Aerodrom
    {
        public string Ime { get; set; }
        public double GeogSirina { get; set; }
        public double GeogDuljina { get; set; }

        public Aerodrom()
        {
            Ime = "";
            GeogSirina = 0;
            GeogDuljina = 0;
        }

        public Aerodrom(string ime, double geogsirina, double geogduljina)
        {
            Ime = ime;
            GeogSirina = geogsirina;
            GeogDuljina = geogduljina;
        }
     }
}
