﻿
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

        //public async Task<Timetable> CreateTimetableAsync(Timetable timetable)
        //{
        //    var data = await _context.Timetables.AddAsync(timetable);
        //    await _context.SaveChangesAsync();
        //    return data.Entity;
        //}

        //public async Task<List<Timetable>> GetTimetablesAsync()
        //{
        //    var data = await _context.Timetables.Where(t => !t.IsDelete).ToListAsync();
        //    return data;

        //}

        //public async Task<Timetable> GetTimetableById(DateTime Date)
        //{
        //    var data = await _context.Timetables.FirstOrDefaultAsync(t => t.Date == Date & !t.IsDelete);
        //    return data;
        //}

        //public async Task<Timetable> UpdateTimetable(Timetable timetable)
        //{
        //    var data = await GetTimetableById(timetable.Date);

        //    if (data != null) return null;

        //    data.CourseId = timetable.CourseId;
        //    data.StartTime = timetable.StartTime;
        //    data.EndTime = timetable.EndTime;
        //    data.Location = timetable.Location;

        //    await _context.SaveChangesAsync();
        //    return data;
        //}

        //public async Task DeleteTimetable(DateTime Date)
        //{
        //    var data = await GetTimetableById(Date);
        //    if (data != null)
        //    {
        //        data.IsDelete = true;
        //        _context.Timetables.Update(data);
        //        await _context.SaveChangesAsync();

        //    }
        //}

    }
}
