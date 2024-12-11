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
        public async Task<List<Timetable>> GetTimetableByDate(DateTime date)
        {
            var data = await _context.Timetables.Where(d => d.Day == date.Date).Include(d => d.TimeSlots).ToListAsync();
            return data;
        }
        public async Task<List<Timetable>> GetTimetableByWeeKNo(int weekNo, int year)
        {
            var data = await _context.Timetables.Where(d => d.Week == weekNo && d.Year == year).Include(d => d.TimeSlots).ToListAsync();
            return data;
        }



        //public async Task<Timetable> UpdateTimetableByDate(Timetable timetable)
        //{
        //    var data = await GetTimetableByDate(timetable.Date);
        //    if (data != null) return null;

        //    data.CourseId = timetable.CourseId;


        //    await _context.SaveChangesAsync();
        //    return data;
        //}

        //public async Task DeleteTimetableByDate(DateTime date)
        //{
        //    var data= await GetTimetableByDate(date);
        //    if(data != null)
        //    {
        //        _context.Timetables.Remove(data);
        //        await _context.SaveChangesAsync();
        //    }
        //}


    }
}
