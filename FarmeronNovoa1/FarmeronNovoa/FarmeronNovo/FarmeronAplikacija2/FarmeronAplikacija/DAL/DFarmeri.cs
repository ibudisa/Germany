using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class DFarmeri
    {
        public DFarmeri()
        {

        }

        public IEnumerable<Farmeri> GetAllD()
        {
            IEnumerable<Farmeri> djelatnici = null;

            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                djelatnici = b.Farmeri.ToArray();
            }
            return djelatnici;
        }

        public Farmeri GetOneD(int id)
        {
            Farmeri d = null;

            using (FarmeronBazaEntities e = new FarmeronBazaEntities())
            {
                d = e.Farmeri.Single(a => a.ID == id);
            }
            return d;
        }
        public Farmeri Add()
        {
            Farmeri d = new Farmeri();
            return d;
        }
        public Status AddD(Farmeri d)
        {
            try
            {
                using (FarmeronBazaEntities e = new FarmeronBazaEntities())
                {
                    e.Farmeri.Add(d);
                    e.SaveChanges();
                    return new Status(null, "Success");

                }
            }
            catch (Exception ec)
            {
                return new Status(ec, "Failure");
            }
        }
        public string GetSurname(string name)
        {
            string d = String.Empty;
            Farmeri m = null;
            using (FarmeronBazaEntities b = new FarmeronBazaEntities())
            {
                m = b.Farmeri.Single(s => s.Ime.Equals(name));
            }
            d = m.Prezime;

            return d;
        }



        public Farmeri Update(int d)
        {
            Farmeri x = null;
            using (FarmeronBazaEntities g = new FarmeronBazaEntities())
            {
                x = g.Farmeri.Single(e => e.ID == d);
            }
            return x;
        }

        public Status Update1(Farmeri d)
        {
            Farmeri g = null;
            try
            {
                using (FarmeronBazaEntities b = new FarmeronBazaEntities())
                {
                    b.Entry(d).State = System.Data.EntityState.Modified;
                    b.SaveChanges();
                    return new Status(null, "Success");
                }
            }
            catch (Exception ec)
            {
                return new Status(ec, "Failure");
            }
        }

        public Farmeri Delete(int m)
        {
            Farmeri b = null;

            using (FarmeronBazaEntities d = new FarmeronBazaEntities())
            {
                b = d.Farmeri.Single(e => e.ID == m);

            }
            return b;
        }


        public Status Delete1(int g)
        {
            try
            {
                using (FarmeronBazaEntities a = new FarmeronBazaEntities())
                {
                    var d = a.Farmeri.Single(k => k.ID == g);
                    a.Farmeri.Remove(d);
                    a.SaveChanges();

                    return new Status(null, "Success");
                }
            }
            catch (Exception ec)
            {
                return new Status(ec, "Failure");
            }
        }

    }
}

