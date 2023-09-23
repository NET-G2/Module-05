using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Models
{
    internal class SalaryGrade
    {
        public int Grade { get; set; }
        public decimal HighestSalary { get; set;}
        public decimal LowastSalary { get; set;}

        public SalaryGrade() { }

        public SalaryGrade(int grade, decimal hisalGrade, decimal losalGrade)
        {
            Grade = grade;
            HighestSalary = hisalGrade;
            LowastSalary = losalGrade;
        }

        public override string ToString()
        {
            return $" Grade : {Grade} ;  Highest salary : {HighestSalary} ; " +
                $" Lowest salary : {LowastSalary} ; ";
        }
    }
}
