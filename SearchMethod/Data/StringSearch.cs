using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class StringSearch
    {
        private readonly string value;
        private readonly List<int> indexList = new List<int>();
        public StringSearch(string value)
        {
            this.value = value;
        }
        public bool Found(int nextChar)
        {
            for (int index = 0; index < indexList.Count; )
            {
                int valueIndex = indexList[index];
                if (value[valueIndex] == nextChar)
                {
                    ++valueIndex;
                    if (valueIndex == value.Length)
                    {
                        indexList[index] = indexList[indexList.Count - 1];
                        indexList.RemoveAt(indexList.Count - 1);
                        return true;
                    }
                    else
                    {
                        indexList[index] = valueIndex;
                        ++index;
                    }
                }
                else
                {   // next char does not match
                    indexList[index] = indexList[indexList.Count - 1];
                    indexList.RemoveAt(indexList.Count - 1);
                }
            }
            if (value[0] == nextChar)
            {
                if (value.Length == 1)
                    return true;
                indexList.Add(1);
            }
            return false;
        }
        public void Reset()
        {
            indexList.Clear();
        }

    }
}
