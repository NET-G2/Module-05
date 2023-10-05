using System.Collections;

namespace Lesson06
{
    class CustomEnumerator : IEnumerator
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
            _currentIndex = 0;
        }
    }
}