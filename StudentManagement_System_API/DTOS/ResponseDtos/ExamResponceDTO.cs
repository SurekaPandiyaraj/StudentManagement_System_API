namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class ExamResponceDTO
    {
        public DateTime ExamDate { get; set; }

        public int? CutOffMarks { get; set; }
        public int? MaximumMarks { get; set; }
        public Guid Id { get; set; }  // Primary Key
        public Guid CourseId { get; set; }  // Foreign Key from Course
    }
}
