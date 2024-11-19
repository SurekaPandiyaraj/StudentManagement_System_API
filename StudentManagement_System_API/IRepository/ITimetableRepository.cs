using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ITimetableRepository
    {
        Task CreateAsync(Timetable timetable);
        Task<IEnumerable<Timetable>> GetAllAsync();
        Task<Timetable> GetByIdAsync(int id);
        Task UpdateAsync(Timetable timetable);
    }
}
