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

        public static List<Employee> GetEmployee()
        {
            var command = "SELECT * FROM dbo.Emp " +
                "where empno = 7782;";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> GetMinSalEmp()
        {
            var command = "SELECT * FROM dbo.Emp " +
                "where sal = (select min(sal) from emp );";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> GetMinSalClerc()
        {
            var command = "select * from emp " +
                "where job = 'CLERK' and sal = (select min(sal) from emp where job = 'clerk' ) ";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
        }

        public static List<Employee> GetAvgSal()
        {
            var command = "select job , avg(sal) as avgSal from emp " +
                "group by job ";

            return DataAccessLayer.ExecuteQuery(command, ReaderToEmployeeList);
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
                    if (reader.FieldCount == 8)
                    {
                        Employee category = new Employee()
                        {

                            Empno = reader.IsDBNull(0) ? null : reader.GetInt32(0),
                            Ename = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Job = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Mgr = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            Hiredate = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            Sal = reader.IsDBNull(5) ? null : reader.GetDecimal(5),
                            Comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6),
                            Deptno = reader.IsDBNull(7) ? null : reader.GetInt32(7)
                        };
                        result.Add(category);
                    }else if (reader.FieldCount == 2)
                    {
                        Employee category = new Employee()
                        {
                            Job = reader.IsDBNull(0) ? null : reader.GetString(0),
                            Sal = reader.IsDBNull(1) ? null : reader.GetDecimal(1),
                        };
                        result.Add(category);
                    }
                }


            }return result;
        }

            
    }
}   
