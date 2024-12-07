using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class TimetableRequestDtos
    {
        public Batch Batch { get; set; }
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
        public Guid CourseId { get; set; }
        public string StartTime { get; set; } 
        public string EndTime { get; set; }
        public ClassType ClassType { get; set; }

    }
}
