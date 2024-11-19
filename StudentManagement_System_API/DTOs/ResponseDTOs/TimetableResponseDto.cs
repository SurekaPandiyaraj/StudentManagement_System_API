namespace StudentManagement_System_API.DTOs.ResponseDTOs
{
    public class TimetableResponseDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public string? CourseName { get; set; }  // For example, Course Name (if needed)
    }
}
