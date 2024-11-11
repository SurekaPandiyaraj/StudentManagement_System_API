using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class StudentResults
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EducationInfo")]
        public int EducationInfoId { get; set; }  // Foreign key to EducationInfo

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }  // Foreign key to Subject

        public string Results { get; set; }  // e.g., marks or grade

        // Navigation properties
        public virtual EducationInfo? EducationInfo { get; set; }
        public virtual Subject Subject { get; set; }
    }

}
