using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace Zadatak
{
    public class Mapper
    {


        public JsonRData toData(RootObject d)
        {
            JsonRData m = new JsonRData();
            m.Name = d.name;
            m.Username = d.username;
            m.Email = d.email;
            m.AddressCity = d.address.city;
            m.AddressStreet = d.address.street;
            m.Phone = d.phone;
            m.Website = d.website;
            m.CompanyName = d.company.name;

            return m;
        }
    }
}