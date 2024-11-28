using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class MarksResponceDTO
    {

        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string UTNumber { get; set; }
        public Guid CourseId { get; set; }
        public DateTime ExamDate { get; set; }

        public bool IsApproved { get; set; } = false;

        // Navigation properties for related data
        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }
}
