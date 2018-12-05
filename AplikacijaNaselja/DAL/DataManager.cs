using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataManager
    {
        private TestMVCEntities testMVC = new TestMVCEntities();

        public DataManager()
        {

        }


        public List<Naselja> GetNaselja()
        {
            var list = testMVC.Naseljas.ToList();
            return list;
        }


        public void AddNaselje(Naselja naselja)
        {
            testMVC.Naseljas.Add(naselja);
            testMVC.SaveChanges();
        }

        public Naselja GetNaselje(int id)
        {
            var item = testMVC.Naseljas.Where(p => p.Id == id).SingleOrDefault();

            return item;
        }

        public void UpdateNaselje(Naselja naselja)
        {
            testMVC.Entry(naselja).State = EntityState.Modified;
            testMVC.SaveChanges();
        }

        public void DeleteNaselje(int id)
        {
            var naselje = GetNaselje(id);
            testMVC.Naseljas.Remove(naselje);
            testMVC.SaveChanges();
        }


        public List<SifrarnikDrzava> GetDrzave()
        {
            var list = testMVC.SifrarnikDrzavas.ToList();

            return list;
        }

        public int BrojNaselja()
        {
            int count = testMVC.Naseljas.ToList().Count;

            return count;
        }
    }
}
