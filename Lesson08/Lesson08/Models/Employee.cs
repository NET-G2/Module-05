using System;

namespace Lesson08.Models
{
    public class Employee
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime Hiredate { get; set; }
        public decimal Sal { get; set; }
        public decimal? Comm { get; set; }
        public int Deptno { get; set; }

        public override string ToString()
        {
            return $"Empno {Empno}, Ename {Ename}, Job {Job}, Mgr {Mgr}, Hiredate {Hiredate.ToString("dd-mm-yyyy")}, Sal {Sal}, Comm {Comm}, Deptno {Deptno}";
        }
    }
}
