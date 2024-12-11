using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(Guid id);
        Task<List<Student>> GetStudentsByCourseId(Guid CourseId, Batch batch);
        Task<Attendance> CreateAttendanceAsync(AttendanceRequestDTO attendanceRequest);
        Task<List<Attendance>> GetStudents(Guid TimeSlotId);
        //Task UpdateAttendanceAsync(Attendance attendance);
        //Task DeleteAttendanceAsync(Guid id);
    }
}
