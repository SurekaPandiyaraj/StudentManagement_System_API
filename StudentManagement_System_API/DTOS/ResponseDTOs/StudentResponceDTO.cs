using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class StudentResponceDTO
    {
        public string UTNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NICNumber { get; set; }
        public string Batch { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Marks> Marks { get; set; }
        public List<Attendance> Attendances { get; set; }
        public Batch Group { get; set; }

    }
}
