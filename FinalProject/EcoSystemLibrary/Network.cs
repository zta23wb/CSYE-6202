using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Network
    {
        public string Name { set; get; }
        public EnterpriseDirectory EnterpriseList { get; }

        public Network()
        {
            this.EnterpriseList = new EnterpriseDirectory();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
