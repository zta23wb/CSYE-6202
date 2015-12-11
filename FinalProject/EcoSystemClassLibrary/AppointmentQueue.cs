using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class AppointmentQueue
    {
        public List<Appointment> AppointmentList { set; get; }

        public AppointmentQueue()
        {
            this.AppointmentList = new List<Appointment>();
        }

        public Appointment AddAppointment()
        {
            Appointment a = new Appointment();
            AppointmentList.Add(a);
            return a;
        }

        public void RemoveAppointment(Appointment a)
        {
            AppointmentList.Remove(a);
        }

        public Appointment SearchAppointment(int appointmentID)
        {
            foreach(Appointment app in AppointmentList)
            {
                if(app.AppointmentID == appointmentID)
                {
                    return app;
                }
            }
            return null;
        }
    }
}
