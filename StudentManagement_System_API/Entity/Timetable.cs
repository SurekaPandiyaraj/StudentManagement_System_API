
namespace StudentManagement_System_API.Entity
{
    public class Timetable
    {
        public Guid Id { get; set; }  // Primary Key
        public Guid CourseId { get; set; } 
        
        public string CourseName { get; set; }
        // Foreign Key from Course
        public DateOnly Date { get; set; }  
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        

        public bool IsDelete { get; set; } = false;

        // Navigation properties
        public Course? Course { get; set; }  // One-to-many with Course
        public ICollection<Attendance>? Attendances { get; set; }  // One-to-many with Attendance
        public List<Subject>? Subjects { get; internal set; }

        public User? UserRole  { get; set; }
    }

}
