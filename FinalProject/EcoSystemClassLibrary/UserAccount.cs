using EcoSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EcoSystemLibrary
{
    public class UserAccount: Person
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }
        public int UserAccountID { set; get; }
        public int EnterpriseID { set; get; }
        public AppointmentQueue AppointmentQueue { set; get; }
     
        public UserAccount()
        {
            this.AppointmentQueue = new AppointmentQueue();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

    }
}
