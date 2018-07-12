using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Helpers;

namespace DAL
{
    public class DAktivnosti
    {
        public DAktivnosti()
        {

        }

        public IEnumerable<Aktivnosti> GetAllN()
        {
            IEnumerable<Aktivnosti> a = null;
            using (FarmeronBazaEntities e = new FarmeronBazaEntities())
            {
                a = e.Aktivnosti.ToArray();
            }

            return a;
        }

        public Aktivnosti GetOne(int f)
        {
            Aktivnosti e = new Aktivnosti();

            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                e = b.Aktivnosti.Single(d => d.id == f);
            }

            return e;

        }

        public IEnumerable<Aktivnosti> GetAktivnosti(int id)
        {
            IEnumerable<Aktivnosti> d = null;
            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                d = (from a in b.Aktivnosti
                     where a.idFarmera == id
                     select a).ToArray();
            }

            return d;
        }



        public Aktivnosti Add()
        {
            Aktivnosti e = new Aktivnosti();

            return e;
        }

        public void Add1(Aktivnosti e)
        {
            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                b.Aktivnosti.Add(e);
                b.SaveChanges();
            }
        }

        public Aktivnosti Update(int c)
        {
            Aktivnosti e = null;
            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                e = b.Aktivnosti.Single(m => m.id == c);
            }
            return e;

        }

        public void Update1(Aktivnosti g)
        {
            Aktivnosti e = null;

            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                b.Entry(g).State = System.Data.EntityState.Modified;
                b.SaveChanges();
            }
        }

        public Aktivnosti Delete(int g)
        {
            Aktivnosti e = null;

            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                e = b.Aktivnosti.Single(d => d.id == g);
            }

            return e;
        }

        public void Delete1(int d)
        {
            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                Aktivnosti e = b.Aktivnosti.Single(p => p.id == d);
                b.Aktivnosti.Remove(e);
                b.SaveChanges();
            }
        }


    }
}
