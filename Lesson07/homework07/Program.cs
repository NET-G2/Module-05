using homework07.Models;
using homework07.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace homework07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeModule employeeModule = new EmployeeModule();
            List<Employee> employees = employeeModule.GetAllEmployees();

            DepartmentModule departmentModule = new DepartmentModule();
            List<Department> departments = departmentModule.GetAllDepartments();

            SalaryGradeModule salaryGradeModule = new SalaryGradeModule();
            List<SalaryGrade> salaryGrades = salaryGradeModule.GetAllSalaryGrades();

            #region Get all Employees

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}

            #endregion

            #region Get all Department

            //foreach(Department department in departments)
            //{
            //    Console.WriteLine(department);
            //}

            #endregion

            #region Get all Salary Grade

            //foreach(SalaryGrade s in salaryGrades)
            //{
            //    Console.WriteLine(s);
            //}

            #endregion

            #region Task 1

            // Find the lowest salary for Clerk

            //var minSalary = employees.Where(x => x.JobName.Trim().ToLower() == "clerk")
            //    .Min(x => x.Salary);

            //Console.WriteLine("Min salary : " + minSalary);
            #endregion

            #region Task 2

            // Find the highest salary for CLERK 

            //var result = employees.Where(x => x.JobName.ToUpper() == "CLERK")
            //    .Max(s => s.Salary);

            //Console.WriteLine("Max salary : " + result);
            #endregion

            #region Task 3

            // Show the average salary for each job.

            //var result = employees.GroupBy(e => e.JobName)
            //    .Select(g => new
            //    {
            //        jobName = g.Key,
            //        salary = g.Average(e2 => e2.Salary),
            //    });

            //foreach(var employee in result)
            //{
            //    Console.WriteLine($"{employee.jobName}  {employee.salary.ToString("N2")} ");
            //}
            #endregion

            #region Task 4

            //  Find the minimal salary for each job except MANAGER.

            //var result = employees.Where(e => e.JobName.ToUpper() != "MANAGER")
            //    .GroupBy(e => e.JobName)
            //    .Select(g => new
            //    {
            //        jobName = g.Key,
            //        minSalary = g.Min(e2 => e2.Salary)
            //    });

            //foreach (var employee in result)
            //{
            //    Console.WriteLine($" {employee.jobName} -> {employee.minSalary}");
            //}

            #endregion

            #region Task 5

            // For each job in each department show maximal salary.

            //var result = employees.Join(departments,
            //    e => e.DepartmentId,
            //    d => d.DepartmentId,
            //    (e, d) => new
            //    {
            //        departName = d.DepartmentName,
            //        e.Salary
            //    })
            //    .GroupBy(d => d.departName)
            //    .Select(e => new
            //    {
            //        dName = e.Key,
            //        maxSal = e.Max(e2 => e2.Salary)
            //    });

            //foreach(var employee in result)
            //{
            //    Console.WriteLine($" {employee.dName} -> {employee.maxSal}");
            //}

            #endregion

            #region Task 6

            // For each job find minimal commision.

            //var result = employees.GroupBy(e => e.JobName)
            //    .Select(g => new
            //    {
            //        jobName = g.Key,
            //        minComm = g.Min(e2 => e2.Commition)
            //    });

            //foreach(var emp in result)
            //{
            //    Console.WriteLine($" {emp.jobName} -> {emp.minComm}");
            //}
            #endregion

            #region Task 7

            // Show the average salary for each department employing more than 3 people.

            //var result = employees.Join(departments,
            //    e => e.DepartmentId,
            //    d => d.DepartmentId,
            //    (e, d) => new
            //    {
            //        Employee = e,
            //        Department = d
            //    })
            //    .GroupBy(ed => ed.Department.DepartmentName)
            //    .Where(ed => ed.Count() >= 3)
            //    .Select(x => new
            //    {
            //        dName = x.Key,
            //        avgSal = x.Average(ex => ex.Employee.Salary)
            //    });

            //foreach(var employee in result)
            //{
            //    Console.WriteLine($" {employee.dName} -> {employee.avgSal.ToString("N2")} ");
            //}

            #endregion

            #region Task 8

            // Show all jobs with the average salary not less than 3000.

            //var result = employees.GroupBy(e => e.JobName)
            //    .Where(eg => eg.Average(x => x.Salary) >= 3000)
            //    .Select(e => new
            //    {
            //        jobName = e.Key,
            //        avgSal = e.Average(e2 => e2.Salary)
            //    });

            //foreach(var emp in result)
            //{
            //    Console.WriteLine($" {emp.jobName} -> {emp.avgSal.ToString("N3")}");
            //}

            #endregion

            #region Task 9

            // Find the average salary (monthly), and average yearly income for each department.

            //var result = employees.Join(departments,
            //    e => e.DepartmentId,
            //    d => d.DepartmentId,
            //    (e, d) => new
            //    {
            //        dName = d.DepartmentName,
            //        e.Salary
            //    })
            //    .GroupBy(d => d.dName)
            //    .Select(ed => new
            //    {
            //        deptName = ed.Key,
            //        avgSalMonth = ed.Average(e => e.Salary),
            //        avgSalYearly = ed.Average(e => e.Salary * 12)
            //    });

            //foreach(var emp in result)
            //{
            //    Console.WriteLine($" {emp.deptName} --> M : {emp.avgSalMonth.ToString("N2")}" +
            //        $" --> Y : {emp.avgSalYearly.ToString("N2")}");
            //}

            #endregion

            #region Task 10

            // Find the difference between the highest and the lowest salary .

            //var result = employees.Max(e => e.Salary) - employees.Min(e => e.Salary);

            //Console.WriteLine("MaxSalary - MinSalary = " + result);

            #endregion
        }
    }
}
