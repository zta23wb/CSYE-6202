using EcoSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Enterprise
    {
        public int EnterpriseID { set; get; }
        public string Name { set; get; }
        public string Location { set; get; }
        public UserAccountDirectory UserAccountDirectory { set; get; }
        public AppointmentQueue AppointmentQueue { set; get; }
        public PatientDirectory patientDirectory { set; get; }

        public Enterprise() {
            this.UserAccountDirectory = new UserAccountDirectory();
            this.AppointmentQueue = new AppointmentQueue();
            patientDirectory = new PatientDirectory();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
