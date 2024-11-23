using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class UserResponseDTOs
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; }
    }
}
