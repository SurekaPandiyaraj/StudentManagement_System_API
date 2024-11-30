using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.DTOS.ResponseDTOs;
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
        private readonly ICourseRepository _courseRepository;

        public TimetableService(ITimetableRepository repository, ICourseRepository courseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
        }



        public async Task<TimetableResponceDTO> CreateTable(Guid courseId, TimetableRequestDtos timetableRequestDTO)
        {
            // Get the course details by courseId
            var course = await _courseRepository.GetCourseById(courseId);

               

            // Create a new Timetable Entity
            var timetable = new Timetable
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                CourseName = course.CourseName,
                Date = timetableRequestDTO.Date,
                StartTime = timetableRequestDTO.StartTime,
                EndTime = timetableRequestDTO.EndTime,
            };

            // Create the timetable in the repository/database
            var data = await _repository.CreateTimetableAsync(timetable);

            // Mapping the entity to the response DTO
            var response = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
               
                Date = data.Date,  
                StartTime = data.StartTime, 
                EndTime = data.EndTime   

            };

            return response;
        }
        public async Task<TimetableResponceDTO> GetTimetableByDate(DateOnly date)
        {

          
            var data = await _repository.GetTimetableByDate(date);

            if (data == null)
            {
                return null;  // Return null if no timetable data is found
            }

            // Map the data to the response DTO
            var res = new TimetableResponceDTO
            {
                Id = data.Id,
                CourseId = data.CourseId,
               
                Date = data.Date,
                StartTime = data.StartTime,
                EndTime = data.EndTime,
             
            };

            return res;  // Return the mapped response
        }



        //public async Task<TimetableResponceDTO> UpdateTimetable(DateTime date, TimetableRequestDtos timetableRequestDTO)
        //{
        //    var timeTable = new Timetable
        //    {
        //        Id = Guid.NewGuid(),
        //        Date = DateTime.Now,
        //        TimetableSubjects = timetableRequestDTO.Subject?.Select(x => new Subject

        //        {
        //            Name = x.SubjectName,
        //            StartTime = x.StartTime,
        //            EndTime = x.EndTime
        //        }).ToList()
        //    };

        //    var data = await _repository.GetTimetableByDate(date);

        //    var resTable = new TimetableResponceDTO
        //    {
        //        Id = data.Id,
        //        CourseId = data.CourseId,
        //        timetablesubjectresponses = data.TimetableSubjects?.Select(x => new Timetablesubjectresponse
        //        {
        //            SubjectName = x.Name,
        //            StartTime = x.StartTime,
        //            EndTime = x.EndTime
        //        }).ToList()
        //    };
        //    return resTable;
        //}

    }

    

    //public async Task DeleteTable(DateTime date)
    //{
    //    await _repository.DeleteTimetableByDate(date);
        
    //}

}

