using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree_multi
{
    public class Cvor
    {

        public int Val { get; set; }
        public Cvor Tata { get; set; }

        public Cvor()
        {
            Val = 0;
            Tata = null;
        }

        public Cvor(int val)
        {
            Val = val;
            Tata = null;
        }

        public Cvor(int val, Cvor tata):this(val)
        {
            Tata = tata;
        }
    }
}