using Supermarket;
using Supermarket.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Category> categories = new List<Category>();
        public Form1()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            categories.Clear();
            CategoryDbService productService = new CategoryDbService();
            categories = productService.GetAllCategories();

            dataGridView1.DataSource = categories;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
