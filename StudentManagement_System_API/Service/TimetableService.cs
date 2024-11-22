
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
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

        public async Task<TimetableResponceDTO> CreateTimetableAsync(TimetableRequestDTO timetableRequestDto)
        {
            var timetable = new Timetable
            {
                CourseId = timetableRequestDto.CourseId,
                Date = timetableRequestDto.Date,
                StartTime = timetableRequestDto.StartTime,
                EndTime = timetableRequestDto.EndTime,
                Location = timetableRequestDto.Location
            };
            var data = await _repository.CreateAsync(timetable);

            var response = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
                Date = data.Date,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                Location = data.Location,
             //   CourseName = data.Course?.CourseName
            };

            return response;
          
            
        }

        public async Task<IEnumerable<TimetableResponceDTO>> GetAllTimetablesAsync()
        {
            var timetables = await _repository.GetAllAsync();
            var timetableDtos = new List<TimetableResponceDTO>();

            foreach (var timetable in timetables)
            {
                timetableDtos.Add(new TimetableResponceDTO
                {
                    Id = timetable.Id,
                    CourseId = timetable.CourseId,
                    Date = timetable.Date,
                    StartTime = timetable.StartTime,
                    EndTime = timetable.EndTime,
                    Location = timetable.Location,
                 //   CourseName = timetable.Course?.CourseName
                });
            }

            return timetableDtos;
        }

        public async Task<TimetableResponceDTO> GetTimetableByIdAsync(int id)
        {
            var timetable = await _repository.GetByIdAsync(id);
            if (timetable == null)
                return null;

            return new TimetableResponceDTO
            {
                Id = timetable.Id,
                CourseId = timetable.CourseId,
                Date = timetable.Date,
                StartTime = timetable.StartTime,
                EndTime = timetable.EndTime,
                Location = timetable.Location,
              //  CourseName = timetable.Course?.CourseName
            };
        }

        public async Task UpdateTimetableAsync(int id, TimetableRequestDTO timetableRequestDto)
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
