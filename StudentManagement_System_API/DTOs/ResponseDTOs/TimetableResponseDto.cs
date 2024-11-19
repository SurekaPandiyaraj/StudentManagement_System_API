namespace StudentManagement_System_API.DTOs.ResponseDTOs
{
    public class TimetableResponseDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
        public string? CourseName { get; set; }  // For example, Course Name (if needed)
    }
}
