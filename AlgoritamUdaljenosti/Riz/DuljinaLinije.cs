using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Device.Location;


namespace Riz
{
    public class DuljinaLinije
    {
        public Aerodrom A1 { get; set; }
        public Aerodrom A2 { get; set; }

        public DuljinaLinije(Aerodrom aerodrom1, Aerodrom aerodrom2)
        {
            A1 = aerodrom1;
            A2 = aerodrom2;
        }

        public double Distance()
        {
            var firstCordinate = new GeoCoordinate(A1.GeogDuljina, A1.GeogSirina);
            var secondCordinate = new GeoCoordinate(A2.GeogDuljina, A2.GeogSirina);

            double distance = firstCordinate.GetDistanceTo(secondCordinate);
            return distance;
        }

        private double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
