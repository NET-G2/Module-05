using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson08.Models
{
    internal class Department
    {
        public int Deptno { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"Deptno {Deptno}, Dname {Dname}, Location {Location}";
        }
    }
}
