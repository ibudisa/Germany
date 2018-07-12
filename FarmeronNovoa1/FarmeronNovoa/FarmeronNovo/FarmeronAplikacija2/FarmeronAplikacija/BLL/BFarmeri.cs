using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BFarmeri
    {
        private DFarmeri d;


        public BFarmeri()
        {
            this.d = new DFarmeri();
        }

        public IEnumerable<Farmeri> GetFarmeri()
        {
            return this.d.GetAllD();
        }
        public Farmeri GetFarmer(int i)
        {
            return this.d.GetOneD(i);
        }

        public string GetSurname(string name)
        {
            return this.d.GetSurname(name);
        }

        public Farmeri Add()
        {
            Farmeri g = this.d.Add();

            return g;
        }
        public String Add1(Farmeri e)
        {
            Status s = this.d.AddD(e);
            return s.Info;
        }

        public Farmeri Update(int i)
        {
            Farmeri g = this.d.Update(i);

            return g;
        }

        public String Update1(Farmeri g)
        {
            Status st = this.d.Update1(g);
            return st.Info;
        }

        public Farmeri Delete(int i)
        {
            Farmeri m = this.d.Delete(i);

            return m;
        }

        public String Delete1(int m)
        {
            Status s = this.d.Delete1(m);

            return s.Info;
        }


    }
}
