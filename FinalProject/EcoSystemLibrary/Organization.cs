using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public abstract class Organization
    {
        public string Name { set; get; }
        public WorkQueue WorkQueue { set; get; }
        public EmployeeDirectory EmployeeDirectory { set; get; }
        public UserAccountDirectory UserAccountDirectory { set; get; }
        public int OrganizationID { set; get; }
        public static int counter = 0;

        public enum OrganizationType
        {
            None,
            Admin,
            Regular,
            Doctor,
            Nurse,
            Patient
        }

        public Organization()
        {
            counter++;
            WorkQueue = new WorkQueue();
            EmployeeDirectory = new EmployeeDirectory();
            UserAccountDirectory = new UserAccountDirectory();
            OrganizationID = counter;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
