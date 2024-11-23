

using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task<TimetableResponceDTO> CreateTimetableAsync(TimetableRequestDTO timetableRequestDto);
        Task<IEnumerable<TimetableResponceDTO>> GetAllTimetablesAsync();
        Task<TimetableResponceDTO> GetTimetableByIdAsync(int id);
        Task UpdateTimetableAsync(int id, TimetableRequestDTO timetableRequestDto);
        Task DeleteTimetableAsync(int id);
    }
}
