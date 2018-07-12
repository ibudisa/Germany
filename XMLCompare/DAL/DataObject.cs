using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class DataObject
    {
        public DataObject()
        {

        }

        public void SaveDiff(List<FileData> list)
        {
            using(CompareEntities ctx= new CompareEntities())
            {
                ctx.FileData.AddRange(list);
                ctx.SaveChanges();
            }
        }

        public void SaveNodes(List<Node> list)
        {
            using (CompareEntities ctx = new CompareEntities())
            {
                ctx.Node.AddRange(list);
                ctx.SaveChanges();
            }
        }

        public int GetID(string name)
        {
            int id;
             using (CompareEntities ctx = new CompareEntities())
            {
               Node res = ctx.Node.FirstOrDefault(n => n.Name.Equals(name));
               id = res.ID;
            }
             return id;
        }
        public IEnumerable<Node> GetNodes()
        {
            IEnumerable<Node> nodes;
            using (CompareEntities ctx = new CompareEntities())
            {
                nodes = ctx.Node.ToList(); ;

            }
            return nodes;
        }

        public bool Contains(Node n)
        {
            bool b = false;
            using(CompareEntities ctx=new CompareEntities())
            {
                b = ctx.Node.Any(p => p.Name.Equals(n.Name));
            }
            return b;
        }

        public IEnumerable<FileData> GetFileData()
        {
            IEnumerable<FileData> files;
            using(CompareEntities ctx= new CompareEntities())
            {
                files = ctx.FileData.ToList();
            }
            return files;
        }
        

        public void DeleteNodes()
        {
            using(CompareEntities ctx=new CompareEntities())
            {
                ctx.Node.RemoveRange(GetNodes());
                ctx.SaveChanges();
            }
        }

       public IEnumerable<FileData> GetFilesByID(int id)
        {
            IEnumerable<FileData> f;
           using(CompareEntities ctx = new CompareEntities())
           {
               f = (from a in ctx.FileData
                    where a.NodeID == id
                    select a).ToList();
           }

           return f;
        }
       
        public void DeleteFileData()
        {
            using(CompareEntities ctx = new CompareEntities())
            {
                ctx.FileData.RemoveRange(GetFileData());
                ctx.SaveChanges();
            }
        }
 /*      
        public List<DataValue> Get()
        {
            List<DataValue> data;
            using(CompareEntities ctx=new CompareEntities())
            {
                 data = ctx.FileData
                .GroupBy(ac => new
                {
                    ac.NodeName, // required by your view model. should be omited
                    // in most cases because group by primary key
                    // makes no sense.
                    ac.NodeValue,
                    ac.Xpath
                    
                })
                .Select(ac => new DataValue
                {
                    NodeName = ac.Key.NodeName,
                    NodeValue = ac.Key.NodeValue,
                    Xpath = ac.Key.Xpath

                }).ToList();
            }
            return data;
        }

        public List<DataValueView> GetDataDisplay()
        {
            List<FileData> list = new List<FileData>();
            string s = null;
            IEnumerable<DataValue> data = Get();
            DataValueView item;
            List<DataValueView> items = new List<DataValueView>();
            List<string> comparedfiles = new List<string>();
            using (CompareEntities ctx = new CompareEntities())
            {
                list = ctx.FileData.ToList();
            }
                foreach(DataValue v in data)
                {
                    comparedfiles = new List<string>();
                    
                    foreach(FileData f in list)
                    {
                        if((v.NodeName.Equals(f.NodeName))&&(v.NodeValue.Equals(f.NodeValue))&&(v.Xpath.Equals(f.Xpath)))
                        {
                              s = f.SourceFile + "-" + f.ExpectedFile;
                            comparedfiles.Add(s);
                        }
                    }
                    item = new DataValueView {NodeName= v.NodeName,NodeValue= v.NodeValue,Xpath= v.Xpath,Files= comparedfiles};
                    items.Add(item);
                }
            
            int i = 0;
            return items;
        }
        
        */
    }
}

