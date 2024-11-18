namespace StudentManagement_System_API.Entity
{
    public class Timetable
    {
        public int TimetableId { get; set; }  // Primary Key
        public int CourseId { get; set; }  // Foreign Key from Course
        public DayOfWeek Day { get; set; }  // Day of the week for the class
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Location { get; set; }

        // Navigation properties
        public Course Course { get; set; }  // One-to-many with Course
        public ICollection<Attendance> Attendances { get; set; }  // One-to-many with Attendance
    }

}
