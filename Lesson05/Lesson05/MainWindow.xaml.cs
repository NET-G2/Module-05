using Lesson05.Models;
using System.Collections.Generic;
using System.Windows;

namespace Lesson05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.GetAllEmployees();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 2 clicked now");
        }
    }
}
