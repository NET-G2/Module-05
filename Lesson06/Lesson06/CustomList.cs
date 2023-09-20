using System.Collections;

namespace Lesson06
{
    class CustomList : IEnumerable
    {
        private readonly CustomEnumerator _enumerator;

        public CustomList(string[] items)
        {
            _enumerator = new CustomEnumerator(items);
        }

        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }
    }
}