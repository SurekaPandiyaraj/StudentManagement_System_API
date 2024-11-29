using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.IService
{
    public interface IMarksService
    {
        Task<MarksResponceDTO> CreateUser(MarksRequestDTO marksRequest);
        Task<MarksResponceDTO> GetMarksById(Guid id);
        Task<List<MarksResponceDTO>> GetAllMarks();
        Task<MarksResponceDTO> UpdateMarks(Guid UserId, MarksRequestDTO marksRequest);
    }
}
