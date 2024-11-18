using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOs.RequestDTOs
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}
