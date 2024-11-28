namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class TimetableRequestDtos
    {
        public DateOnly Date { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

       
    }
}
