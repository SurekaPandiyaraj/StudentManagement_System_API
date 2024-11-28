using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IExamService
    {
        Task<ExamResponceDTO> AddExam(ExamRequestDTO examRequestDTO);
        Task<ExamResponceDTO> GetExamById(Guid id);
       Task<List<ExamResponceDTO>> GetAllExams();
        Task<ExamResponceDTO> UpdateExam(Guid id, ExamRequestDTO examRequest);
      
    }
}
