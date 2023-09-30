using System;
using System.Linq;

namespace Lesson06
{
    internal class Anoniyms
    {
        public Anoniyms() { }

        private readonly List<string> strings;

        public Anoniyms(List<string> strings)
        {
            this.strings = strings;
        }

        public decimal Sum(Func<string, decimal> func)
        {
            string str = string.Empty;
            decimal result = 0; ;
            foreach (string s in strings)
            {
                str += func(s);
                result += func(s);
            }

            return result;
        }

        public double Avarage(Func<string, double> func)
        {

            double result = 0;
            foreach (string s in strings)
            {
                result += func(s);
            }

            return result;
        }

        public bool All(Func<string, bool> func)
        {

            double result = 0;
            foreach (string s in strings)
            {
                if (func(s))
                {
                    return true;
                }
            }

            return false;
        }




    }
}
