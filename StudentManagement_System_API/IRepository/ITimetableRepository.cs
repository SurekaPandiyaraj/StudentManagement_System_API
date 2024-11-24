using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ITimetableRepository
    {
        Task<Timetable> CreateTimetableAsync(Timetable timetable);
        Task<List<Timetable>> GetTimetablesAsync();
        Task<Timetable> GetTimetableById(Guid Id);
        Task<Timetable> UpdateTimetable(Timetable timetable);
        Task DeleteTimetable(Guid Id);

    }
}
