namespace StudentManagement_System_API.DTOs.RequestDTOs
{
    public class TimetableRequestDto
    {
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
    }
}
