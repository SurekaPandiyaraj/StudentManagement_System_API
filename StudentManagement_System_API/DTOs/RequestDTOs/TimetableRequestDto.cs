namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class TimetableRequestDTO
    {
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        
    }
}
