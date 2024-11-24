

using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task<TimetableResponceDTO> CreateTable(TimetableRequestDTO timetableRequestDTO);
         Task<TimetableResponceDTO> GetTimetableById(Guid Id);
        Task<TimetableResponceDTO> UpdateTimetable(Guid Id, TimetableRequestDTO timetableRequestDTO);
        Task DeleteTable(Guid Id);
       
    }
}
