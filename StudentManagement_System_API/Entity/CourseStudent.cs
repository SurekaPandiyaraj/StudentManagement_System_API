namespace StudentManagement_System_API.Entity
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string UTNumber { get; set; }
        public Student Student { get; set; }
    }

}
