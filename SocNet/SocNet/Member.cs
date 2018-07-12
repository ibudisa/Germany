using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocNet
{
    public class Member
    {
        public int num;
        public List<int> persons;

        public Member(int n)
        {
            this.num = n;
            this.persons = new List<int>();
        }

        public void AddPerson(int d)
        {
            this.persons.Add(d);
        }

        public void AddOthers(List<int> l1)
        {
            this.persons.AddRange(l1);
            this.persons = this.persons.Distinct().ToList();
             
            
        }


        public List<int> GetPersons()
        {
            if (persons != null)
            {
                return this.persons;
            }
            return null;
        }
    }
}
