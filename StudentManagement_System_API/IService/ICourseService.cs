﻿using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface ICourseService
    {
        Task<CourseResponceDTO> AddCourse(CourseRequestDTO courseRequestDTO);
        Task<List<CourseResponceDTO>> GetAllCourses();
        Task<CourseResponceDTO> GetCourseById(Guid id);
        Task<CourseResponceDTO> UpdateCoures(Guid Id, CourseRequestDTO course);
        Task DeleteCourse(Guid Id);
    }
}
