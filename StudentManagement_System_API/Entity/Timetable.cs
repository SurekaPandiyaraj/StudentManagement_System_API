
namespace StudentManagement_System_API.Entity
{
    public class Timetable
    {
        public Guid Id { get; set; }  // Primary Key
        public Batch Batch { get; set; }
        public DateOnly Day {  get; set; }
        public int Week { get; set; }
        public int Year { get; set; }


        // Navigation properties
        public ICollection<TimeSlot>? TimeSlot { get; set; }
        public Type? Type { get; set; }
        
    }

    public enum Batch
    {
        A = 1, 
        B = 2, 
        C = 3, 
        D = 4, 
        E = 5
    }

   
    

}
