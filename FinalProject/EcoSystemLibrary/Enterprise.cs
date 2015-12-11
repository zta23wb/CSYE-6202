using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public abstract class Enterprise: Organization
    {
        public enum EnterpriseType
        {
            None,
            Hospital
        }

        public EnterpriseType Type { set; get; }
        public OrganizationDirectory OrganizationDirectory { set; get; }
        public Enterprise() {
            this.Type = EnterpriseType.Hospital;
            OrganizationDirectory = new OrganizationDirectory();
        }
    }
}
