namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
    }
}
