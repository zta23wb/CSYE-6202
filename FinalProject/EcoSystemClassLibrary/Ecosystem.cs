using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class EcoSystem
    { 
        public static EcoSystem Business { set; get; }
        public EnterpriseDirectory EnterpriseDirectory { set; get; }
        public static UserAccountDirectory SystemAdminDirectory { set; get; }

        public EcoSystem()
        {
            this.EnterpriseDirectory = new EnterpriseDirectory();
            Configure();
        }

        private static void Configure()
        {
            SystemAdminDirectory = new UserAccountDirectory();
            UserAccount ua = SystemAdminDirectory.AddUserAccount();
            ua.Username = "sysadmin";
            ua.Password = "sysadmin";
            ua.Role = "System Administration";
        }

        public UserAccount AuthenticateUser(string u, string p)
        {
            foreach (UserAccount ua in SystemAdminDirectory.UserAccountList)
            {
                if (ua.Username.Equals(u) && ua.Password.Equals(p))
                {
                    return ua;
                }
            }

            foreach (Enterprise enterprise in EnterpriseDirectory.EnterpriseList)
            {
                foreach (UserAccount ua in enterprise.UserAccountDirectory.UserAccountList)
                {
                    if (ua.Username.Equals(u) && ua.Password.Equals(p))
                    {
                        return ua;
                    }
                }
            }
            return null;
        }
    }
}
