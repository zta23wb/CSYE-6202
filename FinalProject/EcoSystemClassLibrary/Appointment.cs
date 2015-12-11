using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Appointment
    {
        public int AppointmentID { set; get; }
        public string Name { set; get; }
        public string Reson { set; get; }
        public int EnterpriseID { set; get; }
        public UserAccount Doctor { set; get; }
        public UserAccount Nurse { set; get; }
        public UserAccount Patient { set; get; }
        public double Cost { set; get; }
        public DateTime RequestDate { set; get; }

        public Appointment()
        {
        }
    }
}
