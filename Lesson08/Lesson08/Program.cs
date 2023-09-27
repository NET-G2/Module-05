using Lesson08.Models;
using Lesson08.Services;
using System.Xml.Schema;

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

            /* 8. Show all jobs with the average salary not less than 3000 */
            Console.WriteLine();
            Console.WriteLine("---- Show all jobs with the average salary not less than 3000 ----- ");

            var allJob = employees.GroupBy(g => g.Job)
                .Where(s => s.Average(e => e.Sal) >= 3000);

            foreach(var res in allJob)
            {
                Console.WriteLine($"{res}");
            }

            /* 9. Find the average salary (monthly), and average yearly income for each department */
            Console.WriteLine();
            Console.WriteLine("---- Find the average salary (monthly), and average yearly income for each department ----- ");

            var deptAvr = employees.GroupBy(d => d.Deptno)
                .Select(f => new
                {
                    Departments = f.Key,
                    AvgMonth = f.Average(s => s.Sal),
                    AvgYear = f.Average(s => s.Sal) * 12
                }
                );
            foreach(var res in deptAvr)
            { Console.WriteLine($"{res.Departments}, {res.AvgMonth}, {res.AvgYear}"); }

            /* 10. Find the difference between the highest and the lowest salary */
            Console.WriteLine();
            Console.WriteLine("---- Find the difference between the highest and the lowest salary ----- ");

            var defferenceSal = employees.GroupBy(s => s.Empno)
                .Select(f => new
                {
                    Empno = f.Key,
                    hightSal = f.Max(s => s.Sal),
                    minSal = f.Min(s => s.Sal),
                    deference = f.Max(s => s.Sal) - f.Min(s => s.Sal)
                });

            foreach(var res in defferenceSal)
            {
                Console.WriteLine($"{res.Empno}, max: {res.hightSal}, min: {res.minSal}, diference: {res.deference}");
            }

            /* 11. Find department employing more than 3 people */
            Console.WriteLine();
            Console.WriteLine("---- Find department employing more than 3 people ----- ");

            var empMoreThan = employees.GroupBy(s => s.Deptno)
                .Where(e => e.Count() > 3);

            foreach(var emp in empMoreThan)
            {
                Console.WriteLine($"{emp}");
            }

            /* 12. Check if all personal numbers are unique */
            Console.WriteLine();
            Console.WriteLine("---- Check if all personal numbers are unique ----- ");

            var uniqueNum = employees.GroupBy(s => s.Empno)
                .All(s => s.Count() > 1);

            if (uniqueNum)
            {
                Console.WriteLine("All personal numbers are unique.");
            }
            else
            {
                Console.WriteLine("Not all personal numbers are unique.");
            }

            /* 13. Find the lowest salary paid to employees working under each manager. Eliminate groupswith minimal salary below 1000. Present data by increasing values of salary */
            Console.WriteLine();
            Console.WriteLine("---- Find the lowest salary paid to employees working under each manager. Eliminate groupswith minimal salary below 1000. Present data by increasing values of salary ----- ");

            var lowesSalUnderMan = employees.Where(s => s.Sal >= 1000)
                .GroupBy(s => s.Mgr)
                .Select(n => new
                {
                    Mgr = n.Key,
                    LowesSal = n.Min(s => s.Sal)
                })
                .OrderBy(r => r.LowesSal);

            foreach(var emp in lowesSalUnderMan)
            {
                Console.WriteLine($"{emp.Mgr}, {emp.LowesSal}");
            }


            /* 14. How many people work in departmnet located in Dallas */
            Console.WriteLine();
            Console.WriteLine("---- How many people work in departmnet located in Dallas ----- ");

            var locatDallas = (from emp in employees    
                              join dept in departments on emp.Deptno equals dept.Deptno
                              where dept.Location == "Dallas"
                              select emp.Empno).Count();

            Console.WriteLine($" {locatDallas} people work in departmnet located in Dallas ");

            /* 15. For each grade find the maximal salary earned by a person having salary in this grade */
            Console.WriteLine();
            Console.WriteLine("---- For each grade find the maximal salary earned by a person having salary in this grade ----- ");

            var maxSalGrade = employees.GroupBy(s => s.Deptno)
                .Select(n => new
                {
                    dept = n.Key,
                    maxSal = n.Max(s => s.Sal)
                });

            foreach (var item in maxSalGrade)
            {
                Console.WriteLine($"{item.dept}, {item.maxSal}");
            }

            /* 16. Which values of salaries occur more than once? */
            Console.WriteLine();
            Console.WriteLine("---- Which values of salaries occur more than once ----- ");

            var valuesMoreOne = employees.GroupBy(s => s.Sal)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);

            foreach (var item in valuesMoreOne)
            {
                Console.WriteLine($" salary {item}");
            }

            /* 17. What is the average salary for people with salaries in the second grade? */
            Console.WriteLine();
            Console.WriteLine("---- What is the average salary for people with salaries in the second grade ----- ");

            /* 18. For each manager show number of people supervised by him */
            Console.WriteLine();
            Console.WriteLine("---- For each manager show number of people supervised by him ----- ");

            var superviseByMgr = employees.Where(s => s.Mgr != null)
                .GroupBy(s => s.Mgr.Value)
                .Select(f => new
                {
                    ManagerId = f.Key,
                    SupervisedCount = f.Count()
                });
            foreach (var item in superviseByMgr)
            {
                Console.WriteLine($" {item.ManagerId}, {item.SupervisedCount}");
            }


            /* 19. Find total yearly income earned by people earning salaries from the first grade */



        }
    }

    
}