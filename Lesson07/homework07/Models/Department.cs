using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Models
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }

        public Department() { }

        public Department(int departmentId, string departmentName, string location)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            Location = location;
        }

        public override string ToString()
        {
            return $" Department Id : {DepartmentId}; " +
                $"Department name : {DepartmentName}; Location : {Location};";
        }
    }
}
