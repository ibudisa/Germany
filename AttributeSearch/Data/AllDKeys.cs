using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Data
{
    public class AllKeys<T> : IEnumerable<T> where T : DKey
    {
        public List<T> Keys { get; private set; }


        public AllKeys()
        {
            Keys = new List<T>();
        }

        public void AddKey(T key)
        {
            Keys.Add(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Keys as IEnumerable).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (Keys as IEnumerable<T>).GetEnumerator();
        }

        public T this[int i]
        {
            get { return Keys[i]; }
            set { Keys[i] = value; }
        }
    }
}
