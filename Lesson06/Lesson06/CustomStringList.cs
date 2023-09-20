namespace Lesson06
{
    public class CustomStringList
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
