using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class EcoSystem: Organization
    { 
        public static EcoSystem Business { set; get; }
        public List<Network> NetworkList { set; get; }

        public static EcoSystem GetInstance()
        {
            if(Business == null)
            {
                Business = new EcoSystem();
            }

            return Business;
        }

        private EcoSystem()
        {
            NetworkList = new List<Network>();
        }

        public Network AddNetwork(string s)
        {
            Network network = new Network();
            network.Name = s;
            NetworkList.Add(network);
            return network;
        }

    }
}
