

using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface ITimetableService
    {
        Task<TimetableResponceDTO> CreateTable(TimetableRequestDTO timetableRequestDTO)
         Task<TimetableResponceDTO> GetTimetableById(DateTime Date);
        Task<TimetableResponceDTO> UpdateTimetable(DateTime Date, TimetableRequestDTO timetableRequestDTO);
        Task DeleteTable(DateTime Date);
       
    }
}
