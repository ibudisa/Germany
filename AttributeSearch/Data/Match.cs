using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Match
    {
        public int Offset { get; set; }
        public int Length { get; set; }

        public  Match()
        {
            
        }

        public  Match(int offset,int length)
        {
            Offset = offset;
            Length = length;
        }

        public override string ToString()
        {
            return ";" + Offset.ToString() + ";" + Length.ToString();
        }
    }
}
