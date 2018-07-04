using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationTest
{
    public class Address
    {
        public string AddressName { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string ZipCode { get; set; }

        public Address(string name,string city,string code,string zipcode)
        {
            AddressName = name;
            City = city;
            Code = code;
            ZipCode = zipcode;
        }

        public override string ToString()
        {
            return "AddressName=" + AddressName +  ",City=" + City  + ",Code=" + Code + ",ZipCode=" + ZipCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is Address)
              
            {
                Address ad = obj as Address;
                if (AddressName.Equals(ad.AddressName) && City.Equals(ad.City) && Code.Equals(ad.Code) && ZipCode.Equals(ad.ZipCode))
                {
                    return true;
                }
                
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + (!Object.ReferenceEquals(null, AddressName) ? AddressName.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, City) ? City.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, Code) ? Code.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, ZipCode) ? ZipCode.GetHashCode() : 0);
                return hash;
            }

        }
    }
}
