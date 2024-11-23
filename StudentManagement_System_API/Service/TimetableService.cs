
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentManagement_System_API.Service
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _repository;

        public TimetableService(ITimetableRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimetableResponceDTO> CreateTable(TimetableRequestDTO timetableRequestDTO)
        {
            var timetable = new Timetable
            {
                Id = Guid.NewGuid(),
                CourseId = timetableRequestDTO.CourseId,
                Date = timetableRequestDTO.Date,
                StartTime = timetableRequestDTO.StartTime,
                EndTime = timetableRequestDTO.EndTime,
               

            };
             var data = await _repository.CreateTimetableAsync(timetable);

            var req = new TimetableResponceDTO
            {

                CourseId = data.CourseId,
                Date = data.Date,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
                

            };

            return req;
        }

       public async Task<TimetableResponceDTO> GetTimetableById(DateTime Date)
        {
            var data = await _repository.GetTimetableById(Date);
            var req = new TimetableResponceDTO
            {
               
                CourseId = data.CourseId,
                Date = data.Date,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
              
            };
            return req;
       }

        public async Task<TimetableResponceDTO> UpdateTimetable(DateTime Date, TimetableRequestDTO timetableRequestDTO)
        {
            var timeTable = new Timetable
            {
                CourseId = timetableRequestDTO.CourseId,
                Date = timetableRequestDTO.Date,
                StartTime = timetableRequestDTO.StartTime,
                EndTime = timetableRequestDTO.EndTime
            };

            var data = await _repository.UpdateTimetable(timeTable);

            var req = new TimetableResponceDTO
            {

                CourseId = data.CourseId,
                Date = data.Date,
                StartTime = data.StartTime,
                EndTime = data.EndTime
            };
            return req;
        }
    }
}
