using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class UserAccountDirectory
    {
        public List<UserAccount> UserAccountList { set; get; }

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

        public UserAccount AddUserAccount()
        {
            UserAccount userAccount = new UserAccount();
            UserAccountList.Add(userAccount);
            return userAccount;
        }

        public bool IfUsernameIsUnique(String username)
        {
            foreach(UserAccount ua in UserAccountList)
            {
                if (ua.Username.Equals(username))
                    return false;
            }
            return true;
        }

        public void RemoveUser(int userID)
        {
            UserAccount ua = SearchUser(userID);
            UserAccountList.Remove(ua);
        }

        public UserAccount SearchUser(int userID)
        {
            foreach (UserAccount ua in UserAccountList)
            {
                if (ua.UserAccountID == userID)
                {
                    return ua;
                }
            }
            return null;
        }
    }
}
