using System.Collections.Generic;

namespace MainIotApp
{
    public class Controller
    {
        private List<BackgroundTask> _backgroundTasks;

        public async void InitController()
        {
            RegisterBackgroundTasks rbt = new RegisterBackgroundTasks();
            _backgroundTasks = await rbt.RegisterTasks();
        }
    }
}
