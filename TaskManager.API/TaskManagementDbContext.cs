using Microsoft.EntityFrameworkCore;

namespace TaskManager.API
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTask { get; set; }
    }
}
