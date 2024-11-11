using System.ComponentModel.DataAnnotations;

namespace StudentManagement_System_API.Entity
{
    public class Student
    {
        [Key]
        public string UTNumber { get; set; }  // Unique identifier for the student

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public string Gender { get; set; }

        // Navigation properties
        public virtual ICollection<StudentAddress> Addresses { get; set; }
        public virtual ICollection<StudentContact> Contacts { get; set; }
        public virtual ICollection<StudentEmail> Emails { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<EducationInfo> EducationInfos { get; set; }
        public virtual User User { get; set; }
    }

}
