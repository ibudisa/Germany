using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.IO;

namespace Data
 {
    public class AttributeFile
    {
        private string _path = String.Empty; 
        private AllKeys<DKey> _keys;
        private int _count;
        private const int _offsetPos = 0;
        private const int _lengthPos = 1;
        private const int _parameterPos = 2;
        private const int _offsetKeyPos = 3; 
        private const int _lengthKeyPos = 4;

        private const int _dkeyAlloc = 5;
        private const int _dainAlloc = 3;

        private readonly Encoding _encoding = Encoding.GetEncoding("iso-8859-1");

        public AttributeFile(string pth)
        { 
            this._path = pth;
            this._keys = new AllKeys<DKey>();
             
        }

        private AllKeys<DKey>  GetDKeys()
        {
            string st = String.Empty;
            DKey key ;


            using(Stream s = File.OpenRead(this._path))
            {
                using(StreamReader rdr = new StreamReader(s,_encoding))
                {  
                    while ((st = rdr.ReadLine()) != null)
                    {
                        string[] arr = st.Split (' ') ;

                        
                        if (arr[_parameterPos].StartsWith("DKEY"))
                        {
                            string[] res = clearArray(arr,_dkeyAlloc);

                            key = new DKey();

                            key.Name = res[_parameterPos].Substring(4).Trim();
                            key.Offset = int.Parse((res[_offsetKeyPos]).Trim());
                            key.Length = int.Parse((res[_lengthKeyPos]).Trim());

                            this._keys.AddKey(key);
                        }
                    }
               }
            }

            return this._keys;
        }

        private string[]  clearArray (string[] input,int alloc)
        {
            string[] output= new string[alloc];
            int i = 0;

            foreach (var s in input)
            {
                if (i == alloc) break;
                
                if (!(s.Equals("")))
                {
                    output[i++] = s;
                }
            }

            return output;
        }

        private bool IsValid(string[] ptrn)
        {
            try
            {
                this._keys = GetDKeys();
                int i = 0;

                bool[] validArray = new bool[ptrn.Length];

                foreach (string st in ptrn)
                {
                    string[] tem = st.Split('+');
                
                    foreach (var dkey in _keys)
                    {
                        if ((tem[_offsetPos].Equals(dkey.Offset.ToString())) && (tem[_lengthPos].Equals(dkey.Length.ToString())))
                        {
                            validArray[i] = true;
                        }
                    }

                    i++;

                }

                if (IsAllTrue(validArray))
                {
                    return true;
                }

                 return false;
            }

            catch (Exception)
            {
                return false;
            }
            
        }

        private  bool IsAllTrue(bool[] bf)
        {
            foreach (var b in bf)
            {
                if (!b) return false;
            }

         return true;
        }

        public string Match(string pattern,int numresults,int fromOffset,int toOffset)
        {

            try
            {
                IList<Match> result = new List<Match>();
                IList<Match> temp = new List<Match>();

                string s;

                string[] attributes = pattern.Split('#');

                bool isValid = this.IsValid(attributes);

                if (isValid)
                {

                    if (attributes.Length > 1)
                    {

                        foreach (var attribute in attributes)
                        {
                            temp = HelperMatch(attribute, numresults,fromOffset,toOffset);

                            result = result.Concat(temp).ToList();

                        }
                    }

                    else
                    {
                        result = HelperMatch(pattern, numresults, fromOffset, toOffset);
                    }

                    s = _count.ToString();

                    foreach (Match m in result)
                    {
                        s += m.ToString();
                    }
                    s += ";";
                }
                else
                {
                    s = "Pattern invalid!";
                }


                return s;
            }
            catch (Exception ee)
            {

                string st = "Pattern invalid!";

                return st;
            }
             
        }

        private IList<Match> HelperMatch(string param,int num,int fromOffset,int toOffset)
        {
            try
            {
                string st = String.Empty;
                Dain dain;

                IList<Match> list = new List<Match>();

                using (Stream s = File.OpenRead(this._path))
                {
                    using (StreamReader rdr = new StreamReader(s,_encoding))
                    {
                        while ((((st = rdr.ReadLine()) != null)) && (_count < num))
                        {
                            string[] arr = st.Split(' ');

                            if (arr[_parameterPos].StartsWith("DAIN"))
                            {
                                string[] res = clearArray(arr,_dainAlloc);
                                
                                dain = new Dain(res[_parameterPos].Substring(4));

                                dain.Offset = int.Parse(res[_offsetPos]);
                                dain.Length = int.Parse(res[_lengthPos]);

                                if (dain.Contains(param,fromOffset,toOffset))
                                {
                                    Match m = new Match(dain.Offset, dain.Length);
                                    list.Add(m);
                                    _count++;
                                }
                            }
                        }
                    }
                }
                if (fromOffset<=toOffset)
                {
                    return list;
                }
                else
                {
                    return list.Reverse().ToList();
                }
                
            }
            catch (Exception ee)
            {
                return new List<Match>();
            }
            
            
           
        }
    }
}
