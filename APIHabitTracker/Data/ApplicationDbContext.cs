using Microsoft.EntityFrameworkCore;
using HabitTrackerAPI.Models;

namespace HabitTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 🌱 Seeding Users Table
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "meghan", Email = "meghan@example.com" },
            new User { Id = 2, Username = "john_doe", Email = "johndoe@example.com" },
            new User { Id = 3, Username = "jane_doe", Email = "janedoe@example.com" }
        );
    }
        public DbSet<Habit> Habits { get; set; }
    }
}