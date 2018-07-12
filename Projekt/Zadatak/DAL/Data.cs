using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Data
    {
        public IEnumerable<JsonRData> GetData()
        {
            IEnumerable<JsonRData> data = null;
            using (ServisBazaEntities a = new ServisBazaEntities())
            {
                data = a.JsonRData.ToArray();
            }
            return data;
        }


        public void Insert(JsonRData d)
        {
            try
            {
                using (ServisBazaEntities t = new ServisBazaEntities())
                {
                    t.JsonRData.Add(d);
                    t.SaveChanges();
                }
            }
            catch (Exception ec)
            {
            }
        }
    }
}
