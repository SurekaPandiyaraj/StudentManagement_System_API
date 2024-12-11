namespace StudentManagement_System_API.Entity
{
    public class Attendance
    {
        public Guid Id { get; set; }  // Primary Key
        public DateTime CheckedIn { get; set; }
        public bool IsPresent { get; set; } = false; // Present or Absent
        // Navigation properties
        public Guid TimeSlotId { get; set; }  // Foreign Key from Timetable
        public TimeSlot? TimeSlot { get; set; }
        public string StudentUTNumber { get; set; }  // Foreign Key from Student
        public Student? Student { get; set; }
    }
 }
