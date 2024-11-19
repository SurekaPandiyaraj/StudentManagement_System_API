using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _repository;

        public TimetableService(ITimetableRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateTimetableAsync(TimetableRequestDto timetableRequestDto)
        {
            var timetable = new Timetable
            {
                CourseId = timetableRequestDto.CourseId,
                Date = timetableRequestDto.Date,
                StartTime = timetableRequestDto.StartTime,
                EndTime = timetableRequestDto.EndTime,
                Location = timetableRequestDto.Location
            };
        }
    }
}
