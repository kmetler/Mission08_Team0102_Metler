namespace Mission08_Team0102_Metler.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
    }
}
