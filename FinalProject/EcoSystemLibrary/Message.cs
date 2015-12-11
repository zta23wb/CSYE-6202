using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Message
    {
        public List<UserAccount> SenderList { set; get; }
        public List<UserAccount> ReceiverList { set; get; }
        public DateTime SendTime { get; }
        public DateTime OpenTime { set; get; }

        public Message()
        {
            this.SendTime = DateTime.Now;
        }
    }
}
