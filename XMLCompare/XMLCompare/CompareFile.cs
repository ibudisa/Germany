using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Org.XmlUnit;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Validation;
using Org.XmlUnit.Input;
using Org.XmlUnit.Diff;
using System.Xml;
using DAL;



namespace XMLCompare
{
    public class CompareFile
    {
        private string sourcepath;
        private string expectedpath;
         

        public CompareFile(string path1,string path2)
        {
            this.sourcepath = path1;
            this.expectedpath = path2;
        }
        public List<FileData> Compare()
        {
            bool d = false;
            List<Node> nodes= new List<Node>(); 
            List<FileData> list = new List<FileData>();
            ISource test1 = Input.FromFile(this.sourcepath).Build();
            ISource test2 = Input.FromFile(this.expectedpath).Build();
            Diff myDiff = DiffBuilder
                .Compare(test1).WithTest(test2).IgnoreWhitespace()
                .CheckForSimilar()
                .Build();
            if (myDiff.HasDifferences())
            {

                List<Difference> values = myDiff.Differences.ToList();
                foreach (Difference dif in values)
                {
                    Comparison.Detail co = dif.Comparison.ControlDetails;
                    Node n = FindNodes(co);
                    nodes.Add(n);
                    
                }

                List<string> nodesvalues = nodes.Select(x => x.Name).Distinct().ToList();

                List<Node> nodeslist = GetList(nodesvalues);

                List<Node> nodesdifferent = new List<Node>();

                nodesdifferent = GetDifferent(nodeslist);

                DataObject data = new DataObject();
                if (nodesdifferent.Count > 0)
                {

                    
                    data.SaveNodes(nodesdifferent);
                }

                foreach (Difference dif in values)
                {
                    Comparison.Detail co = dif.Comparison.ControlDetails;

                    FileData value = GetFile(co);
                    list.Add(value);
                }

              
                data.SaveDiff(list);


            }
            return list;
            
        }

        public Node FindNodes(Comparison.Detail d)
        {
            Node n = new Node();
             if (d.Target.Name.Equals("#text"))
            { n.Name = d.Target.ParentNode.Name; }
            else
            {
                n.Name = d.Target.Name;
            }
            return n;
        }

        public FileData GetFile(Comparison.Detail detail)
        {
            FileData f = new FileData();
            DataObject dataaccess = new DataObject();
            
            if (detail.Target.Name.Equals("#text"))
            { f.NodeID = dataaccess.GetID(detail.Target.ParentNode.Name); }
            else
            {
                f.NodeID = dataaccess.GetID(detail.Target.Name);
            }
            f.NodeValue = detail.Target.Value;
            f.SourceFile = this.sourcepath;
            f.ExpectedFile = this.expectedpath;
            f.Xpath = detail.XPath;

            return f;


        }

        public List<Node> GetDifferent(List<Node> ls)
        {
            DataObject k = new DataObject();
            List<Node> l = new List<Node>();
            foreach(Node node in ls)
            {
                if(!k.Contains(node))
                {
                    l.Add(node);
                }
            }
            return l;
        }

        public List<Node> GetList(List<string> list)
        {
            List<Node> nodes = new List<Node>();
            foreach(string s in list)
            {
                Node element = new Node();
                element.ID = 0;
                element.Name = s;
                nodes.Add(element);
            }
            return nodes;
        }
        public void Function()
        {

        }
    }
}