using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
 

namespace Data
{
    public class DataFile

    {
        private string path;
        private bool rev = false;

        public DataFile(string pth)
        {
            this.path = pth;
        }


        public string Find(string pattern,int fromOffset, int toOffset, int numresults)
        {
            try
            {
                string sg = string.Empty;
                string res;
                int length = 0;

                CheckValues(ref fromOffset, ref toOffset);

                using (Stream s = File.OpenRead(this.path))
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        sg = sr.ReadToEnd();

                        MakeALimit(ref toOffset, sg);

                        length = Convert.ToInt32(Math.Abs(toOffset - fromOffset));

                        res = sg.Substring(fromOffset, length);
                       
                    }

                }
                return SearchString(pattern, fromOffset, toOffset, res, numresults).ToString();
            }
            catch (Exception)
            {

                return "0;";
            }
             
        }
        
        private void CheckValues(ref int from, ref int to)
        {
            int tem = 0;

            if(from>to)
            {
                tem = from;
                from = to;
                to = tem;

                this.rev = true;
            }
        }

        private void MakeALimit(ref int to,string s)
        {
            if (to>s.Length)
            {
                to = s.Length;
            }
        }

        private string SearchString(string patrn, int fromOffset, int toOffset,string str,int num)
        {
            try
            {
                int i = 0;
                int lastOffset = fromOffset;
                int listOffset=0;

                string res = string.Empty;
                string wrkstring = string.Empty;

                wrkstring = str;

                List<int> ints = new List<int>();


                while ((wrkstring.IndexOf(patrn) != -1))
                {

                    i = wrkstring.IndexOf(patrn);
                    lastOffset += i ;
                    //lastOffset += patrn.Length;
                    wrkstring = wrkstring.Substring(i + patrn.Length);

                    
                    ints.Add(lastOffset);

                    lastOffset += patrn.Length;


                }

                string s = string.Empty;


                s = Reversed(ints, this.rev,num);


                return s;
            }
            catch (Exception)
            {

                return "";
            }
            
        }

        private  string Reversed(List<int> list,bool iS,int num)
        {
            try
            {
                string d = string.Empty;
                List<int> temp = new List<int>();

                if (!iS)
                {
                    temp = list;
                }
                else
                {
                    temp = list.Reverse<int>().ToList();
                }

                if(num>temp.Count)
                {
                    num = temp.Count;
                }

                temp.RemoveRange(num,temp.Count-num);

                foreach (var a in temp)
                {
                    d += a.ToString() + ";";
                }

                d = temp.Count.ToString() + ";" + d;

                return d;
            }
            catch (Exception)
            {

                return "";
            }
            
        }
}
}
