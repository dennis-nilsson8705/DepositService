using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasIndex(c => c.Key).IsUnique();
            modelBuilder.Entity<Users>().HasData(new Users(Guid.NewGuid(), 1, "Dennis"));
            modelBuilder.Entity<Users>().HasData(new Users(Guid.NewGuid(), 2, "Bob"));
            modelBuilder.Entity<Users>().HasData(new Users(Guid.NewGuid(), 3, "Alice"));
        }

        public DbSet<Deposit>? Deposit { get; set; }
        public DbSet<Users>? Users { get; set; }
    }
}