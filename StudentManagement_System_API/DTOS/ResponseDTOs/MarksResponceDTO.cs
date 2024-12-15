using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class MarksResponceDTO
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string UTNumber { get; set; }
        public int? MarksObtained { get; set; }
        public bool IsApproved { get; set; }
    }
}
