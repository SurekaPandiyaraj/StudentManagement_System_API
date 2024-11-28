using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
      

        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName {  get; set; }
        public DateOnly Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       
    }
}
