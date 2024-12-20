﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudentManagement_System_API.Entity
{
    public class Student
    {
        [Key]
        public string UTNumber { get; set; } 
        public string Batch { get; set; }   
        public bool IsActive { get; set; }
        public string UserId { get; set; }  // Foreign Key from User
        // Navigation properties
        public User? User { get; set; }  // One-to-one relationship with User
        public ICollection<Enrollment>? Enrollments { get; set; }  // Many-to-many with Course via Enrollment
        public ICollection<Marks>? Marks { get; set; }  // One-to-many with Marks
        public ICollection<Attendance>? Attendances { get; set; }  // One-to-many with Attendance
        public Batch Group { get; set; }

    }
}
