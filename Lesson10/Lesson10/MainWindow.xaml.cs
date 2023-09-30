using Bogus;
using Lesson10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SupermarketDbContext _context;
        private ObservableCollection<Product> products;

        public MainWindow()
        {
            InitializeComponent();

            _context = new SupermarketDbContext();
            products = new ObservableCollection<Product>();
            productsDataGrid.ItemsSource = products;

            LoadData().Wait();
        }

        private async Task LoadData()
        {
            using (var dbContext = new SupermarketDbContext())
            {
                var loadedProducts = await dbContext.Products
                    .Include(nameof(Product.Category))
                    .ToListAsync();

                productsCount.Text = $"Products ({loadedProducts.Count})";

                products = new ObservableCollection<Product>(loadedProducts);

                var loadedCategories = await dbContext.Categories
                    .ToListAsync();

                categoriesCombobox.ItemsSource = loadedCategories;
            }
        }

        private void PopulateData()
        {
            using (var dbContext = new SupermarketDbContext())
            {
                AddCategories(dbContext);
                AddProducts(dbContext);
            }
        }

        private void AddCategories(SupermarketDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var faker = new Faker();
            List<string> categoryNames = faker.Commerce.Categories(50).ToList();

            foreach (var name in categoryNames)
            {
                context.Categories.Add(new Category()
                {
                    Name = name
                });
            }
        }

        private void AddProducts(SupermarketDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var faker = new Faker();
            List<Category> categories = context.Categories.ToList();

            for (int i = 0; i < 500; i++)
            {
                context.Products.Add(new Product()
                {
                    Name = faker.Commerce.ProductName(),
                    Price = faker.Random.Decimal(5000, 500_000),
                    CategoryId = GetRandomCategoryId(categories)
                });
            }

            context.SaveChanges();
        }

        private static int GetRandomCategoryId(List<Category> categories)
        {
            var random = new Random();
            int randomIndex = random.Next(0, categories.Count);
            var randomCategory = categories[randomIndex];

            if (randomCategory == null)
            {
                return -1;
            }

            return categories[randomIndex].Id;
        }

        private async void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                return;
            }

            List<Product> searchResult = null;

            if (string.IsNullOrEmpty(searchBox.Text))
            {
                searchResult = await GetAllProducts();
            }
            else
            {
                searchResult = await SearchProducts(searchBox.Text);
            }

            products = new ObservableCollection<Product>(searchResult);
        }

        private void CategoriesCombobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            List<Product> filteredProducts = null;
            var selectedCategory = ((Category)categoriesCombobox.SelectedItem);

            using (var context = new SupermarketDbContext())
            {
                if (selectedCategory == null)
                {
                    filteredProducts = context.Products
                        .Include(nameof(Product.Category))
                        .ToList();
                }
                else
                {
                    filteredProducts = context.Products
                        .Include(nameof(Product.Category))
                        .Where(x => x.CategoryId == selectedCategory.Id)
                        .ToList();
                }

                productsCount.Text = $"Products ({filteredProducts.Count})";

                productsDataGrid.ItemsSource = null;
                productsDataGrid.ItemsSource = filteredProducts;
            }
        }

        private void ClearCombobox_Clicked(object sender, RoutedEventArgs e)
        {
            categoriesCombobox.SelectedItem = null;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async Task<List<Product>> SearchProducts(string searchText) =>
            await _context.Products.Where(x => x.Name.ToLower().Contains(searchText.ToLower()) ||
               x.Category.Name.ToLower().Contains(searchText.ToLower())).ToListAsync();

        private async Task<List<Product>> GetAllProducts() => await _context.Products.ToListAsync();
    }
}
