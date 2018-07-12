using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    public class PersonData
    {
        public List<Person> data = new List<Person>();

        public PersonData()
        {
            Person p1 = new Person();
            p1.ID = 1;
            p1.FirstName = "Name1";
            p1.LastName = "Last1";
            p1.Address = "Address1";
            data.Add(p1);
            Person p2 = new Person();
            p2.ID = 2;
            p2.FirstName = "Name2";
            p2.LastName = "Last2";
            p2.Address = "Address2";
            data.Add(p2);
            Person p3 = new Person();
            p3.ID = 3;
            p3.FirstName = "Name3";
            p3.LastName = "Last3";
            p3.Address = "Address3";
            data.Add(p3);
            Person p4 = new Person();
            p4.ID = 4;
            p4.FirstName = "Name4";
            p4.LastName = "Last4";
            p4.Address = "Address4";
            data.Add(p4);
            Person p5 = new Person();
            p5.ID = 5;
            p5.FirstName = "Name5";
            p5.LastName = "Last5";
            p5.Address = "Address5";
            data.Add(p5);
            Person p6 = new Person();
            p6.ID = 6;
            p6.FirstName = "Name6";
            p6.LastName = "Last6";
            p6.Address = "Address6";
            data.Add(p6);
            Person p7 = new Person();
            p7.ID = 7;
            p7.FirstName = "Name7";
            p7.LastName = "Last7";
            p7.Address = "Address7";
            data.Add(p7);
            Person p8 = new Person();
            p8.ID = 8;
            p8.FirstName = "Name8";
            p8.LastName = "Last8";
            p8.Address = "Address8";
            data.Add(p8);
            Person p9 = new Person();
            p9.ID = 9;
            p9.FirstName = "Name9";
            p9.LastName = "Last9";
            p9.Address = "Address9";
            data.Add(p9);
            Person p10 = new Person();
            p10.ID = 10;
            p10.FirstName = "Name10";
            p10.LastName = "Last10";
            p10.Address = "Address10";
            data.Add(p10);
        }
    }
}
