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
        public async Task<Timetable> CreateAsync(Timetable timetable)
        {
            var data = await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<IEnumerable<Timetable>> GetAllAsync()
        {
            return await _context.Timetables.Include(t => t.Course).ToListAsync();
        }

        public async Task<Timetable> GetByIdAsync(int id)
        {
            return await _context.Timetables.Include(t => t.Course).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Timetable timetable)
        {
            _context.Timetables.Update(timetable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable != null)
            {
                _context.Timetables.Remove(timetable);
                await _context.SaveChangesAsync();
            }
        }
    }
}
