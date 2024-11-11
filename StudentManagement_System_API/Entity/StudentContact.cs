using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class StudentContact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentUTNumber { get; set; }  // Foreign key to Student

        public string PhoneNumber { get; set; }

        // Navigation property
        public virtual Student Student { get; set; }
    }

}
