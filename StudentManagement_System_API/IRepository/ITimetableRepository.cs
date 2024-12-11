using Microsoft.AspNetCore.Routing.Constraints;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ITimetableRepository
    {
        Task<Timetable> CreateTimetableAsync(Timetable timetable);
        Task<List<Timetable>> GetTimetableByDate(DateTime date);
        Task<List<Timetable>> GetTimetableByWeeKNo(int weekNo, int year);
     //   Task<Timetable> UpdateTimetableByDate(Timetable timetable);
     // Task DeleteTimetableByDate(DateTime date);


    }
}
