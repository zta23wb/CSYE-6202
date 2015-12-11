using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class UserAccountDirectory
    {
        public List<UserAccount> UserAccountList { get; }

        public UserAccountDirectory()
        {
            this.UserAccountList = new List<UserAccount>();
        }

        public UserAccount AuthenticateUser(string u, string p)
        {
            foreach(UserAccount ua in UserAccountList)
            {
                if(ua.Username.Equals(u) && ua.Password.Equals(p))
                {
                    return ua;
                }
            }
            return null;
        }

        public UserAccount AddUserAccount(String username, String password, Employee employee, string role)
        {
            UserAccount userAccount = new UserAccount();
            userAccount.Username = username;
            userAccount.Password = password;
            userAccount.Employee = employee;
            userAccount.Role = role;
            UserAccountList.Add(userAccount);
            return userAccount;
        }

        public bool CheckIfUsernameIsUnique(String username)
        {
            foreach(UserAccount ua in UserAccountList)
            {
                if (ua.Username.Equals(username))
                    return false;
            }
            return true;
        }

    }
}
