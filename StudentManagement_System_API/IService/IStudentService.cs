using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsForAttendance(int courseId);
    }
}
