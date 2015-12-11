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

        public Enterprise AddEnterprise()
        {
            Enterprise e = new Enterprise();
            EnterpriseList.Add(e);
            return e;
        }

        public void RemoveEnterprise(Enterprise e)
        {
            EnterpriseList.Remove(e);
        }

        public Enterprise SearchEnterprise(int e)
        {
            foreach (Enterprise enterprise in EnterpriseList)
            {
                if (enterprise.EnterpriseID == e)
                {
                    return enterprise;
                }
            }
            return null;
        }
    }
}
