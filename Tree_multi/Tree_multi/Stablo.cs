using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tree_multi
{
    public class Stablo
    {
        public List<int> Ulaz { get;set;}
        public List<Cvor> Stabloo { get; set; }
        public List<Cvor> StabloFinal { get; set; }


        public Stablo()
        { 
            Ulaz = new List<int>(); 
            Stabloo = new List<Cvor>();
            StabloFinal = new List<Cvor>();
        }

        public Stablo( List<int> ulazni)
            : this()
        {
            Ulaz = ulazni;

            kreirajStablo(Ulaz);

        }

        private void kreirajStablo(List<int> podaci)
        {
            int a = 0; 

            foreach (int s in podaci)
            {
                Cvor tata = new Cvor(s);
                Cvor sin = new Cvor(a++, tata);

                Stabloo.Add(sin);
            }

            //dodaj sve reference od listova prema korijenskom elementu

            List<Cvor> cvorovi = this.CvorListovi();

            foreach (Cvor c in cvorovi)
            {
                Cvor cc = new Cvor();
                cc = c;
                dodajReference(ref cc);
                StabloFinal.Add(cc);
            }

        }


        private List<int> Listovi()
        {
            List<int> listovi = new List<int>();

            for (int i = 0; i < Ulaz.Count;i++ )
            {
                if (!(this.Exists(i)))
                {
                    listovi.Add(i);
                }
            }

            return listovi;
        }

        private List<Cvor> CvorListovi()
        {
            List<Cvor> cvorovi = new List<Cvor>();
            
            foreach (Cvor c in Stabloo)
            {
                if (this.Listovi().Contains(c.Val))
                {
                    cvorovi.Add(c);
                }

            }

            return cvorovi;
        }


        private bool Exists(int val)
        {
            foreach (int q in Ulaz)
            {
                if (q == val) return true;
            }

            return false;
        }


        private void dodajReference(ref Cvor cv)
        {
            Cvor c = new Cvor();
            c = cv.Tata;

            if (c.Val == -1) return;

            foreach (Cvor cc in Stabloo)
            {
                if (c.Val == cc.Val)
                {
                    c.Tata = cc.Tata;
                    dodajReference(ref c);
                }
            }
        }

        public int maxLength()
        {
            int max = 0;
            Cvor cv = new Cvor();

            foreach (Cvor c in StabloFinal)
            {
                int i = 0;
                cv=c;

                if (cv.Tata == null) continue;
                while (cv.Tata.Val != -1)
                {                    
                    cv = cv.Tata;
                    i++;
                }
                if (i > max)
                {
                    max = i;
                }
            }

            return max;
        }
    }
}
