namespace Lesson06.Extensions
{
    internal static class MyListExtension
    {
        public static void DisplayAll(this CustomList list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
