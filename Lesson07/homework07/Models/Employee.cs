using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.Models
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobName { get; set; }
        public int ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public double Commition { get; set; }
        public int DepartmentId { get; set; }

        public Employee(int employeeId, string employeeName, string jobName, int managerId, DateTime hireDate, decimal salary, double commition, int departmentId)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            JobName = jobName;
            ManagerId = managerId;
            HireDate = hireDate;
            Salary = salary;
            Commition = commition;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return $" Employee Id : {EmployeeId} ; Employee name : {EmployeeName}; Job name : {JobName};" +
                $" Manager Id : {ManagerId}; Hire date : {HireDate}; Salary : {Salary}; " +
                $" Commition : {Commition}; Department Id : {DepartmentId};";
        }
    }
}
