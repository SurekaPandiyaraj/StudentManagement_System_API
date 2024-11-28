using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(Guid id);
        Task<List<Student>> GetStudentsByCourseId(Guid CourseId);
        Task CreateAttendanceAsync(Attendance attendance);
        //Task UpdateAttendanceAsync(Attendance attendance);
        //Task DeleteAttendanceAsync(Guid id);
    }
}
