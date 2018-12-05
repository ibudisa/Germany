using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositorys
{
    public class DataManager
    {
        private PosaoAnketaEntities anketaEntities = new PosaoAnketaEntities();

        public DataManager()
        {

        }

        public List<Anketa> GetAnkete()
        {
            var list = anketaEntities.Anketas.Where(p=>p.Aktivna==true).ToList();

            return list;
        }

        public List<Pitanje> GetPitanja(int anketaid)
        {
            var list = anketaEntities.Pitanjes.Where(p => p.AnketaId == anketaid).ToList();

            return list;
        }

        public List<Odgovor> GetOdgovori(int pitanjeid)
        {
            var list = anketaEntities.Odgovors.Where(o => o.PitanjeId == pitanjeid).ToList();

            return list;
        }

        public Pitanje GetPitanje(int? id)
        {
            var item = anketaEntities.Pitanjes.Where(p => p.Id == id).SingleOrDefault();

            return item;
        }



        public Anketa GetJednaAnketa(int id)
        {
            var anketa = anketaEntities.Anketas.Include(a => a.Pitanjes).Where(p => p.Id == id && p.Aktivna==true).SingleOrDefault();

            return anketa;
        }

        public void Izmjeni(Anketa anketa)
        {
            //var data = anketaEntities.Anketas.Include(a => a.Odgovors).Where(p => p.Id == anketa.Id).SingleOrDefault();
            //data.Datum = anketa.Datum;
            //data.Pitanje = anketa.Pitanje;
            //data.Odgovors = anketa.Odgovors;

            anketaEntities.Entry(anketa).State = EntityState.Modified;
            anketaEntities.SaveChanges();

        }

        public Anketa GetLatest()
        {
            var anketa=  anketaEntities.Anketas.Where(p=>p.Aktivna==true).OrderByDescending(item => item.Datum).First();

            return anketa;
        }

        public void AddPitanje(Pitanje pitanje)
        {
            anketaEntities.Pitanjes.Add(pitanje);
            anketaEntities.SaveChanges();
        }

        public void AddOdgovor(Odgovor odgovor)
        {
            anketaEntities.Odgovors.Add(odgovor);
            anketaEntities.SaveChanges();
        }

        public Odgovor GetOdgovor(int id)
        {
            Odgovor item = anketaEntities.Odgovors.Where(o => o.Id == id).FirstOrDefault();

            return item;
        }

        public void UpdateOdgovor(Odgovor odgovor)
        {
            anketaEntities.Entry(odgovor).State = EntityState.Modified;
            anketaEntities.SaveChanges();
        }

        public void DeleteOdgovor(int id)
        {
            var odgovor = GetOdgovor(id);
            anketaEntities.Odgovors.Remove(odgovor);
            anketaEntities.SaveChanges();
        }

        public void AddRezultat(Statistika statistika)
        {
            anketaEntities.Statistikas.Add(statistika);
            anketaEntities.SaveChanges();
        }

        public List<int?> GetIskoristenaPitanja()
        {
            var list = anketaEntities.Statistikas.Select(p => p.IdPitanja).ToList();

            return list;
        }

        public List<Pitanje> GetPreostalaPitanja()
        {
            List<Pitanje> list = new List<Pitanje>();

            List<Pitanje> listsva = anketaEntities.Pitanjes.ToList();

            //list = listsva;

            List<int?> iskoristeni = GetIskoristenaPitanja();
            bool found = false;

           
            foreach(var i in iskoristeni)
            {
                Pitanje p = GetPitanje(i);
                list.Add(p);
            }
            
            foreach(var item in list)
            {
                if(listsva.Contains(item))
                {
                    listsva.Remove(item);
                }
            }

            return listsva;
        }

        public Pitanje GetLatestPitanje()
        {

            Pitanje data = null;
            var list = GetPreostalaPitanja();
            if (list.Count > 0)
            {
                data = GetPreostalaPitanja().FirstOrDefault();
            }

            return data;
        }

        public void DeleteStatistika()
        {
            var itemsToDelete = anketaEntities.Set<Statistika>();
            anketaEntities.Statistikas.RemoveRange(itemsToDelete);
            anketaEntities.SaveChanges();
        }

        public double GetRezultat()
        {
            var list = anketaEntities.Statistikas.ToList();
            int count = list.Count;
            int num = 0;
            double r = 0;

            foreach(var item in list)
            {
                int? odgovorid = item.IdOdgovora;
                if(odgovorid!=null)
                {
                    int id = (int)odgovorid;
                    Odgovor o = GetOdgovor(id);
                    if(o.Tocan==true)
                    {
                        num++;
                    }

                }
            }

            r =(double) num / count;

            return r;
        }

    }
}
