namespace StudentManagement_System_API.Entity
{
    public class TimeSlot
    {
       public Guid Id { get; set; } 
       public Type? ClassType { get; set; }
       public TimeSpan StartTime { get; set; }
       public TimeSpan EndTime { get; set; }
       public Guid CourseId { get; set; }
        public Course Course{ get;set; }

    }

    public enum Type
    {
        Lab = 1,
        Session = 2
    }
}
