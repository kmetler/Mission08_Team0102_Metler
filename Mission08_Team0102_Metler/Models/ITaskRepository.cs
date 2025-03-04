namespace Mission08_Team0102_Metler.Models
{
    //defines a contract for managing tasks in the application
    public interface ITaskRepository
    {
        // returns list of task objects
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        // method to add new Task object to the repository
        public void AddTask(Task task);
        public void UpdateTask(Task task);
        public void DeleteTask(int id);


    }
}
