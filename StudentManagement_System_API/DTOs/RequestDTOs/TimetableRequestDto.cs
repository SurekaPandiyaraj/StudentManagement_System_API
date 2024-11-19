namespace StudentManagement_System_API.DTOs.RequestDTOs
{
    public class TimetableRequestDto
    {
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
    }
}
