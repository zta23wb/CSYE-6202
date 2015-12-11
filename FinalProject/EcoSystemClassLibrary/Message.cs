using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class Message
    {
        public int SenderID { set; get; }
        public int ReceiverID { set; get; }
        public int MessageID { set; get; }
        public DateTime SendTime { set; get; }
        public DateTime OpenTime { set; get; }
        public string message { set; get; }

        public Message()
        {
            this.SendTime = DateTime.Now;
        }
    }
}
