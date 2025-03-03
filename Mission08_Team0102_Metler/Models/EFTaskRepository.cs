namespace Mission08_Team0102_Metler.Models
{
    // interface, provides database access for managing tasks
    public class EFTaskRepository : ITaskRepository
    {
        // hold database context instance
        private TaskDbContext _context;

        // constructor, initialize the _context field
        public EFTaskRepository(TaskDbContext temp)
        {
            _context = temp;
        }

        // get all tasks from database and converts to list
        public List<Task> Tasks => _context.Tasks.ToList();

        // method to add new task to database and save
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}
