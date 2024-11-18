namespace StudentManagement_System_API.Entity
{
    public class Attendance
    {
        public int AttendanceId { get; set; }  // Primary Key
        public int TimetableId { get; set; }  // Foreign Key from Timetable
        public int StudentId { get; set; }  // Foreign Key from Student
        public DateTime Date { get; set; }
        public string AttendanceStatus { get; set; }  // Present or Absent

        // Navigation properties
        public Timetable Timetable { get; set; }
        public Student Student { get; set; }
    }

}
