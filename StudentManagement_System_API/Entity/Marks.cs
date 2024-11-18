namespace StudentManagement_System_API.Entity
{
    public class Marks
    {
        public int MarksId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int MarksObtained { get; set; }
        public string ApprovalStatus { get; set; } // Pending or Approved

        // Navigation properties for relationships
        public Exam Exam { get; set; }
        public Student Student { get; set; }
    }

}
