namespace StudentManagement_System_API.Entity
{
    public class TimeSlot
    {
        public Guid Id { get; set; }
        public ClassType? ClassType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid CourseId { get; set; }
        public Guid TimeTableId { get; set; }

        public Timetable? Timetable { get; set; }
        public Course? Course { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }  // One-to-many with Attendance


    }

    public enum ClassType
    {
        Lab = 1,
        Session = 2
    }
}
