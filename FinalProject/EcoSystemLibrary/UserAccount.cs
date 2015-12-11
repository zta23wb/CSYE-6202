using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class UserAccount
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public Employee Employee { set; get; }
        public string Role { set; get; }
        public WorkQueue WorkQueue { set; get; }
        public MessageQueue MessageQueue { set; get; }

        public UserAccount()
        {
            this.WorkQueue = new WorkQueue();
            this.MessageQueue = new MessageQueue();
        }

    }
}
