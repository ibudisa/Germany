using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BAktivnosti
    {
        private DAL.DAktivnosti dl;


        public BAktivnosti()
        {
            this.dl = new DAktivnosti();
        }

        public IEnumerable<DAL.Aktivnosti> GetAll()
        {
            IEnumerable<Aktivnosti> k = this.dl.GetAllN();

            return k;
        }

        public DAL.Aktivnosti GetOne(int i)
        {
            Aktivnosti m = this.dl.GetOne(i);

            return m;

        }

        public IEnumerable<DAL.Aktivnosti> GetAktivnosti(int i)
        {
            IEnumerable<DAL.Aktivnosti> d = this.dl.GetAktivnosti(i);

            return d;

        }


        public DAL.Aktivnosti Add()
        {
            DAL.Aktivnosti e = this.dl.Add();

            return e;

        }

        public void Add1(DAL.Aktivnosti g)
        {
            this.dl.Add1(g);
        }

        public DAL.Aktivnosti Update(int i)
        {

            DAL.Aktivnosti e = this.dl.Update(i);

            return e;

        }

        public void Update1(DAL.Aktivnosti m)
        {
            this.dl.Update1(m);
        }

        public DAL.Aktivnosti Delete(int i)
        {

            Aktivnosti e = this.dl.Delete(i);

            return e;
        }

        public void Delete1(int i)
        {
            this.dl.Delete1(i);

        }


    }
}
