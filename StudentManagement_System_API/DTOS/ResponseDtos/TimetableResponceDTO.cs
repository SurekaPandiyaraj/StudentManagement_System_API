using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
       
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
       
    }
}
