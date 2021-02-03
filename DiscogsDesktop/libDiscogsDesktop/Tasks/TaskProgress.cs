using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDiscogsDesktop.Tasks
{
    public sealed class TaskProgress
    {
        public bool Determinate { get; }

        public int Percentage { get; }

        public string Info { get; }

        public TaskProgress(bool determinate, int percentage, string info)
        {
            this.Determinate = determinate;
            this.Percentage = percentage;
            this.Info = info;
        }

        public static TaskProgress Det(int percentage, string info)
        {
            return new TaskProgress(true, percentage, info);
        }
   
        public static TaskProgress InDet(string info)
        {
            return new TaskProgress(false, 0, info);
        }
    }
}
