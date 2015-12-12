using System;
using Windows.ApplicationModel.Background;

namespace MainIotApp
{
    public class RegisterBackgroundTasks
    {
        TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
        private static readonly String TempLoggerName = "";
        private static readonly String TempLoggerStartingPoint = "";



        public async void RegisterTasks()
        {
            await BackgroundExecutionManager.RequestAccessAsync();


        }

        public BackgroundTask RegisterTemperaturLogger()
        {
            BackgroundTaskRegistration task = RegisterBackgroundTask("", "", hourlyTrigger, null);
            return new BackgroundTask(task);
        }

        public static BackgroundTaskRegistration RegisterBackgroundTask(string taskEntryPoint, string taskName, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            //
            // Check for existing registrations of this background task.
            //

            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {

                if (cur.Value.Name == taskName)
                {
                    // 
                    // The task is already registered.
                    // 

                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }


            //
            // Register the background task.
            //

            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = taskEntryPoint;
            builder.SetTrigger(trigger);

            if (condition != null)
            {

                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;

        }

    }
}
