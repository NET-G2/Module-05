using Lesson08.Models;
using Lesson08.Services;

namespace Lesson08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeService service = new EmployeeService();
            List<Employee> employees = service.GetAllEmployees();
            List<Department> departments = service.GetAllDepartments();

            Console.WriteLine("---- Employees ----");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine();
            Console.WriteLine("---- Departments ----");

            foreach (var department in departments)
            {
                Console.WriteLine(department);
            }

            // Find the lowest salary for Clerk
            Console.WriteLine();
            Console.WriteLine("---- Find the lowest salary for Clerk ----");

            var minSalary = employees.Where(x => x.Job.Trim().ToLower() == "clerk")
                .Min(x => x.Sal);


            Console.WriteLine(minSalary);

            // Show the average Salary for each job
            Console.WriteLine();
            Console.WriteLine("---- Show the average Salary for each job ----");

            var averageSalary = employees.GroupBy(x => x.Job)
                .Select(x => new
                {
                    Job = x.Key,
                    AverageSal = x.Average(s => s.Sal)
                });

            foreach(var res in averageSalary)
            {
                Console.WriteLine($"{res.Job} {res.AverageSal}");
            }

            // Find the minimal salary for each job
            Console.WriteLine();
            Console.WriteLine("---- Find the minimal salary for each job ---- ");

            var minSalaryForEachJob = employees.GroupBy(x => x.Job)
                .Select(x => new
                {
                    Job = x.Key,
                    MinSalary = x.Min(s => s.Sal)
                });

            foreach(var res in minSalaryForEachJob)
            {
                Console.WriteLine($"{res.Job} {res.MinSalary}");
            }

            // Find minimal salary for each job except MANAGER
            Console.WriteLine();
            Console.WriteLine("---- Find minimal salary for each job except MANAGER ----");

            var minSalaryExceptManager = employees
                .Where(x => x.Job.Trim().ToLower() != "manager")
                .GroupBy(x => x.Job)
                .Select(x => new
                {
                    Job = x.Key,
                    MinSal = x.Min(r => r.Sal)
                });

            foreach(var res in minSalaryExceptManager)
            {
                Console.WriteLine($"{res.Job} {res.MinSal}");
            }

            // For each department show max salary
            Console.WriteLine();
            Console.WriteLine("---- For each department show max salary ---- ");

            var maxSalaryForEachDept = employees.Join(departments,
                x => x.Deptno,
                r => r.Deptno,
                (x, r) => new
                {
                    DName = r.Dname,
                    x.Sal
                })
                .GroupBy(x => x.DName)
                .Select(x => new
                {
                    Dname = x.Key,
                    MaxSal = x.Max(s => s.Sal)
                });

            foreach(var res in maxSalaryForEachDept)
            {
                Console.WriteLine($"{res.Dname} {res.MaxSal}");
            }

            // Show average salaries for each department employing more than 3 people
            Console.WriteLine();
            Console.WriteLine("---- Show average salaries for each department employing more than 3 people ----");

            var deptAverageSalaries = employees.Join(departments,
                e => e.Deptno,
                d => d.Deptno,
                (e, d) => new
                {
                    Employee = e,
                    Department = d
                })
                .GroupBy(ed => ed.Department.Dname)
                .Where(x => x.Count() >= 3)
                .Select(x => new
                {
                    Dname = x.Key,
                    Average = x.Average(e => e.Employee.Sal)
                });

            foreach(var res in deptAverageSalaries)
            {
                Console.WriteLine($"{res.Dname} {res.Average.ToString("N2")}");
            }
        }
    }

    class ResList<Employee>
    {
        public string Key { get; set; }
    }

    class Res1
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}