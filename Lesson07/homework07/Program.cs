using homework07.Models;
using homework07.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeModule employeeModule = new EmployeeModule();
            List<Employee> employees =employeeModule.GetAllEmployees();

            DepartmentModule departmentModule = new DepartmentModule();
            List<Department> departments =departmentModule.GetAllDepartments();

            SalaryGradeModule salaryGradeModule = new SalaryGradeModule();
            List<SalaryGrade> salaryGrades = salaryGradeModule.GetAllSalaryGrades();

            foreach( Employee employee in employees )
            {
                Console.WriteLine(employee);
            }
        }
    }
}
