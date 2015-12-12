using System;
using Windows.ApplicationModel.Background;

namespace MainIotApp
{
    public class BackgroundTask
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        private readonly BackgroundTaskRegistration _theTask;

        public BackgroundTask(BackgroundTaskRegistration task)
        {
            Name = task.Name;
            Id = task.TaskId;
            _theTask = task;
        }

        public void RegisterEventHandler()
        {
            _theTask.Completed += TheTask_Completed;
        }

        public void RegisterProgressHandler()
        {
            _theTask.Progress += TheTask_Progress;
        }

        public void RegisterHandler(BackgroundTaskProgressEventHandler daFunc)
        {
            _theTask.Progress += daFunc;
        }

        public void RegisterHandler(BackgroundTaskCompletedEventHandler daFunc)
        {
            _theTask.Completed += daFunc;
        }

        private void TheTask_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {

        }

        private void TheTask_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {

        }
    }
}
