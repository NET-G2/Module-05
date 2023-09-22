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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    employees = employeeService.GetAllEmployees();

        //    empDataGrid.ItemsSource = employees;
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    employees = employeeService.GetAllEmployeesFromDepartment20();

        //    empDataGrid.ItemsSource = employees;
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var command = "select min(sal) as \"lowest salary\", job from emp\r\n" +
                "where job = 'clerk'\r\n" +
                "group by job;";

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
                    MinSalary = dataReader.GetValue(0),
                    Job = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var command = "select max(sal) as \"highest salary\", job from emp\r\n" +
                "where job = 'clerk'\r\n" +
                "group by job;";

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
                    MaxSalary = dataReader.GetValue(0),
                    Job = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var command = "select avg(sal), job from emp\r\n" +
                "group by job\r\n" +
                "order by avg(sal) desc;";

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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var command = "select min(sal), job from emp\r\n" +
                "where job != 'MANAGER'\r\n" +
                "group by job\r\n" +
                "order by min(sal) desc;";

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
                    MinSalary = dataReader.GetValue(0),
                    Job = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var command = "select max(e.sal), d.dname  from emp e\r\n" +
                "inner join dept d on e.deptno = d.deptno\r\n" +
                "group by  d.dname;";

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
                    MaxSalary = dataReader.GetValue(0),
                    DepartmentName = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var command = "select job, min(isnull(comm,0)) as \"lowest commision\" from emp\r\n" +
                "where comm > 0\r\n" +
                "group by job;";

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
                    Job = dataReader.GetValue(0),
                    MinSalary = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var command = "select avg(e.sal), d.dname, count(e.empno)  from emp e\r\n" +
                "inner join dept d \r\n" +
                "on e.deptno = d.deptno\r\n" +
                "group by d.dname\r\n" +
                "having count(e.empno) > 3;";

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
                    DepartmentName = dataReader.GetValue(1),
                    CountEmployee = dataReader.GetValue(2)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var command = "select job, avg(sal) from emp\r\n" +
                "group by job\r\n" +
                "having avg(sal) >= 3000;";

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
                    Job = dataReader.GetValue(0),
                    AverageSalary = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var command = "select d.dname, avg(e.sal) as \"monthly average salary\"," +
                " avg(e.sal * 12) as \"yearly average salary\"\r\n" +
                "from emp e inner join dept d\r\n" +
                "on e.deptno = d.deptno\r\n" +
                "group by d.dname;";

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
                    DepartmentName = dataReader.GetValue(0),
                    MonthlyAvgSalary = dataReader.GetValue(1),
                    YearlyAvgSalary = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            var command = "select (max(sal) - min(sal)) \r\n" +
                "as \"difference salary\" from emp;";

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
                    HighestSalDiffLowestSal = dataReader.GetValue(0)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            var command = "select d.dname, count(e.empno) as \"number of employees\" from emp e\r\n" +
                "inner join dept d\r\n" +
                "on e.deptno = d.deptno\r\n" +
                "group by d.dname\r\n" +
                "having count(e.empno) > 3;";

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
                    DepartmentName = dataReader.GetValue(0),
                    CountEmployee = dataReader.GetValue(1)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            var command = "select empno, ename from emp\r\n" +
                "group by empno, ename\r\n" +
                "having count(empno) = 1;";

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
                    EmployeNumber = dataReader.GetValue(1),
                    EmployeeName = dataReader.GetValue(0)
                };

                resultList.Add(resut);
            }

            empDataGrid.ItemsSource = resultList;
        }
    }
}
