using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    class HashTableEnum : IEnumerator
    {
        private Person[] _personsArray;
        int _position = -1;

        public HashTableEnum(Person[] array)
        {
            _personsArray = array;
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _personsArray.Length);

        }
        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _personsArray[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
