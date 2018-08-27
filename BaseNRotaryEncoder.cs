using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DialectSoftware.Encoding
{
    public class BaseNRotaryEncoder: IEnumerator<string>, IEnumerable, IEnumerable<string>
    {
        int baseN;
        int generator;
        List<char> mapping;

        public string Current => Encode(generator);

        object IEnumerator.Current => Current;

        public BaseNRotaryEncoder(int baseN, IEnumerable<char> mapping)
        {
            System.Diagnostics.Debug.Assert(mapping.Count() == baseN, "baseN mapping length mismatch");
            this.generator = -1;
            this.baseN = baseN;
            this.mapping = mapping.ToList();
        }
  
        public string Encode(int d)
        {
            int r = d % baseN;
            if (r - d == 0)
                return toChar(r);
            return Encode(((d - r) / baseN)-1) + toChar(r);
        }

        public int Decode(string value)
        {
            int i = (int)value.Reverse().Select((c, index) =>
            {
                return ((mapping.IndexOf(c)) * Math.Pow(baseN, index)) + Math.Pow(baseN, index);
            }).Sum();
            return --i;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string toChar(int n)
        {
            return mapping[n].ToString();
        }

        public bool MoveNext()
        {
            return ++generator >= 0;
        }

        public void Reset()
        {
            generator = -1;
        }

        public void Dispose()
        {
            
        }
    }
}
