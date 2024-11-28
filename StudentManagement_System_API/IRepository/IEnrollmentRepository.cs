using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> AddEnrollment(Enrollment enrollment);
        Task<List<Enrollment>> GetEnrollmentById(Guid Id);
        Task<List<Enrollment>> GetEnrollmentsByCourseId(Guid CourseId);
        Task DeleteEntrollment(Guid Id);

    }
}
