﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementContext _context;

        public StudentRepository(StudentManagementContext context)
        {
            _context = context;
        }


        public async Task<Student> GetStudentById(string utNumber)
        {
            var data = await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments).ThenInclude(s => s.course)
                .Include(s => s.Marks).ThenInclude(s => s.Exam)
                .Include(s => s.Attendances)
                .FirstOrDefaultAsync(s => s.UTNumber == utNumber);
            return data;
        }



        public async Task<List<Student>> GetAllStudent()
        {
            var data = await _context.Students.Include(s=> s.User).ToListAsync();
            return data;
        }

        public async Task<Student> CreateStudent(Student student)
        {
             var data =await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return data.Entity;
        }


        public async Task<Student> UpdateStudent(Student student)
        {
          //  var student = await _context.Students.FindAsync(utnumber);

                _context.Students.Update(student);
                await _context.SaveChangesAsync();
          
            return student;
        }


        public async Task<bool> DeleteStudent(string utNumber)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UTNumber == utNumber);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Student>>GetStudentsByCourse(string batch)
        {
            var data = await _context.Students.Where(s => s.Batch == batch).ToListAsync();
            return data;
        }
        public async Task<Student> softDelete(Student student)
        {
            student.IsActive = false;
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<List<Student>> GetStudentsForMarking(string batch ,Batch group)
        {
            var data = await _context.Students.Where(s => s.Batch == batch && s.Group == group).Include(s => s.Enrollments).Include(s => s.User).Include(s => s.Marks).ToListAsync();
            return data;
        }
    }
}
