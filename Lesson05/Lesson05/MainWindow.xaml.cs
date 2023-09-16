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
            employees = Services.EmployeeService.GetEmployeeByEmpno(7369);

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.MinSalInfirm();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.WorkAsFord();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.MinSalWorkAsClerk();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.MaxSalWorkAsClerk();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            employees = Services.EmployeeService.AverageSalaryInEachJob();

            empDataGrid.ItemsSource = employees;
        }
    }
}
