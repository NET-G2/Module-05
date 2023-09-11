namespace Supermarket.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfProducts { get; set; }

        public Category() { }
        public Category(int id, string categoryName, int numberOfProducts)
        {
            Id = id;
            CategoryName = categoryName;
            NumberOfProducts = numberOfProducts;
        }
    }
}
