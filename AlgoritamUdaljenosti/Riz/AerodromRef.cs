using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Riz
{
    public class AerodromRef
    {
        public Aerodrom Podaci { get; set; }
        public AerodromRef Sljedeci { get; set; }
        public AerodromRef Prethodni { get; set; }

        public AerodromRef()
        {
            Podaci = null;
            Sljedeci = null;
            Prethodni = null;
        }
        
        public AerodromRef(Aerodrom a1)
        {
            Podaci = a1;
            Sljedeci = null;
            Prethodni = null;
        }
            
    }
}
