using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationTest
{
    public class Business:BaseClass<Business>
    {
        public  string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public Business()
        {

        }

        public Business(string name, Address businessaddress):base(new object[] { name, businessaddress})
        {
            Id ="";
        }

        public override bool Equals(object obj)
        {
          return base.Equals(obj);
        }

        public override int GetHashCode()
        {
           return  base.GetHashCode();
        }
    }
}
