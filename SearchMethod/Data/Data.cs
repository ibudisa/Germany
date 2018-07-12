using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class Data
    {
        public static int FindInFile(string fileName, string value)
        {   // returns complement of number of characters in file if not found
            // else returns index where value found
            int index = 0;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName))
            {
                if (String.IsNullOrEmpty(value))
                    return 0;
                StringSearch valueSearch = new StringSearch(value);
                int readChar;
                while ((readChar = reader.Read()) >= 0)
                {
                    ++index;
                    if (valueSearch.Found(readChar))
                        return index - value.Length;
                }
            }
            return ~index;
        }

    }
}
