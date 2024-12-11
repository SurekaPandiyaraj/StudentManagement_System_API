namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class AttendanceRequestDTO
    {
        public Guid TimeSlotId { get; set; }
        public string StudentUTNumber { get; set; }

    }
}
