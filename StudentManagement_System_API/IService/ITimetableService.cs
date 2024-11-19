using StudentManagement_System_API.DTOs.RequestDTOs;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task CreateTimetableAsync(TimetableRequestDto timetableRequestDto);
    }
}
