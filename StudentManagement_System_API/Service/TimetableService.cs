using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;

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

        public async Task<IEnumerable<TimetableResponseDto>> GetAllTimetablesAsync()
        {
            var timetables = await _repository.GetAllAsync();
            var timetableDtos = new List<TimetableResponseDto>();

            foreach (var timetable in timetables)
            {
                timetableDtos.Add(new TimetableResponseDto
                {
                    Id = timetable.Id,
                    CourseId = timetable.CourseId,
                    Date = timetable.Date,
                    StartTime = timetable.StartTime,
                    EndTime = timetable.EndTime,
                    Location = timetable.Location,
                    CourseName = timetable.Course?.CourseName
                });
            }

            return timetableDtos;
        }

        public async Task<TimetableResponseDto> GetTimetableByIdAsync(int id)
        {
            var timetable = await _repository.GetByIdAsync(id);
            if (timetable == null)
                return null;

            return new TimetableResponseDto
            {
                Id = timetable.Id,
                CourseId = timetable.CourseId,
                Date = timetable.Date,
                StartTime = timetable.StartTime,
                EndTime = timetable.EndTime,
                Location = timetable.Location,
                CourseName = timetable.Course?.CourseName
            };
        }

        public async Task UpdateTimetableAsync(int id, TimetableRequestDto timetableRequestDto)
        {
            var existingTimetable = await _repository.GetByIdAsync(id);
            if (existingTimetable != null)
            {
                existingTimetable.CourseId = timetableRequestDto.CourseId;
                existingTimetable.Date = timetableRequestDto.Date;
                existingTimetable.StartTime = timetableRequestDto.StartTime;
                existingTimetable.EndTime = timetableRequestDto.EndTime;
                existingTimetable.Location = timetableRequestDto.Location;

                await _repository.UpdateAsync(existingTimetable);
            }
        }

        public async Task DeleteTimetableAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
