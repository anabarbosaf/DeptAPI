using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentProjectAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department {  get; set; }
        public int DepartmentId { get; set; }
        public int Rg {  get; set; }
        public string PhotoFileName { get; set; }
    }
}
