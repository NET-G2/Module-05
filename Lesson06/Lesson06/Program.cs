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
            strings.Add("   ");
            strings.Add("five");

            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            #region Extenion methods Sampels

            //List<string> list = new List<string>();
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //HashSet<string> hashSet = new HashSet<string>();
            //Queue<string> queue = new Queue<string>();
            //Stack<string> stack = new Stack<string>();

            //CustomList customList = new CustomList(
            //    new string[] { "one", "two", "three" });

            //customList.DisplayAll();

            //int a = 4;

            //Console.WriteLine(a.IsEven());
            //Console.WriteLine(a.IsOdd());

            #endregion

            #region Anonymous methods

            //var printHello = () => Console.WriteLine();
            //printHello();

            //var printMessage = (string message) => Console.WriteLine(message);
            //printMessage("Hello, World!");

            //var getSum = (int a, int b) => (a + b).ToString();
            //printMessage(getSum(1, 2));

            //var calculateTotal = (int[] array) =>
            //{
            //    int sum = 0;
            //    foreach (var item in array)
            //    {
            //        Console.Write(item + " + ");
            //        sum += item;
            //    }

            //    Console.WriteLine();

            //    return sum;
            //};
            //printMessage(calculateTotal(new int[] { 1, 2, 3, 4, 5 }).ToString());

            #endregion

            #region Contains

            //Console.WriteLine(strings.Contains("one"));
            //Console.WriteLine(numbers.Contains(6));

            #endregion

            #region Homework

            //GenericList<string> stringList = new GenericList<string>(strings);

            //var getFirstLetterValue = (string item) =>
            //{
            //    if (item.Trim().Length > 0)
            //    {
            //        decimal value = item.Trim()[0];
            //        return value;
            //    }

            //    return 0;
            //};

            //var firstLettersSum = stringList.Sum(getFirstLetterValue);
            //var vowelsAndConsonantsDifference = stringList.Sum(CalculateDifferenceBetweenVowelAndConsonants);
            //var totalSum = stringList.Sum((string item) =>
            //{
            //    decimal currentSum = 0;
            //    foreach (char ch in item)
            //    {
            //        currentSum += ch;
            //    }

            //    return currentSum;
            //});

            //var countLetters = (string item) => (double)item.Length;

            //var averageLettersCount = stringList.Average(countLetters);
            //var averageVowels = stringList.Average(CalculateAverageVowels);

            //Console.WriteLine(averageLettersCount);
            //Console.WriteLine(averageVowels);

            //var displayNonEmptyString = (string item) =>
            //{
            //    if (item.Trim().Length > 0)
            //    {
            //        Console.WriteLine(item);
            //    }
            //};

            //stringList.Foreach(DisplayAllUppercase);
            //stringList.Foreach(displayNonEmptyString);

            //var countStringWithMoreThanThreeLetters = stringList.Count(HasMoreTanThreeLetters);
            //var countStringEndingWithVowels = (string item) =>
            //{
            //    if (item.Trim().Length > 0)
            //    {
            //        char lastChar = item.Trim()[item.Trim().Length - 1];
            //        if (lastChar == 'a' || lastChar == 'e' || lastChar == 'i' ||
            //            lastChar == 'o' || lastChar == 'u' || lastChar == 'y')
            //        {
            //            return true;
            //        }
            //    }

            //    return false;
            //};

            //Console.WriteLine(countStringWithMoreThanThreeLetters);
            // Console.WriteLine(stringList.Count(countStringEndingWithVowels));

            #endregion
        }

        static decimal CalculateDifferenceBetweenVowelAndConsonants(string str)
        {
            decimal vowelsSum = 0;
            decimal consonantsSum = 0;

            foreach (char ch in str)
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' ||
                                       ch == 'o' || ch == 'u' || ch == 'y')
                {
                    vowelsSum += ch;
                }
                else
                {
                    consonantsSum += ch;
                }
            }

            return Math.Abs(vowelsSum - consonantsSum);
        }

        static double CalculateAverageVowels(string str)
        {
            double totalNumberOfVowels = 0;

            foreach (char ch in str)
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' ||
                                       ch == 'o' || ch == 'u' || ch == 'y')
                {
                    totalNumberOfVowels += 1;
                }
            }

            return totalNumberOfVowels / str.Length;
        }

        static void DisplayAllUppercase(string str)
        {
            Console.WriteLine(str.ToUpper());
        }

        static bool HasMoreTanThreeLetters(string str)
        {
            return str.Length > 3;
        }
    }
}