using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace MainIotApp
{
    public class RegisterBackgroundTasks
    {
        TimeTrigger _hourlyTrigger = new TimeTrigger(60, false);
        private static readonly String TempLoggerName = "TempLogger";
        private static readonly String TempTaskEntryPoint = "Temperature_Logger.StartupTask";

        public async Task<List<BackgroundTask>> RegisterTasks()
        {
            List<BackgroundTask> taskList = new List<BackgroundTask>();
            await BackgroundExecutionManager.RequestAccessAsync();
            taskList.Add(RegisterTemperaturLogger());
            return taskList;
        }

        public BackgroundTask RegisterTemperaturLogger()
        {
            BackgroundTaskRegistration task = RegisterBackgroundTask(TempTaskEntryPoint, TempLoggerName, _hourlyTrigger, null);
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
