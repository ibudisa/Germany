using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationTest
{
    public interface IBase<T> where T:class
    {
       // T Find(int id);
        void Save();
        void Delete();
        string Id { get; set; }

    }
}
