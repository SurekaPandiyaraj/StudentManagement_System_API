namespace StudentManagement_System_API.Entity
{
    public class Enrollment
    {
        public Guid Id { get; set; }  // Primary Key

        public Guid CourseId { get; set; }  // Foreign Key from Course
        public DateTime EnrolledDate { get; set; }
        public Student Student { get; set; }
        public string StudentId { get; set; }


        public Course course { get; set; }

    }

}
