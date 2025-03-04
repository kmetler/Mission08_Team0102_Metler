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
        public List<Category> Categories => _context.Categories.ToList();

        // method to add new task to database and save
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            Task task = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
            _context.Tasks.Remove(task); // Remove task from the database
            _context.SaveChanges();
        }

    }
}
