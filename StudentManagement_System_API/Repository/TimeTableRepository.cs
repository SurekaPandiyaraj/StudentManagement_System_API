using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class TimeTableRepository : ITimetableRepository
    {
        private readonly StudentManagementContext _context;

        public TimeTableRepository(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<Timetable> CreateTimetableAsync(Timetable timetable)
        {
            var data = await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<Timetable>> GetTimetablesAsync()
        {
            var data = await _context.Timetables.Where(t => !t.IsDelete).ToListAsync();
            return data;

        }

        public async Task<Timetable> GetTimetableById(Guid Id)
        {
            var data = await _context.Timetables.FirstOrDefaultAsync(t => t.Id == Id & !t.IsDelete);
            return data;
        }

        public async Task<Timetable> UpdateTimetable(Timetable timetable)
        {
            var data = await GetTimetableById(timetable.Id);

            if (data != null) return null;

            data.CourseId = timetable.CourseId;
            data.StartTime = timetable.StartTime;
            data.EndTime = timetable.EndTime;
            

            await _context.SaveChangesAsync();
            return data;
        }

        public async Task DeleteTimetable(Guid Id)
        {
            var data = await GetTimetableById(Id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Timetables.Update(data);
                await _context.SaveChangesAsync();

            }
        }
    }
}
