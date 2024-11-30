namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class EntrollementRequestDTO
    {
        public DateTime EnrolledDate { get; set; }
        public string StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
