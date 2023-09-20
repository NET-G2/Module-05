using System.Collections;

namespace Lesson06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            strings.Add("one");
            strings.Add("two");
            strings.Add("three");
            strings.Add("four");
            strings.Add("five");

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            // Delegate for even/odd check
            Func<int, bool> isEven = (int a) => a % 2 == 0;
            Func<int, bool> isOdd = (int a) => a % 2 != 0;

            #region Anonymous methods

            var printHello = new Action(() => Console.WriteLine("Hello"));
            printHello();

            var printMessage = new Action<string>((string message) => Console.WriteLine(message));
            printMessage("Hello, World!");

            var getSum = new Func<int, int, string>((int a, int b) => (a + b).ToString());
            Console.WriteLine(getSum(1, 2));

            var calculateTotal = new Func<int[], int>((int[] array) =>
            {
                int sum = 0;
                foreach (var item in array)
                {
                    Console.Write(item + " + ");
                    sum += item;
                }

                Console.WriteLine();

                return sum;
            });
            Console.WriteLine(calculateTotal(new int[] { 1, 2, 3, 4, 5 }));

            #endregion

            #region Contains

            Console.WriteLine(strings.Contains("one"));
            Console.WriteLine(numbers.Contains(6));

            #endregion

            #region Any

            Func<string, bool> containsLetterA = (string item) =>
            {
                foreach (var letter in item)
                {
                    if (letter == 'a')
                    {
                        return true;
                    }
                }

                return false;
            };

            Func<string, bool> isOne = (string item) => item == "one";

            Console.WriteLine(strings.Any(isOne));
            Console.WriteLine();
            Console.WriteLine(strings.Sum(item =>
            {
                decimal currentSum = 0;
                foreach (char ch in item)
                {
                    currentSum += ch;
                }

                Console.WriteLine(currentSum);

                return currentSum;
            }));

            Console.WriteLine(strings.Sum(item =>
            {
                int totalSum = 0;
                if (item == "one")
                {
                    totalSum += 1;
                }
                else if (item == "two")
                {
                    totalSum += 2;
                }
                else if (item == "three")
                {
                    totalSum += 3;
                }
                else if (item == "four")
                {
                    totalSum += 4;
                }
                else if (item == "five")
                {
                    totalSum += 5;
                }

                return totalSum;
            }));

            CustomStringList stringList = new CustomStringList(strings);
            Console.WriteLine($"Custom string method: {stringList.Sum()}");

            Func<string, bool> hasMoreVowels = (string item) =>
            {
                int vowelsCount = 0;
                int consonantsCount = 0;

                foreach (var ch in item)
                {
                    if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    {
                        vowelsCount++;
                    }
                    else
                    {
                        consonantsCount++;
                    }
                }

                return vowelsCount > consonantsCount;
            };

            Console.WriteLine(stringList.Any(hasMoreVowels));

            #endregion
        }
    }

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
            _currentIndex = -1;
        }
    }

    class CustomStringList
    {
        private readonly List<string> strings;

        public CustomStringList(List<string> strings)
        {
            this.strings = strings;
        }

        public decimal Sum(Func<string, decimal> func)
        {
            decimal totalSum = 0;

            foreach (var item in strings)
            {
                totalSum += func(item);
            }

            return totalSum;
        }

        public bool Any(Func<string, bool> predicate)
        {
            foreach (var item in strings)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public decimal Sum()
        {
            decimal totalSum = 0;

            foreach (var item in strings)
            {
                int currentSum = 0;
                foreach (var ch in item)
                {
                    currentSum += ch;
                }

                totalSum += currentSum;
            }

            return totalSum;
        }
    }
}
