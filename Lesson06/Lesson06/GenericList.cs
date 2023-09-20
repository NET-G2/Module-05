namespace Lesson06
{
    class GenericList<T> where T : IRunnable
    {
        private readonly List<T> elements;

        public GenericList(List<T> elements)
        {
            this.elements = elements;
        }

        public decimal Sum(Func<T, decimal> func)
        {
            decimal totalSum = 0;

            foreach (T item in elements)
            {
                item.Run();
                totalSum += func(item);
            }

            return totalSum;
        }

        public double Average(Func<T, double> func)
        {
            double totalSum = 0;

            foreach (T item in elements)
            {
                totalSum += func(item);
            }

            return totalSum / elements.Count;
        }

        public void Foreach(Action<T> action)
        {
            foreach (T item in elements)
            {
                action(item);
            }

            Console.WriteLine();
        }

        public int Count(Predicate<T> predicate)
        {
            int count = 0;

            foreach (T item in elements)
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