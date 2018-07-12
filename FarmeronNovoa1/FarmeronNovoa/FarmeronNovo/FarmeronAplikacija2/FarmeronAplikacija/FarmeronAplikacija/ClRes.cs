using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmeronAplikacija
{
    public class ClRes
    {
        public DAL.Farmeri Djelatnik { get; set; }
        public String Data { get; set; }

        public ClRes(DAL.Farmeri d, String data)
        {
            Djelatnik = d;
            Data = data;
        }
    }
}