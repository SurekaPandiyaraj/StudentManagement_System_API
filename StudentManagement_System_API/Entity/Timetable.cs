namespace StudentManagement_System_API.Entity
{
    public class Timetable
    {
        public Guid Id { get; set; }  // Primary Key
        public int CourseId { get; set; } 
        public DateTime Date { get; set; }
        public Guid TimetableSubjectId { get; set; }
      public ICollection<TimetableSubject> TimetableSubjects { get; set; }                          
        

        public bool IsDelete { get; set; } = false;

        // Navigation properties
        public Course? Course { get; set; }  // One-to-many with Course
        //public ICollection<Attendance>? Attendances { get; set; }  // One-to-many with Attendance
    }

}
