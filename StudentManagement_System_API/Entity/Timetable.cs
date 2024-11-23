﻿namespace StudentManagement_System_API.Entity
{
    public class Timetable
    {
        public Guid Id { get; set; }  // Primary Key
        public int CourseId { get; set; }  // Foreign Key from Course
        public DateTime Date { get; set; }  
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        

        public bool IsDelete { get; set; } = false;

        // Navigation properties
        public Course? Course { get; set; }  // One-to-many with Course
        public ICollection<Attendance>? Attendances { get; set; }  // One-to-many with Attendance
    }

}
