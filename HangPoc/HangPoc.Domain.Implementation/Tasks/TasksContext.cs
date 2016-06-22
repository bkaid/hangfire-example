using System.Data.Entity;

namespace HangPoc.Domain.Tasks {

    public class TasksContext : DbContext {

        public TasksContext(): base("TasksContext") {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
