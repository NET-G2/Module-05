using homework07.Models.DataAccesLayer;
using homework07.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Module
{
    internal class SalaryGradeModule
    {
        private readonly DAL _database;

        public SalaryGradeModule()
        {
            _database = new DAL();
        }

        public List<SalaryGrade> GetAllSalaryGrades()
        {
            var command = "SELECT * FROM dbo.SALGRADE;";

            TryExecuteQuery(command, out List<SalaryGrade> result);

            return result;
        }

        private void TryExecuteQuery(string command, out List<SalaryGrade> result)
        {
            try
            {
                result = _database.ExecuteQuery(command, ReaderToSalaryGradeList);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.", "Error executing query.");
                result = new List<SalaryGrade>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new List<SalaryGrade>();
            }
        }

        private List<SalaryGrade> ReaderToSalaryGradeList(SqlDataReader reader)
        {
            if (reader is null)
            {
                Console.WriteLine("Error: Data reader is null.");
                return new List<SalaryGrade>();
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("Data not available...");
                return new List<SalaryGrade>();
            }

            List<SalaryGrade> result = new List<SalaryGrade>();

            while (reader.Read())
            {
                SalaryGrade salaryGrade = new SalaryGrade();
                salaryGrade.Grade = reader.GetInt32(0);
                salaryGrade.HighestSalary = reader.GetDecimal(1);
                salaryGrade.LowastSalary = reader.GetDecimal(2);

                result.Add(salaryGrade);
            }

            return result;
        }
    }
}
