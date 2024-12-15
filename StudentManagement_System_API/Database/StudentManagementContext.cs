using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.Database
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for the User table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = "Admin",
                   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@2024"),
                   UserRole = Role.Manager
                }
            );
        }
    }

    }