using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagement_System_API.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly StudentManagementContext _context;

        public AttendanceRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<Attendance> AddStudentAttendence(Attendance attendance)
        {
            var data = await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            var data = await _context.Attendances.Where(a => !a.IsPresent).ToListAsync();
            return data;
        }

        public async Task<Attendance> GetByAttendancesById(Guid id)
        {
            var data = await _context.Attendances.FirstOrDefaultAsync(a => a.Id == id && !a.IsPresent);
            return data;
        }

        //public async Task<Attendance> GetByStudentUTNumber(string UTNumber)
        //{
        //    var data = await _context.Attendances.FirstOrDefaultAsync(f => f.UTNumber == UTNumber && !f.IsPresent);
        //    return data;
        //}


        //public async Task<Attendance> UpdateAttendance(Attendance attendance)
        //{

        //    var data = await GetByAttendancesById(attendance.Id);

        //    if (data == null) return null;

        //    data.IsPresent = attendance.IsPresent;
        //    data.Date = attendance.Date;

        //    await _context.SaveChangesAsync();
        //    return data;


        //}

        //public async Task DeleteAttendence(Guid Id)
        //{

        //    var data = await GetByAttendancesById(Id); ;


        //    if (data != null)

        //    data.IsPresent = true;
        //    data.Date = DateTime.Now;
        //    _context.Attendances.Update(data);
        //    await _context.SaveChangesAsync();


        //}

        public async Task<List<Attendance>>GetStudents(Guid TimeSlotId)
        {
            var students = await _context.Attendances.Where(a => a.TimeSlotId == TimeSlotId).Include(a => a.Student).ThenInclude(a => a.User).ToListAsync();
            return students;
        }
    }
}