﻿using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IStudentService
    {
        //Task<List<Student>> GetStudentsForAttendance(int courseId);
        Task<Student> GetStudentById(string utNumber);
        Task<List<StudentResponceDTO>> GetAllStudent();
        Task<StudentResponceDTO> CreateStudent(StudentRequestDTO studentRequestDto);
        Task<StudentResponceDTO> UpdateStudent(string utnumber, StudentRequestDTO studentRequestDto);
        Task<bool> DeleteStudent(string utNumber);
        Task<StudentResponceDTO> softDelete(string utNumber);
        Task<List<StudentResponceDTO>> GetStudentsForMarking(Guid courseId, string batch, Batch group);
    }
}
