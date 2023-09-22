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
            strings.Add("wrtz");
            strings.Add("ieya");

            StringList lists = new StringList(strings);

            #region Sum

            // Task 1 : Barcha elementlarni bir-biriga qo'shish. 


            //var result = lists.Sum(str =>
            //{
            //    decimal currentSum = 0;
            //    foreach (char ch in str)
            //    {
            //        currentSum += ch;
            //    }

            //    return currentSum;
            //});


            // Task 2 : Sonlarni tarjima qilib qo'shish. 

            //var result = lists.Sum(str =>
            //{
            //    if (str.Trim().ToLower() == "one") return (decimal)1;
            //    if (str.Trim().ToLower() == "two") return (decimal)2;
            //    if (str.Trim().ToLower() == "three") return (decimal)3;
            //    if (str.Trim().ToLower() == "four") return (decimal)4;
            //    if (str.Trim().ToLower() == "five") return (decimal)5;
            //    if (str.Trim().ToLower() == "six") return (decimal)6;
            //    if (str.Trim().ToLower() == "seven") return (decimal)7;
            //    if (str.Trim().ToLower() == "eight") return (decimal)8;
            //    if (str.Trim().ToLower() == "nine") return (decimal)9;
            //    if (str.Trim().ToLower() == "zero") return (decimal)0;

            //    return (decimal)0;
            //});


            //Task 3 : Unli xarflarni qo'shish. 

            //var result = lists.Sum(str =>
            //{
            //    decimal totalVowels = 0;

            //    foreach (char ch in str.ToLower())
            //    {
            //        if(ch == 'a' || ch == 'e' || ch == 'i'
            //        || ch == 'o' || ch == 'u' || ch == 'y')
            //        {
            //            totalVowels += ch;
            //        }
            //    }

            //    return totalVowels;
            //});


            //Console.WriteLine(result);
            #endregion

            #region Average

            // Task 1 :  Barcha xarflarni ASCII tabledan olib o'rta qiymatini xisoblash.

            //var result = lists.Average(str =>
            //{
            //    double totalLatters = 0;

            //    foreach(var item in str.Trim())
            //    {
            //        totalLatters += item;
            //    }

            //    return totalLatters;
            //});

            // Task 2 : Unli xarflarni ASCII tabledan olib o'rta qiymatini xisoblash. 

            //var result = lists.Average(str =>
            //{
            //    double totalVowels = 0;
            //    int counter = 0;

            //    foreach (char ch in str.ToLower())
            //    {
            //        if (ch == 'a' || ch == 'e' || ch == 'i'
            //        || ch == 'o' || ch == 'u' || ch == 'y')
            //        {
            //            totalVowels += ch;
            //            counter++;
            //        }
            //    }

            //    Console.WriteLine($" {str} = {totalVowels / counter}");

            //    return totalVowels / counter;
            //});

            // Task 3 : Undosh xarflarni ASCII tabledan olib o'rta qiymatini xisoblash. 

            //var result = lists.Average(str =>
            //{
            //    double totalConsonant = 0;
            //    int counter = 0;

            //    foreach (char ch in str.ToLower())
            //    {
            //        if (!(ch == 'a' || ch == 'e' || ch == 'i'
            //        || ch == 'o' || ch == 'u' || ch == 'y'))
            //        {
            //            totalConsonant += ch;
            //            counter++;
            //        }
            //    }

            //    Console.WriteLine($" {str} = {totalConsonant / counter}");

            //    return totalConsonant / counter;
            //});

            //Console.WriteLine($"Total result = {result}");

            #endregion

            #region All

            // Task 1 : Barcha xarflar unli ekanini tekshirish. 

            //var result = lists.All(str =>
            //{
            //    foreach (char item in str)
            //    {
            //        if (!(item == 'a' || item == 'e' || item == 'i'
            //        || item == 'o' || item == 'u' || item == 'y')) return false;
            //    }

            //    return true;
            //});

            // Task 2 : Barcha xarflar undosh ekanini tekshirish. 

            //var result = lists.All(str =>
            //{
            //    foreach (char item in str)
            //    {
            //        if (item == 'a' || item == 'e' || item == 'i'
            //        || item == 'o' || item == 'u' || item == 'y') return false;
            //    }

            //    return true;
            //});

            // Task 3 : Bittayam so'zda 'a' xarfi ishlatilmaganini tekshirish.

            //var result = lists.All(str =>
            //{
            //    foreach (char item in str.Trim().ToLower())
            //    {
            //        if (item == 'a') return false;
            //    }

            //    return true;
            //});

            //Console.WriteLine(result);

            #endregion

            #region Any

            // Task : Barcha elementlar ichida xech bo'lmaganda 1 tasida
            // 'v' harfi borligini tekshirish. 

            //var result = lists.Any(str =>
            //{
            //    foreach (char item in str)
            //    {
            //        if (item == 'v') return true;
            //    }

            //    return false;
            //});

            //Console.WriteLine(result);

            #endregion

            #region ForEach
            // Task : Berilgan elementlarni har birini bosh harfini katta harfga o'zgartirish.

            //lists.ForEach(str => Console.WriteLine(str.Replace(str[0], str.ToUpper()[0])));

            #endregion

            #region First
            // Task : Harflar soni 3 tadan ko'p bo'lgan 1-so'zni topish.

            //var res = lists.First(str => str.Length > 3);
            //Console.WriteLine(res);
            #endregion

            #region Containst

            // Task : Elementlar orasida belgilar soni juft ekanligini tekshirish.

            //var result = lists.Cointains(str =>
            //{
            //    if (str.Length % 2 == 0) return true;
            //    return false;
            //});

            //Console.WriteLine(result);

            #endregion

            #region

            // Task : Elementlar orasidan har bir elementdagi unli harflar soni undosh
            // harflar sonidan ko'p yoki teng bo'lgan elementlar sonini toping ;

            //var result = lists.Count(str =>
            //{
            //    int countVowels = 0;
            //    int countConsonants = 0;

            //    foreach (char ch in str.Trim())
            //    {
            //        if (ch == 'a' || ch == 'e' || ch == 'i'
            //            || ch == 'o' || ch == 'u' || ch == 'y') { countVowels++; }

            //        else { countConsonants++; }
            //    }

            //    return countVowels >= countConsonants;
            //});

            //Console.WriteLine(result);

            #endregion
        } 
    } 
}