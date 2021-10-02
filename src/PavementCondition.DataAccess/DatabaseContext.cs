using Microsoft.EntityFrameworkCore;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<DefectType> DefectTypes { get; set; }

        public DbSet<Road> Roads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
