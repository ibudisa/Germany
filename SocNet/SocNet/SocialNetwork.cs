using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocNet
{
    
    public class SocialNetwork
    {

        private int num = 0;
        private List<int> list;
        private List<Member> mlist = new List<Member>();

        

        public SocialNetwork(int N)
        {
            mlist = new List<Member>();
            this.num = N;
            Fill();
        }
        private void Fill()
        {
           

            for (int j = 0; j < num ;j++ )
            {
                mlist.Add(new Member(j));
                
            }
        }

        public bool AreInContact(int i, int j)
        {

            bool isMatch = false;
            try
            {
                Member m = null;
                Member t = null;
                foreach (Member d in mlist)
                {
                    if (d.num == i)
                    {
                        m = d;
                    }
                    if (d.num == j)
                    {
                        t = d;
                    }
                }

                List<int> lst = null;
                lst = m.GetPersons();

                if (lst != null)
                {

                    isMatch = Func(lst, j);
                }
            }
            catch (Exception ec)
            {
            }

            return isMatch;
        }

        private bool Func(List<int> d, int t)
        {
            foreach (int i in d)
            {
                if (i == t)
                    return true;
            }
            return false;
        }

        public void MakeContact(int i, int j)
        {
            try
            {
                Member m = null;
                Member t = null;
                foreach (Member d in mlist)
                {
                    if (d.num == i)
                    {
                        m = d;
                    }
                    if (d.num == j)
                    {
                        t = d;
                    }
                }

                if (!(AreInContact(i, j)))
                {
                    m.AddPerson(j);
                    m.AddOthers(t.GetPersons());

                    t.AddPerson(i);
                    List<int> l = m.GetPersons();

                    List<int> b = GetData(l, t.num);
        
                    t.AddOthers(b);
                }
            }
            catch (Exception ec)
            {
            }
        }

        private List<int> GetData(List<int> ls, int t)
        {
            List<int> list = new List<int>();
            foreach (int i in ls)
            {
                if (i != t)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public string Poznanici(int i)
        {
            string s = string.Empty;
            try
            {
                foreach (int t in mlist[i].GetPersons())
                {
                    s += t.ToString() + " ";
                }

               
            }
            catch (Exception ec)
            {
            }
            return s;
        }
    }
}
