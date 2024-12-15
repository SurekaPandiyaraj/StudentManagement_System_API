namespace StudentManagement_System_API.Entity
{
    public class Exam
    {
        public Guid Id { get; set; }  // Primary Key
        public Guid CourseId { get; set; }  // Foreign Key from Course
        public DateTime ExamDate { get; set; }     
        public int? CutOffMarks { get; set; }
        public Batch Group {  get; set; }
        public int Batch {  get; set; }
        // Navigation properties
        public Course Course { get; set; }  // One-to-many with Course
        public ICollection<Marks>? Marks { get; set; }  // One-to-many with Marks
    }

}
