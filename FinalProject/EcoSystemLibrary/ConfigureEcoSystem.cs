using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class ConfigureEcoSystem
    {
        public static EcoSystem Configure()
        {
            EcoSystem system = EcoSystem.GetInstance();
            Employee employee = system.EmployeeDirectory.AddEmployee("System Admin");
            UserAccount ua = system.UserAccountDirectory.AddUserAccount("sysadmin", "sysadmin", employee, "System Admin");
            return system;
        }
    }
}
