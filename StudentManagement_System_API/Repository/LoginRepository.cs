
using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class LoginRepository : ILoginRepository

    {
        private readonly StudentManagementContext _context;
        public LoginRepository(StudentManagementContext context)
        {
            _context = context;
        }

      public async Task<Timetable> CreateTimetableAsync(Timetable timetable)
      {
            var data = await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();
            return data.Entity;
      }

       

    }
}
