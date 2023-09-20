namespace Lesson06
{
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

            foreach (string item in strings)
            {
                totalSum += func(item);
            }

            return totalSum;
        }

        public double Average(Func<string, double> func)
        {
            double totalSum = 0;

            foreach (string item in strings)
            {
                totalSum += func(item);
            }

            return totalSum / strings.Count;
        }

        public void Foreach(Action<string> action)
        {
            foreach (string item in strings)
            {
                action(item);
            }

            Console.WriteLine();
        }

        public int Count(Predicate<string> predicate)
        {
            int count = 0;

            foreach (var item in strings)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }
    }
}