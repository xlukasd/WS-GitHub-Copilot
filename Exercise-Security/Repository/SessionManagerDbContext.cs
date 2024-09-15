using Exercise_Security.Model;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Security.Repository
{
    public class SessionManagerDbContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }

        public SessionManagerDbContext(DbContextOptions<SessionManagerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>().HasKey(s => s.Id);
            modelBuilder.Entity<Talk>().HasKey(t => t.Id);
        }
    }
}
