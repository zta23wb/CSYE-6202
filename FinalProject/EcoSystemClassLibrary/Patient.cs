using EcoSystemLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystemClassLibrary
{
    public class Patient: UserAccount
    {
        public string BloodType { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
