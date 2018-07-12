using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Riz
{
    public class FileData
    {
        public string Name { get; set; }

        public static string FileName { get; set; }

        private List<string> linije = new List<string>();
        private List<string> linijep = new List<string>();

        private List<AerodromRef> linijer = new List<AerodromRef>();

        public FileData()
        {
           if (Name==null)
           {
               Name= @"c:\lokacije.txt";
           }
           else
           {
               Name = FileName;
           }
        }
        /* Baza podataka iz tekstualne dataoteke se prenosi u listu*/
        public List<Aerodrom> Data()
        {
            List<Aerodrom> list = new List<Aerodrom>();
            using (Stream s = File.OpenRead(Name))
            {
                using (StreamReader st = new StreamReader(s))
                {
                    string line;
                    while ((line = st.ReadLine()) != null)
                    {
                        string[] array = line.Split(' ');
                        decimal a1 = decimal.Parse(array[1]);
                        decimal a2 = decimal.Parse(array[2]);
                        Aerodrom j = new Aerodrom(array[0], (double) a1, (double) a2);
                        list.Add(j);
                    }
                }
            } return list;
        }
        /* Podaci o letovi između aerodroma*/
        public List<string> Linije()
        {
            try
            {
                List<Aerodrom> list = new List<Aerodrom>();
                list = Data();
                List<string> podaci = new List<string>();

                foreach (Aerodrom d in list)
                {
                    podaci = AerodromLinije(list, d);

                    linije.AddRange(podaci);
                }
            }
            catch (Exception ec)
            {
            }
            return linije;
        }

        public List<string> AerodromLinije(List<Aerodrom> l, Aerodrom f)
        {
            List<string> c = new List<string>();
            try
            {

                foreach (Aerodrom a in l)
                {
                    if (!(a.Equals(f)))
                    {
                        DuljinaLinije d = new DuljinaLinije(f, a);
                        double udaljenost = d.Distance();
                        Linije g = new Linije(f.Ime, a.Ime, udaljenost);
                        c.Add(g.ToString());
                    }
                }
            }
            catch (Exception ec)
            {
            }
            return c;
        }

        private double GetValue(string a,string b)
        {
            List<string> lista = new List<string>();
            double length = 0;
            if (this.linije==null)
            {
                lista = Linije();
            }

            foreach(string s in this.linije)
            {
                string[] array = s.Split(' ');
                if((array[0].Equals(a))&&(array[2].Equals(b)))
                {
                    length = double.Parse(array[array.Length - 1]);
                }
            }

            return length;

        }
        /* Dodavanja leta u podatke o letovima*/
        public void AddFlight(string aerodroma, string aerodromb)
        {
            try
            {
                int v = 0;

                foreach (string l in linije)
                {
                    string[] array = l.Split(' ');
                    if (!((array[0].Equals(aerodroma)) && (array[2].Equals(aerodromb))))
                    {
                        v++;
                    }
                    if (v == linije.Count)
                    {
                        List<Aerodrom> ls = new List<Aerodrom>();
                        Aerodrom ar1 = GetAerodrom(Data(), aerodroma);
                        Aerodrom ar2 = GetAerodrom(Data(), aerodromb);
                        DuljinaLinije dl = new DuljinaLinije(ar1, ar2);
                        Linije sd = new Linije(aerodroma, aerodromb, dl.Distance());

                        linije.Add(sd.ToString());
                    }

                }
            }
            catch (Exception ec)
            {
            }
        }
        /* Uklanjanje podataka o liniji između aerodroma*/
        public void RemoveFlight(string aerodrom1, string aerodrom2)
        {

            try
            {
                int f = 0;
                int j = 0;
                int d = 0;
                foreach (string l in linije)
                {
                    string[] array = l.Split(' ');
                    if ((array[0].Equals(aerodrom1)) && (array[2].Equals(aerodrom2)))
                    {
                        j = f;
                        d = f;
                    }
                    
                    f++;
                }
                if (j == d)
                {
                    linije.RemoveAt(j);
                }
            }
            catch (Exception ec)
            {
            }
        }
        private Aerodrom GetAerodrom(List<Aerodrom> aerodromi, string a1)
        {
            Aerodrom r = new Aerodrom();
            foreach (Aerodrom a in aerodromi)
            {
                if (a.Ime.Equals(a1))
                {
                    r = a;
                }
            }

            return r;
        }
        /* Informacije o pojedinim letovima prema nekom aerodromu / do nekog aerodroma*/
        public List<string> GetFlight(string a, string b)
        {
            List<string> l = new List<string>();
            List<string> ls = new List<string>();

            if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
            {
                ls = linije;
            }
            else if (!(String.IsNullOrEmpty(a)) && String.IsNullOrEmpty(b))
            {
                foreach (string s in linije)
                {
                    string[] array = s.Split(' ');

                    if (array[0].Equals(a))
                    {
                        ls.Add(s);
                    }
                }
            }
            else if (String.IsNullOrEmpty(a) && !(String.IsNullOrEmpty(b)))
            {
                foreach (string s in linije)
                {
                    string[] array = s.Split(' ');

                    if (array[2].Equals(b))
                    {
                        ls.Add(s);
                    }
                }
            }
            else if (!(String.IsNullOrEmpty(a)) && !(String.IsNullOrEmpty(b)))
            {
                foreach (string s in linije)
                {
                    string[] array = s.Split(' ');

                    if ((array[0].Equals(a)) && (array[2].Equals(b)))
                    {
                        ls.Add(s);
                    }
                }

            }

            return ls;
        }
        /* Podaci o letovima koji obuhvaćaju više aerodroma, manji put*/
        public List<string> GetShortPathFlight(string a, string b)
        {
            List<AerodromRef> ls = new List<AerodromRef>();
            List<string> l = new List<string>();
            List<string> listr = new List<string>();

            ls = Aerodromi();
            l = LinijeRef();

            int c = 0;
            double distance = 0;

            int r = 0; ;
            string linestr = String.Empty;

            if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
            {
                foreach (string s in l)
                {
                    string[] array = s.Split(' ');

                        r = c;
                        for (int j = 2; j < array.Length; j++)
                        {
                            distance = distance + GetValue(array[j - 2], array[j]);
                        }

                    c++;
                    linestr = l[r] + " : " + distance.ToString();
                    distance = 0;
                    listr.Add(linestr);
                }
                c = 0;
 
            }
            else if (!(String.IsNullOrEmpty(a)) && !(String.IsNullOrEmpty(b)))
            {
                foreach (string s in l)
                {
                    string[] array = s.Split(' ');

                    if ((array[0].Equals(a))&&(array[array.Length-1].Equals(b)))
                    { 
                        r=c;
                        for (int j = 2; j < array.Length; j++)
                        {
                            distance = distance + GetValue(array[j - 2], array[j]);
                        }
                    }
                     c++;
                     linestr = l[r] + " : " + distance.ToString();
                }
                c = 0;
                distance = 0;
                listr.Add(linestr);
            }
            else if (String.IsNullOrEmpty(a) && !(String.IsNullOrEmpty(b)))
            {
                foreach (string s in l)
                {
                    string[] array = s.Split(' ');

                    if (array[array.Length - 1].Equals(b))
                    {
                        r = c;
                        for (int j = 2; j < array.Length; j++)
                        {
                            distance = distance + GetValue(array[j - 2], array[j]);
                        }
                        linestr = l[r] + " : " + distance.ToString();
                        listr.Add(linestr);

                    }
                    c++;
                    distance = 0;

                }
                c = 0;
            }
            else if (!(String.IsNullOrEmpty(a)) && (String.IsNullOrEmpty(b)))
            {
                foreach (string s in l)
                {
                    string[] array = s.Split(' ');

                    if (array[0].Equals(a))
                    {
                        r = c;
                        for (int j = 2; j < array.Length; j++)
                        {
                            distance = distance + GetValue(array[j - 2], array[j]);
                        }
                        linestr = l[r] + " : " + distance.ToString();
                        listr.Add(linestr);
                    }
                    c++;

                    distance = 0;

                }

                c = 0;
            }

            return listr;
        }

        private List<AerodromRef> Aerodromi()
        {
            try
            {
                int v = 0;
                List<Aerodrom> ls = new List<Aerodrom>();

                List<Aerodrom> list = new List<Aerodrom>();

                List<Aerodrom> listb = new List<Aerodrom>();

                List<Aerodrom> linq = new List<Aerodrom>();

                List<Aerodrom> linqb = new List<Aerodrom>();

                ls = Data();

                linq = (from a in ls
                        orderby a.GeogDuljina
                        select a).ToList<Aerodrom>();

                while (v < 5)
                {
                    AerodromRef ar = new AerodromRef(linq[0]);


                    if (v == 0)
                    {
                        ar.Prethodni = null;
                    }

                    list = linq;

                    AerodromiRef(ref ar, list);

                    linq = (from a in ls
                            orderby a.GeogDuljina
                            select a).ToList<Aerodrom>();

                    v++;
                    if (v > 1)
                    {
                        for (int m = 0; m < v; m++)
                        {
                            linqb.Add(linq[m]);
                        }
                        linqb.RemoveAt(linqb.Count - 1);
                    }
                    
                   
                    listb = linqb;

                    AerodromiReff(ref ar, listb);

                    linq.RemoveRange(0, v);

                    linijer.Add(ar);
                }
            }
            catch (Exception ec)
            {
            }
            return linijer;

        }
        /* Dodavanje referenci na aerodrom - dvostruko povezana lista */

        private void AerodromiRef(ref AerodromRef d1,List<Aerodrom> l)
        {
            AerodromRef t = new AerodromRef();
            if (l.Count > 1)
            {
                t = new AerodromRef(l[1]);
                d1.Sljedeci = t;
                t.Prethodni = d1;

                l.RemoveAt(0);
                AerodromiRef(ref t,l);
            }
            else if (l.Count == 1)
            {
                d1.Sljedeci = null;

                l.RemoveAt(0);
                AerodromiRef(ref t,l);

            }
            else
            {

            }

        }

        /* Dodavanje referenci na aerodrom - dvostruko povezana lista drugi dio */
        private void AerodromiReff(ref AerodromRef d1, List<Aerodrom> lb)
        {
            AerodromRef t = new AerodromRef();
            if (lb.Count > 0)
            {

                t = new AerodromRef(lb[lb.Count - 1]);
                d1.Prethodni = t;
                t.Sljedeci = d1;

                lb.RemoveAt(lb.Count - 1);


                AerodromiReff(ref t, lb);
            }
   
            

        }




        public List<string> LinijeRef()
        {

            foreach (AerodromRef r in linijer)
            {
                AerodromRef d = r;
                LinijeLista(ref d);
            }

            return linijep;
        }

        public void LinijeLista(ref AerodromRef c)
        {
            AerodromRef d = new AerodromRef();
            AerodromRef j = new AerodromRef();
            j = c;
            d = c;
            string s = c.Podaci.Ime;

            while (j.Sljedeci != null)
            {
                s = s + " => " + j.Sljedeci.Podaci.Ime;
                linijep.Add(s);
                j = j.Sljedeci;
            }

            s = d.Podaci.Ime;

            while (d.Prethodni != null)
            {
                s = s + " => " + d.Prethodni.Podaci.Ime;
                linijep.Add(s);
                d = d.Prethodni;

            }
        }
    }   
}