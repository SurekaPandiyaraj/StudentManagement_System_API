using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
        public Guid Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public List<Timetablesubjectresponse> timetablesubjectresponses { get; set; }
       
    }
}
