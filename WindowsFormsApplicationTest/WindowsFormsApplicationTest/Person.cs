using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationTest
{
    public class Person:BaseClass<Person>

    {
        public  string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }

        public Person(string name,string surname,Address personaddress):base(new object[] { name, surname, personaddress })
        {
            Id ="";   
   
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();


        }

        public static bool operator ==(Person k1, Person k2)
        {
            if (object.ReferenceEquals(k1, k2))
            {
                return true;
            }

            if ((object)k1 == null || (object)k2 == null)
            {
                return false;
            }

            return (k1.Id == k2.Id && k1.FirstName == k2.FirstName && k1.LastName == k1.LastName && k1.Address == k2.Address);

        }

        public static bool operator !=(Person k1, Person k2)
        {
            if (object.ReferenceEquals(k1, k2))
            {
                return false;
            }

            if ((object)k1 == null || (object)k2 == null)
            {
                return true;
            }

            return (k1.Id != k2.Id && k1.FirstName != k2.FirstName && k1.LastName != k1.LastName && k1.Address != k2.Address);
        }

    }
}
