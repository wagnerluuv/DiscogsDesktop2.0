using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDiscogsDesktop.Tasks
{
    public sealed class IdentifiableTask
    {
        public string Id { get; }

        public TaskProgressReporter ProgressReporter { get; }

        public IdentifiableTask(string id, TaskProgressReporter progressReporter)
        {
            this.Id = id;
            this.ProgressReporter = progressReporter;
        }
    }
}
