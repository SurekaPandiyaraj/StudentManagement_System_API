using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance> GetByAttendancesById(Guid id);
        Task<Attendance> AddStudentAttendence(Attendance attendance);
        Task<List<Attendance>> GetStudents(Guid TimeSlotId);
      //  Task<Attendance> UpdateAsync(Attendance attendance);
      //   Task DeleteAsync(int id);
    }
}
