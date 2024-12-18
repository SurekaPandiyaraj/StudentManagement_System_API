﻿using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly StudentManagementContext _context;

        public EnrollmentRepository(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<List<Enrollment>> AddEnrollment(List<Enrollment> enrollments)
        {
           await _context.Enrollments.AddRangeAsync(enrollments);
            await _context.SaveChangesAsync();

            return enrollments;
        }
        public async Task<List<Enrollment>> GetEnrollmentById(Guid Id)
        {
            var data = await _context.Enrollments.Where(a => a.Id == Id).ToListAsync();
            return data;

        }
        public async Task<List<Enrollment>> GetEnrollmentsByCourseId(Guid CourseId)
        {
            var data = await _context.Enrollments.Where(a => a.CourseId == CourseId).Include(a => a.Student).ThenInclude(a => a.User).ToListAsync();
            return data;

        }
        public async Task DeleteEntrollment(Guid Id)
        {
            var data =await _context.Enrollments.FindAsync(Id);
            if (data != null)
            {
                _context.Enrollments.Remove(data);
                await _context.SaveChangesAsync();
            }
  
        }
        public async Task<List<Enrollment>>GetEnrollsByUtNum(string UtNum)
        {
            var data = await _context.Enrollments.Where(e => e.StudentId == UtNum).ToListAsync();
            return data;
        }
    }
}
