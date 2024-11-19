using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOs.ResponseDTOs
{
    public class UserResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
    }

}
