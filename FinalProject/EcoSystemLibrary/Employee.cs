using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Employee
    {
        public string Name { set; get; }
        public int ID { set; get; }
        private static int count = 1;

        public Employee()
        {
            count++;
            ID = count;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
