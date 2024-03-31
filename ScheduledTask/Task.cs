namespace ScheduledTask
{
    public class Task
    {
        private string? description;
        private DateTime executionTime;

        public string? Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime ExecutionTime
        {
            get { return executionTime; }
            set { executionTime = value; }
        }

        public Task(string description, DateTime executionTime)
        {
            Description = description;
            ExecutionTime = executionTime;
        }

        public override string ToString()
        {
            return $"{Description} - {ExecutionTime:dd.MM.yyyy HH:mm}";
        }
    }
}