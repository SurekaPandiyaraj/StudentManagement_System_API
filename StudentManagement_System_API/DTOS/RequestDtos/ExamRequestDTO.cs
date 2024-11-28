namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class ExamRequestDTO
    {
        public DateTime ExamDate { get; set; }

        public int? CutOffMarks { get; set; }
        public int? MaximumMarks { get; set; }
        public Guid Id { get; set; }  // Primary Key
        public Guid CourseId { get; set; }  // Foreign Key from Course
    }
}
