using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoSystemLibrary
{
    public class WorkQueue
    {
        public List<WorkRequest> WorkRequestList { get; }

        public WorkQueue()
        {
            this.WorkRequestList = new List<WorkRequest>();
        }
    }
}
