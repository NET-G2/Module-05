using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    public class CustomEnumerator : IEnumerator
    {
        private readonly string[] _items;
        private readonly int _count;
        private int _currentIndex;

        public CustomEnumerator(string[] items)
        {
            _items = items;
            _count = items.Length;
            _currentIndex = -1;
        }

        public object Current => _items[_currentIndex];

        public bool MoveNext()
        {
            if (_currentIndex < _count - 1)
            {
                _currentIndex++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}