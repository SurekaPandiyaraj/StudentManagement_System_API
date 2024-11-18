namespace StudentManagement_System_API.Entity
{
    public class Enrollment
    {
        public int Id { get; set; }  // Primary Key
        public string UTNumber { get; set; }  // Foreign Key from Student
        public int CourseId { get; set; }  // Foreign Key from Course
        public DateTime EnrolledDate { get; set; }

        // Navigation properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }

}
