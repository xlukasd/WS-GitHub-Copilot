using Microsoft.EntityFrameworkCore;
using University.API.Model;

namespace University.API.Database
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Course entity
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);
        }
    }
}
