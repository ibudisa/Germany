using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Dain
    {
        public string RecordType { get; set; }
        public int Offset { get; set; }
        public int Length { get; set;}
        public string Parameter { get; set; }

        private const int _offsetPos = 0;
        private const int _lengthPos = 1;
        private const int _valuePos = 2;

        private string _line;
          

        public  Dain()
        {
            
        }

        public Dain(string ln)
        {
            this._line = ln;
        }

        public bool Contains(string pattern,int fromOff,int toOff)
        {
            int startpos, endpos;
            int fromOffset, toOffset;

            try
            {
                string[] attributes = pattern.Split('+');
                int refer = 0;

                if (attributes[_valuePos].Length < int.Parse(attributes[_lengthPos]))
                {
                    refer = attributes[_valuePos].Length;
                }
                else
                {
                    refer = int.Parse(attributes[_lengthPos]);
                }


                if(fromOff<=toOff)
                {
                    startpos = fromOff;
                    endpos = toOff;
                }
                else
                {
                    startpos = toOff;
                    endpos = fromOff;
                }


                fromOffset = this.Offset + int.Parse(attributes[_offsetPos]);
                toOffset = fromOffset + int.Parse(attributes[_lengthPos]);

                if(!((fromOffset>=startpos)&&(toOffset<=endpos)))
                {
                    return false;
                }


                if (attributes[_valuePos].Equals(this._line.Substring(int.Parse(attributes[_offsetPos]), refer)))
                    return true;

              return false;
            }
            catch(Exception ee)
            {
                return false;
            }
        }

    }
}
