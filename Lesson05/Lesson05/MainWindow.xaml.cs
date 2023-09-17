using Lesson05.DAL;
using Lesson05.Models;
using Lesson05.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Lesson05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SqlConnection _connection;
        private readonly EmployeeService employeeService;
        List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            _connection = new SqlConnection(DataAccessLayer.Connection_String);
            _connection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employees = employeeService.GetAllEmployees();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            employees = employeeService.GetAllEmployeesFromDepartment20();

            empDataGrid.ItemsSource = employees;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var command = "SELECT AVG(Sal), Job FROM dbo.Emp GROUP BY JOB;";

            List<object> resultList = new List<object>();

            using SqlConnection connection = new(DataAccessLayer.Connection_String);
            connection.Open();

            using SqlCommand sqlCommand = new(command, connection);
            var dataReader = sqlCommand.ExecuteReader();

            if (!dataReader.HasRows) return;

            while (dataReader.Read())
            {
                var resut = new
                {
                    AverageSalary = dataReader.GetValue(0),
                    Job = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var command = "SELECT MIN(Sal), Job" +
                " FROM dbo.Emp" +
                " WHERE Job != 'MANAGER'" +
                " GROUP BY Job;";

            List<object> resultList = new List<object>();

            using SqlConnection connection = new(DataAccessLayer.Connection_String);
            connection.Open();

            using SqlCommand sqlCommand = new(command, connection);
            var dataReader = sqlCommand.ExecuteReader();

            if (!dataReader.HasRows) return;

            while (dataReader.Read())
            {
                var resut = new
                {
                    MinimalSalary = dataReader.GetValue(0),
                    Job = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }
    }
}
