namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class MarksRequestDTO
    {

        public Guid? ExamId { get; set; } // Filter by ExamId
        public string? UTNumber { get; set; } // Filter by UTNumber
        public int? Marks {  get; set; }
        public bool? IsApproved { get; set; } = false;

    }
}
