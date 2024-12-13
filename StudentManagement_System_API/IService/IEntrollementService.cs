using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface IEntrollementService
    {
        Task<List<EntrollementResponceDTO>> AddEntrollement(EntrollementRequestDTO entrollementRequestDTOs);
        Task<List<EntrollementResponceDTO>> GetEnrollmentById(Guid CourseId);
        Task Delete(Guid CourseId);
    }
}
