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
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Marks)
                .Include(s => s.Attendances)
                .FirstOrDefaultAsync(s => s.UTNumber == utNumber);
        }



        public async Task<List<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }


        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }


        public async Task<bool> DeleteStudent(string utNumber)
        {
            var student = await _context.Students.FindAsync(utNumber);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
