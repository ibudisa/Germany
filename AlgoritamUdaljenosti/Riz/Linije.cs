using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Riz
{
    public class Linije
    {
        public string PolazniAerodrom { get; set; }
        public string DolazniAerodrom { get; set; }
        public double LinijaDuljina { get; set; }

        public Linije(string polazni, string dolazni, double linijaduljina)
        {
            PolazniAerodrom = polazni;
            DolazniAerodrom = dolazni;
            LinijaDuljina = linijaduljina;

        }

        public override string ToString()
        {
            return PolazniAerodrom + " => " + DolazniAerodrom + " : " + LinijaDuljina.ToString();
        }
    }
}
