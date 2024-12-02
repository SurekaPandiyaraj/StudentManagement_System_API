namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class EntrollementResponceDTO
    {
        public Guid Id { get; set; }
        public DateTime EnrolledDate { get; set; }
        public string StudentId { get; set; }
        public Guid CourseId { get; set; }

    }
}
