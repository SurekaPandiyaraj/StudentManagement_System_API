using StudentManagement_System_API.Entity;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class UserRequestDTOs
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}
