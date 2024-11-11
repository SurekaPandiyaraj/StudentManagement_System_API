using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class StudentEmail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentUTNumber { get; set; }  // Foreign key to Student

        public string Email { get; set; }

        // Navigation property
        public virtual Student Student { get; set; }
    }

}
