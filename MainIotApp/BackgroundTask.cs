using System;
using Windows.ApplicationModel.Background;

namespace MainIotApp
{
    public class BackgroundTask
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        private BackgroundTaskRegistration TheTask;

        public BackgroundTask(BackgroundTaskRegistration task)
        {
            Name = task.Name;
            Id = task.TaskId;
            TheTask = task;
        }

        public void RegisterEventHandler()
        {
            TheTask.Completed += TheTask_Completed;
        }

        public void RegisterProgressHandler()
        {
            TheTask.Progress += TheTask_Progress;
        }

        public void RegisterHandler(BackgroundTaskProgressEventHandler daFunc)
        {
            TheTask.Progress += daFunc;
        }

        public void RegisterHandler(BackgroundTaskCompletedEventHandler daFunc)
        {
            TheTask.Completed += daFunc;
        }

        private void TheTask_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {

        }

        private void TheTask_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {

        }
    }
}
