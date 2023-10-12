using Lesson08.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson08.Services
{
    internal class EmployeeService
    {
        private readonly DataAccessLayer _database;

        public EmployeeService()
        {
            _database = new DataAccessLayer();
        }

        public List<Department> GetAllDepartments()
        {
            var command = "SELECT * FROM dbo.DEPT;";

            TryExecuteQuery(command, out List<Department> result);
            
            return result;
        }

        public List<Employee> GetAllEmployees()
        {
            var command = "SELECT * FROM dbo.Emp;";

            TryExecuteQuery(command, out List<Employee> result);

            return result;
        }

        public List<Employee> GetAllEmployeesFromDepartment20()
        {
            var command = "SELECT * FROM dbo.Emp WHERE Deptno = 20;";

            TryExecuteQuery(command, out List<Employee> result);

            return result;
        }

        private void TryExecuteQuery(string command, out List<Employee> result)
        {
            try
            {
                result = _database.ExecuteQuery(command, ReaderToEmployeeList);

                return;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.", "Error executing query.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}.", "Something went wrong.");
            }

            result = new List<Employee>();
        }

        private void TryExecuteQuery(string command, out List<Department> result)
        {
            try
            {
                result = _database.ExecuteQuery(command, ReaderToDepartmentList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new List<Department>();
            }
        }

        private List<Department> ReaderToDepartmentList(SqlDataReader reader)
        {
            if (reader is null)
            {
                Console.WriteLine("Error: Data reader is null.");
                return new List<Department>();
            }

            if (!reader.HasRows)
            {
                return new List<Department>();
            }

            List<Department> result = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.Deptno = (int)reader.GetDecimal(0);
                department.Dname = reader.GetString(1);
                department.Location = reader.GetString(2);

                result.Add(department);
            }

            return result;
        }

        private List<Employee> ReaderToEmployeeList(SqlDataReader reader)
        {
            if (reader is null)
            {
                Console.WriteLine("Error: Data reader is null.");
                return new List<Employee>();
            }

            List<Employee> result = new List<Employee>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Empno = (int)reader.GetDecimal(0);
                    employee.Ename = reader.GetString(1);
                    employee.Job = reader.GetString(2);
                    employee.Mgr = reader.IsDBNull(3) ? null : (int)reader.GetDecimal(3);
                    employee.Hiredate = reader.GetDateTime(4);
                    employee.Sal = reader.GetDecimal(5);
                    employee.Comm = reader.IsDBNull(6) ? null : reader.GetDecimal(6);
                    employee.Deptno = (int)reader.GetDecimal(7);

                    result.Add(employee);
                }
            }

            return result;
        }
    }
}
