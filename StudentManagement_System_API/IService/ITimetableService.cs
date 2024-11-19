using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task CreateTimetableAsync(TimetableRequestDto timetableRequestDto);
        Task<IEnumerable<TimetableResponseDto>> GetAllTimetablesAsync();
    }
}
