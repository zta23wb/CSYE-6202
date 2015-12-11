using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class OrganizationDirectory
    {
        public List<Organization> OrganizationList { set; get; }

        public OrganizationDirectory()
        {
            OrganizationList = new List<Organization>();
        }

        public Organization AddOrganization(Organization.OrganizationType orgType)
        {
            Organization org = null;
            string orgTypeValue = orgType.ToString();
            if(orgTypeValue.Equals("Admin"))
            {
                org = new AdminOrganization();
                OrganizationList.Add(org);
            }
            if (orgTypeValue.Equals("Regular"))
            {
                org = new RegularOrganization();
                OrganizationList.Add(org);
            }
            if (orgTypeValue.Equals("Doctor"))
            {
                org = new DoctorOrganization();
                OrganizationList.Add(org);
            }
            if (orgTypeValue.Equals("Nurse"))
            {
                org = new NurseOrganization();
                OrganizationList.Add(org);
            }
            if (orgTypeValue.Equals("Patient"))
            {
                org = new PatientOrganization();
                OrganizationList.Add(org);
            }
            return org;
        }
    }
}
