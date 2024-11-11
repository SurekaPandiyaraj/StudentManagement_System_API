using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentUTNumber { get; set; }  // Foreign key to Student

        public byte[] ImageData { get; set; }  // Assuming image stored as binary data

        // Navigation property
        public virtual Student Student { get; set; }
    }

}
