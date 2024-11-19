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
        public async Task CreateAsync(Timetable timetable)
        {
            await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();
        }

    }
}
