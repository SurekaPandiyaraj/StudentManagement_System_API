namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class MarksRequestDTO
    {

        public Guid ExamId { get; set; } // Filter by ExamId
        public string UTNumber { get; set; } // Filter by UTNumber
        public Guid CourseId { get; set; }
        public DateTime ExamDate { get; set; }

        public bool IsApproved { get; set; } = false;

    }
}
