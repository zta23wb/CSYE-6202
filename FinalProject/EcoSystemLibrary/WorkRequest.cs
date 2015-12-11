using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class WorkRequest
    {
        public string Message { set; get; }
        public UserAccount Sender { set; get; }
        public UserAccount Receiver { set; get; }
        public string status { set; get; }
        public DateTime RequestDate { get; }
        public DateTime ResolveDate { set; get; }

        public WorkRequest()
        {
            this.RequestDate = DateTime.Now;
        }
    }
}
