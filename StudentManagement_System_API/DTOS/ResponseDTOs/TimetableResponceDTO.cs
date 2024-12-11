using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
        public Guid Id { get; set; } 
        public string Batch { get; set; } 
        public string Day { get; set; } 
        public int Week { get; set; }  
        public int Year { get; set; } 
        public string? Type { get; set; } 
        public ICollection<TimeSlotResponseDTO>? TimeSlots { get; set; } 
    }

    public class TimeSlotResponseDTO
    {
        public Guid Id { get; set; } 
        public string ClassType { get; set; } 
        public string StartTime { get; set; } 
        public string EndTime { get; set; } 
        public Guid CourseId { get; set; } 
        public string? CourseName { get; set; } 
    }


}
