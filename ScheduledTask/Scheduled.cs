namespace ScheduledTask
{
    public class Scheduled
    {
        public delegate void TaskUpdated(Task task, int index);
        public TaskUpdated? UpdateTaskCallback;

        private List<Task> taskList;

        public Scheduled()
        {
            taskList = new List<Task>();
        }

        public void AddTask(Task task)
        {
            taskList.Add(task);
        }

        public List<Task> GetDueTasks(DateTime now)
        {
            List<Task> dueTasks = new List<Task>();
            foreach (Task task in taskList)
            {
                if (task.ExecutionTime.Hour == now.Hour && task.ExecutionTime.Minute == now.Minute)
                {
                    dueTasks.Add(task);
                }
            }
            foreach (Task task in dueTasks)
            {
                taskList.Remove(task);
            }
            return dueTasks;
        }

        public bool HasTasks()
        {
            return taskList.Count > 0;
        }

        public void RemoveTask(Task task)
        {
            taskList.Remove(task);
        }

        public void UpdateReminder()
        {
            DateTime now = DateTime.Now;
            List<Task> dueTasks = GetDueTasks(now);
            foreach (Task task in dueTasks)
            {
                MessageBox.Show(task.Description, "Нагадування");
            }
        }
    }
}