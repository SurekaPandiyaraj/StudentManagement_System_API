using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class Student
    {
        [Key]
        public int UTNumber { get; set; }  // Primary Key for Student (UT Number)
        public string Batch { get; set; }
        public int UserId { get; set; }  // Foreign Key from User

        // Navigation properties
        public User User { get; set; }  // One-to-one relationship with User
        public ICollection<Enrollment> Enrollments { get; set; }  // Many-to-many with Course via Enrollment
        public ICollection<Marks> Marks { get; set; }  // One-to-many with Marks
        public ICollection<Attendance> Attendances { get; set; }  // One-to-many with Attendance

    }
}
