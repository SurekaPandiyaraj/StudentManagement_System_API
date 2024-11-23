using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;
using StudentManagement_System_API.DTOS.RequestDtos;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task<TimetableResponseDto> CreateTimetableAsync(TimetableRequestDTO timetableRequestDto);
        Task<IEnumerable<TimetableResponseDto>> GetAllTimetablesAsync();
        Task<TimetableResponseDto> GetTimetableByIdAsync(int id);
        Task UpdateTimetableAsync(int id, TimetableRequestDTO timetableRequestDto);
        Task DeleteTimetableAsync(int id);
    }
}
