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
    internal class DepartmentModule
    {
        private readonly DAL _database;

        public DepartmentModule()
        {
            _database = new DAL();
        }

        public List<Department> GetAllDepartments()
        {
            var command = "SELECT * FROM dbo.DEPT;";

            TryExecuteQuery(command, out List<Department> result);

            return result;
        }

        private void TryExecuteQuery(string command, out List<Department> result)
        {
            try
            {
                result = _database.ExecuteQuery(command, ReaderToDepartmentList);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.", "Error executing query.");
                result = new List<Department>();
            }
            catch (Exception ex)
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
                Console.WriteLine("Data not available...");
                return new List<Department>();
            }

            List<Department> result = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.DepartmentId = reader.GetInt32(0);
                department.DepartmentName = reader.GetString(1);
                department.Location = reader.GetString(2);

                result.Add(department);
            }

            return result;
        }
    }
}
