using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class User
    {
        [Key]
        public string UserName { get; set; }  // Unique username

        public string Password { get; set; }

        [ForeignKey("Student")]
        public string StudentUTNumber { get; set; }  // Foreign key to Student

        // Navigation property
        public virtual Student Student { get; set; }
    }

}
