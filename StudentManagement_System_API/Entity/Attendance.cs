namespace StudentManagement_System_API.Entity
{
    public class Attendance
    {
        public Guid Id { get; set; }  // Primary Key
        public Guid TimeSlotId { get; set; }  // Foreign Key from Timetable
        public string UTNumber { get; set; }  // Foreign Key from Student
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }  // Present or Absent
        // Navigation properties
        public TimeSlot? TimeSlot { get; set; }
        public Student? Student { get; set; }
    }
 }
