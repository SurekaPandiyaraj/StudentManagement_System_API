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



    }
}