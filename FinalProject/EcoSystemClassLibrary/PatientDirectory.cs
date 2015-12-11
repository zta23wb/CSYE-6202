using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystemClassLibrary
{
    public class PatientDirectory
    {
        public List<Patient> PatientList { set; get; }

        public PatientDirectory()
        {
            this.PatientList = new List<Patient>();
        }

        
        public Patient AddPatient()
        {
            Patient patient = new Patient();
            PatientList.Add(patient);
            return patient;
        }
      
        public bool PatientNameIsUnique(String name)
        {
            foreach (Patient p in PatientList)
            {
                if (p.Username.Equals(name))
                    return false;
            }
            return true;
        }

        public Patient SearchPatient(int patientID)
        {
            foreach(Patient patient in PatientList)
            {
                if(patient.UserAccountID == patientID)
                {
                    return patient;
                }
            }
            return null;
        }
    }
}
