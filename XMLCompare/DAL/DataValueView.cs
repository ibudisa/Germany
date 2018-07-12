using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataValueView
    {
        public string NodeName;
        public string NodeValue;
        public string Xpath;
        public List<string> Files;


        public DataValueView()
        { }
        public DataValueView(string nodename,string nodevalue,string xpath,List<string> list)
        {
            this.NodeName = nodename;
            this.NodeValue = nodevalue;
            this.Xpath = xpath;
            this.Files = list;

        }
    }
}
