using StudentManagement_System_API.Entity;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.DTOs.RequestDTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role UserRole { get; set; }
    }

}
