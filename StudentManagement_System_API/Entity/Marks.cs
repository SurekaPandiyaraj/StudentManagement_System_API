namespace StudentManagement_System_API.Entity
{
    public class Marks
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string UTNumber { get; set; }
        public int? MarksObtained { get; set; }
        public bool IsApproved { get; set; }                

        // Navigation properties for relationships
        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }

}
