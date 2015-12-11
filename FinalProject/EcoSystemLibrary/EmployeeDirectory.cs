using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class EmployeeDirectory
    {
        public List<Employee> EmployeeList { set; get; }

        public EmployeeDirectory()
        {
            this.EmployeeList = new List<Employee>();
        }

        public Employee AddEmployee(string name)
        {
            Employee employee = new Employee();
            employee.Name = name;
            EmployeeList.Add(employee);
            return employee;
        }
    }
}
