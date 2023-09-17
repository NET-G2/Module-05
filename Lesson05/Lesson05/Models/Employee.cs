using System;

namespace Lesson05.Models
{
    internal class Employee
    {
        public int? Empno { get; set; }
        public string? Ename { get; set; }
        public string? Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public decimal? Sal { get; set; }
        public decimal? Comm { get; set; }
        public int? Deptno { get; set; }

        public Employee() { }

        public Employee(int? empno, string? ename, string? job, int? mgr, DateTime? hiredate, decimal? sal, decimal? comm, int? deptno)
        {
            Empno = empno;
            Ename = ename;
            Job = job;
            Mgr = mgr;
            Hiredate = hiredate;
            Sal = sal;
            Comm = comm;
            Deptno = deptno;
        }

        public Employee(string? job, decimal? sal)
        {
            Job = job;
            Sal = sal;
        }
    }
}
