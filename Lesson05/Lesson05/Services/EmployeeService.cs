using Lesson05.DAL;
using Lesson05.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Lesson05.Services
{
    internal class EmployeeService
    {
        private readonly DataAccessLayer _database;

        public EmployeeService()
        {
            _database = new DataAccessLayer();
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
                MessageBox.Show($"Database error: {ex.Message}.", "Error executing query.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}.", "Something went wrong.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            result = new List<Employee>();
        }

        private List<Employee> ReaderToEmployeeList(SqlDataReader reader)
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
    }
}
