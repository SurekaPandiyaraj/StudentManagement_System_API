﻿using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IStudentRepository
    {
        //Task<List<Student>> GetStudentsWithEnrollments();

        Task<Student> GetStudentById(string utNumber);
        Task<List<Student>> GetAllStudent();
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(string utNumber);
        Task<Student> softDelete(Student student);
        Task<List<Student>> GetStudentsForMarking(string batch, Batch group);
    }
}
