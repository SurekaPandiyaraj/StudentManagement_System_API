using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class ExamRequestDTO
    {
        public DateTime ExamDate { get; set; }
      //  public int? CutOffMarks { get; set; }
        public Batch Group { get; set; }
        public int Batch { get; set; }
        public Guid CourseId { get; set; }
    }
}
