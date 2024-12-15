using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IMarksService
    {
        Task<MarksResponceDTO> AddMarks(MarksRequestDTO marksRequest);
        Task<MarksResponceDTO> GetMarksById(Guid id);
        Task<List<Marks>> GetAllMarks();
        Task<MarksResponceDTO> UpdateMarks(Guid UserId, MarksRequestDTO marksRequest);
        Task<List<Marks>> GetMarksByExamId(Guid examId);
    }
}
