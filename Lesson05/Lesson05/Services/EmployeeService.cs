using Lesson05.DAL;
using Lesson05.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson05.Services
{
    internal static class EmployeeService
    {
        public static async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var command = "SELECT * FROM dbo.Emp;";

            return await DataAccessLayer.ExecuteQueryAsync(command, ReaderToEmployeeList);
        }

        public static List<Employee> GetAllEmployees()
        {
            var command = "SELECT * FROM dbo.Emp;";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> GetEmployeeByEmpno(int empno)
        {
            var command = "SELECT * FROM dbo.Emp " +
                           $"WHERE empno = {empno}";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> MinSalInfirm()
        {
            var command = "Select * from emp " +
                          "where sal = any(select min(sal)" +
                                      "from emp);";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> WorkAsFord()
        {
            var command = "Select * from emp" +
                " where job = (select job from emp" +
                              " where ename = 'Ford');";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> MinSalWorkAsClerk()
        {
            var command = "Select * from emp" +
                " where sal = (select min(sal) from emp" +
                " where job = 'CLERK')";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> MaxSalWorkAsClerk()
        {
            var command = "Select * from emp" +
                " where sal = (select max(sal) from emp" +
                " where job = 'CLERK')";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> AverageSalaryInEachJob()
        {
            var command = "Select job, avg(sal) 'Average salary' from emp" +
                          " group by job";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployee);
        }

        private static List<Employee> ReaderToEmployeeList(SqlDataReader reader)
        {
            if (reader is null)
            {
                MessageBox.Show("Error: Data reader is null.");
                return new List<Employee>();
            }

            List<Employee> result = new List<Employee>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee category = new Employee
                    {
                        Empno = reader.GetInt32(0),
                        Ename = reader.GetString(1),
                        Job = reader.GetString(2),
                        Mgr = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                        Hiredate = reader.GetDateTime(4),
                        Sal = reader.GetDecimal(5),
                        Comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                        Deptno = reader.GetInt32(7)
                    };

                    result.Add(category);
                }
            }

            return result;
        }

        private static List<Employee> ReaderToEmployee(SqlDataReader reader)
        {
            if (reader is null)
            {
                MessageBox.Show("Error: Data reader is null.");
                return new List<Employee>();
            }

            List<Employee> result = new List<Employee>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee category = new Employee
                    {
                        Job = reader.GetString(0),
                        Sal = reader.GetDecimal(1)
                    };

                    result.Add(category);
                }
            }

            return result;
        }
    }
}
