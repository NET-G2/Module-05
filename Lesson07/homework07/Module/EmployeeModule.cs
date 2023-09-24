using homework07.Models;
using homework07.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Module
{
    internal class EmployeeModule
    {

        private readonly DAL _database;

        public EmployeeModule()
        {
            _database = new DAL();
        }

        public List<Employee> GetAllEmployees()
        {
            var command = "SELECT * FROM dbo.Emp;";

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
                    employee.EmployeeId = reader.GetInt32(0);
                    employee.EmployeeName = reader.GetString(1);
                    employee.JobName = reader.GetString(2);
                    employee.ManagerId = reader.GetInt32(3);
                    employee.HireDate = reader.GetDateTime(4);
                    employee.Salary = reader.GetDecimal(5);
                    employee.Commition = reader.GetInt32(6);
                    employee.DepartmentId = reader.GetInt32(7);

                    result.Add(employee);
                }
            }

            return result;
        }
    }
}
