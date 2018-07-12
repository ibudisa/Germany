using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Status
    {
        public Exception ec { get; set; }
        public String Info { get; set; }

        public Status(Exception et, String m)
        {
            ec = et;
            Info = m;
        }
    }
}
