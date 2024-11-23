using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class StudentResponceDTO
    {
        public string UTNumber { get; set; }  // Primary Key for Student (UT Number)
        public string Batch { get; set; }     // Batch information
        public int UserId { get; set; }       // Foreign Key from User
        public UserResponseDTOs? User { get; set; }  // Simplified User data for response
        public List<EntrollementResponceDTO>? Enrollments { get; set; }  // Related Enrollments
        public List<Marks>? Marks { get; set; }             // Related Marks
        public List<Attendance>? Attendances { get; set; }  // Related Attendance
    }
}
