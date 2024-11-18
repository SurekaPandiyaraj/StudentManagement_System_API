using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagement_System_API.Entity
{
    public class User
    {
        [Key]
        public string UserId { get; set; }  // Primary Key for Admin, Staff, Lecturer
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Role as an enum (Admin, Staff, Lecturer, Student)
        public Role UserRole { get; set; }  // Single role per user
    }


    public enum Role
    {
        Admin = 1,
        Staff = 2,
        Lecturer = 3,
        Student = 4
    }


}
