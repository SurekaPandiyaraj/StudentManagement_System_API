using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string BucketSubject { get; set; }
        public string Reference { get; set; }  // e.g., O/L or A/L

        // Navigation property
        public virtual ICollection<EducationInfo> EducationInfos { get; set; }
    }

}
