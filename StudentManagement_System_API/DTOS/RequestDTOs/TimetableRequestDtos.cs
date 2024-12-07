namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class TimetableRequestDtos
    {
        public int Batch { get; set; }
        public DateTime Day { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }
        public List<TimeSlotRequestDto> TimeSlots { get; set; }

        public TimetableRequestDtos()
        {
            TimeSlots = new List<TimeSlotRequestDto>();
        }
    }

    public class TimeSlotRequestDto
    {
        public string CourseId { get; set; }
        public string StartTime { get; set; } 
        public string EndTime { get; set; }
        public int ClassType { get; set; }
    }
}
