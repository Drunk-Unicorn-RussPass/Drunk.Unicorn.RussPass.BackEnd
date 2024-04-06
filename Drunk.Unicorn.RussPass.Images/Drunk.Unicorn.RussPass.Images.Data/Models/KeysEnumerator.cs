using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.Data.Models
{
    public class KeysEnumerator : IEnumerator<string>
    {
        public string[] _keys;

        int position = -1;

        public KeysEnumerator(string[] list)
        {
            _keys = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _keys.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            _keys = null;
        }

        public string Current
        {
            get
            {
                try
                {
                    return _keys[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;
    }
}
