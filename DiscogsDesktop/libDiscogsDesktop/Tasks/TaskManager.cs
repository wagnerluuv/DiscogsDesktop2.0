using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace libDiscogsDesktop.Tasks
{
    public static class TaskManager
    {
        #region private fields

        private static readonly Dictionary<string, IdentifiableTask> runningTasks = new Dictionary<string, IdentifiableTask>();

        #endregion

        #region delegates

        public delegate void TaskProgressHandler(TaskProgress progress);

        public delegate void TaskFinishedHandler();

        #endregion

        #region public methods

        public static void Run(Action<TaskProgressReporter> action, string id, TaskProgressHandler progressHandler, TaskFinishedHandler finishedHandler)
        {
            if (runningTasks.ContainsKey(id))
            {
                runningTasks[id].ProgressReporter.ProgressReported += progressHandler;
                runningTasks[id].ProgressReporter.Finished += finishedHandler;
                return;
            }

            IdentifiableTask task = new IdentifiableTask(id, new TaskProgressReporter());
            task.ProgressReporter.ProgressReported += progressHandler;
            task.ProgressReporter.Finished += finishedHandler;

            Task.Run(() =>
            {
                runningTasks.Add(id, task);
                action.Invoke(task.ProgressReporter);
                task.ProgressReporter.Finish();
                runningTasks.Remove(id);
            });
        }

        public static bool Subscribe(string id, TaskProgressHandler progressHandler, TaskFinishedHandler finishedHandler)
        {
            if (!runningTasks.ContainsKey(id))
            {
                return false;
            }

            runningTasks[id].ProgressReporter.ProgressReported += progressHandler;
            runningTasks[id].ProgressReporter.Finished += finishedHandler;
            return true;
        }

        public static bool TaskAlreadyRunning(string id)
        {
            return runningTasks.ContainsKey(id);
        }

        #endregion
    }
}