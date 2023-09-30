using System.Collections;
using System.Security.Cryptography.X509Certificates;

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

            Anoniyms anoniyms = new Anoniyms(strings);

            #region Topshiriq1

            // 1
            Console.WriteLine(
            anoniyms.Sum(item =>
            {
                string str = "";
                decimal num = 0;
                foreach (string s in strings) 
                { 
                     str += s;
                    num++;
                }
                return num;
            }));

            //2

            Console.WriteLine(anoniyms.Sum(item =>
            {
                decimal totalSum = 0;

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

            // 3

            Console.WriteLine(
           anoniyms.Sum(item =>
           {
               decimal num = 0;
               foreach (string s in strings)
               {
                   foreach(char ch in s)
                   {
                       if(ch == 'u' || ch == 'U' || ch == 'o' || ch == 'O' || ch == 'e' || ch == 'E')
                       {
                           num += ch;
                       }
                   }
               }
               return num ;
           }));


            #endregion


            # region topshiriq2

            //1
            Console.WriteLine("xarflar yigindis "+
            anoniyms.Avarage(item => 
            {
                double d = 0;
                int num = 0;
                foreach(string s in strings)
                {
                    foreach(char ch in s)
                    {
                        d += (int)ch;
                        num++;
                    }
                }
                

                return d / num;
               
            }));

            //2

            Console.WriteLine("unli xarflar yigindisi : "+
           anoniyms.Avarage(item =>
           {
               double num = 0;
               int num1 = 0;
               foreach (string s in strings)
               {
                   foreach (char ch in s)
                   {
                       if (ch == 'u' || ch == 'U' || ch == 'o' || ch == 'O' || ch == 'e' || ch == 'E')
                       {
                           num += (int)ch;
                           num1++;
                       }
                   }
               }
               return num / num1;
           }));

            //3 

            Console.WriteLine("undosh xarflar yigindisi : " +
           anoniyms.Avarage(item =>
           {
               double num = 0;
               int num1 = 0;
               foreach (string s in strings)
               {
                   foreach (char ch in s)
                   {
                       if (!(ch == 'u' || ch == 'U' || ch == 'o' || ch == 'O' || ch == 'e' || ch == 'E'))
                       {
                           num += (int)ch;
                           num1++;
                       }
                   }
               }
               return num / num1;
           }));


            #endregion


            #region topshiriq3
            //1

            Console.WriteLine(
            anoniyms.All(item =>
            {
                string str = "udbfghtr";
                bool unli = true;
                foreach (char s in str)
                {
                    if (s == 'u' || s == 'i' || s == 'a' || s == 'e')
                    {
                        unli = false;
                    }
                }
                if (unli)
                {
                    Console.WriteLine(" unli xarf yoq");
                    return true;
                }
                Console.WriteLine(" unli xarf bor ");
                return false;
            }
            ));

            //2

            Console.WriteLine(
           anoniyms.All(item =>
           {
               
               bool unli = true;
               foreach (string srt in strings)
               {
                   foreach (char s in srt)
                   {
                       if (s == 'a')
                       {
                           unli = false;
                       }
                   }
               }
               if (unli)
               {
                   Console.WriteLine(" unli xarf yoq");
                   return true;
               }
               Console.WriteLine(" unli xarf bor ");
               return false;
           }
           ));


            #endregion

            
        }

    } 
}
    