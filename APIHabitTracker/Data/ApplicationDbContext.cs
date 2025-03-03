using Microsoft.EntityFrameworkCore;
using HabitTrackerAPI.Models;

namespace HabitTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🌱 Seeding Users Table
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "meghan", Email = "meghan@example.com" },
                new User { Id = 2, Username = "john_doe", Email = "johndoe@example.com" },
                new User { Id = 3, Username = "jane_doe", Email = "janedoe@example.com" }
            );

            modelBuilder.Entity<Habit>().HasData(
                new Habit { Id = 1, UserID = 1, Name = "Drink Water", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), Frequency = "Daily", Completed = false },
                new Habit { Id = 2, UserID = 1, Name = "Exercise",  StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), Frequency = "Daily", Completed = false },
                new Habit { Id = 3, UserID = 1, Name = "Make Bed",  StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), Frequency = "Daily", Completed = false }
            );


        }
    }
}