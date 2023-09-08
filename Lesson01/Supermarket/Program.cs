using System;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService db = new ProductService();

            db.ReadAllProducts();
            Console.WriteLine();

            db.CreateProduct("CocaCola", 25000);
            Console.WriteLine();

            db.ReadAllProducts();
            Console.WriteLine();

            db.UpdateProduct(1, "Water", 50000);
            Console.WriteLine();

            db.ReadAllProducts();
            Console.WriteLine();

            db.DeleteProduct(6);
            db.ReadAllProducts();

            Console.ReadKey();
        }
    }
}
