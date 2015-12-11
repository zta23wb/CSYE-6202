using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class MessageQueue
    {
        public List<Message> MessageList { get; }

        public MessageQueue()
        {
            this.MessageList = new List<Message>();
        }
    }
}
