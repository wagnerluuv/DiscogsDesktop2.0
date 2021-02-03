using System;
using JetBrains.Annotations;

namespace libDiscogsDesktop.Tasks
{
    public sealed class TaskProgressReporter
    {
        public event TaskManager.TaskProgressHandler ProgressReported;

        public event TaskManager.TaskFinishedHandler Finished;

        public TaskProgress LastProgress { get; private set; }

        public TaskProgressReporter()
        {
            this.LastProgress = TaskProgress.InDet("no progress has been reported yet");
        }

        public void ReportDeterminate(int percentage, string info)
        {
            this.LastProgress = TaskProgress.Det(percentage, info);
            this.ProgressReported?.Invoke(this.LastProgress);
        }

        public void ReportInDeterminate(string info)
        {
            this.LastProgress = TaskProgress.InDet(info);
            this.ProgressReported?.Invoke(this.LastProgress);
        }

        public void Finish()
        {
            this.Finished?.Invoke();
        }
    }
}