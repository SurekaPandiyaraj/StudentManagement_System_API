using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class EducationInfo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentUTNumber { get; set; }  // Foreign key to Student

        [ForeignKey("Results")]
        public int? ResultsId { get; set; }  // Foreign key to Results (nullable in case of incomplete records)

        public string DegreeDetails { get; set; }
        public string OtherCourseDetails { get; set; }

        // Navigation properties
        public virtual Student? Student { get; set; }
        public virtual ICollection<StudentResults> StudentResults { get; set; }
        public virtual ICollection<Subject>? Subjects { get; set; }
    }

}
