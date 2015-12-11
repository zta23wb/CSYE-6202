using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class EnterpriseDirectory
    {
        public List<Enterprise> EnterpriseList { set; get; }

        public EnterpriseDirectory()
        {
            EnterpriseList = new List<Enterprise>();
        }

        public Enterprise AddHospitalEnterprise(string name)
        {
            Enterprise e = new HospitalEnterprise(name);
            EnterpriseList.Add(e);
            return e;
        }
    }
}
