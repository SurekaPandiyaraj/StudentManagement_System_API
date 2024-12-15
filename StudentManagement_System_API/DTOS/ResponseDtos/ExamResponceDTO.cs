using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class ExamResponceDTO
    {
        public Guid Id { get; set; }
        public DateTime ExamDate { get; set; }
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Marks>? Marks { get; set; }
        public Batch Group { get; set; }
        public int Batch { get; set; }
    }
}
