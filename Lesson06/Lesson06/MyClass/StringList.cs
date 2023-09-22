using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    internal class StringList
    {
        private readonly List<string> strings;

        public StringList(List<string> strings)
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

        public double Average(Func<string, double> func)
        {
            double totalSum = 0;

            foreach(var item in strings)
            {
                totalSum += func(item);
            }

            return totalSum / strings.Count;
        }

        public bool All(Func<string, bool> func)
        {
            foreach(var item in strings)
            {
                if (!func(item))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Any(Func<string, bool> func)
        {
            foreach(var item in strings)
            {
                if (func(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void ForEach(Action<string> action)
        {
            foreach (var item in strings)
            {
                action(item);
            }
        }

        public bool Cointains(Func<string, bool> func)
        {
            foreach (var item in strings)
            {
                if (func(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int Count(Predicate<string> func)
        {
            int counter = 0;

            foreach(var item in strings)
            {
                if (func(item))
                {
                    counter++;
                }
            }

            return counter;
        }

        public string First(Func<string, bool> func)
        {
            foreach(string item in strings)
            {
                if (func(item))
                {
                    return item;
                }
            }

            return "Empty !";
        }
    }
}
