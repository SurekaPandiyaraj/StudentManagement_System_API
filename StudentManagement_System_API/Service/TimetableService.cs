using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;

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



        public async Task<TimetableResponceDTO> CreateTable(TimetableRequestDtos timetableRequestDTO)
        {
            // Get the course details by courseId

            // Create a new Timetable Entity
            var timetable = new Timetable
            {
                Id = Guid.NewGuid(),
                Batch = timetableRequestDTO.Batch,
                Day = timetableRequestDTO.Day.Date,
                Week = timetableRequestDTO.Week,
                Year = timetableRequestDTO.Year,
                TimeSlots = timetableRequestDTO.TimeSlots.Select(t => new TimeSlot
                {
                    StartTime = TimeSpan.Parse(t.StartTime),
                    EndTime = TimeSpan.Parse(t.EndTime),
                    ClassType = t.ClassType,
                    CourseId = t.CourseId,
                }).ToList(),
                // DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                //  System.Globalization.CultureInfo.InvariantCulture);
            };

            // Create the timetable in the repository/database
            var data = await _repository.CreateTimetableAsync(timetable);

            // Mapping the entity to the response DTO
            var response = new TimetableResponceDTO
            {
                Id = data.Id,
            };

            return response;
        }
        public async Task<List<TimetableResponceDTO>> GetTimetableByDate(DateTime date)
        {


            var data = await _repository.GetTimetableByDate(date);

            if (data == null)
            {
                throw new Exception("No Data found");  // Return null if no timetable data is found
            }

            // Map the data to the response DTO
            var res = data.Select(d => new TimetableResponceDTO
            {
                Id = d.Id,
                Batch = d.Batch.ToString(),
                Day = d.Day.ToString(),
                Week = d.Week,
                Year = d.Year,
                DayOfWeek = d.Day.DayOfWeek,
                TimeSlots = d.TimeSlots.Select(s => new TimeSlotResponseDTO
                {
                    Id = s.Id,
                    CourseId = s.CourseId,
                    ClassType = s.ClassType.ToString(),
                    StartTime = s.StartTime.ToString(),
                    EndTime = s.EndTime.ToString(),
                }).ToList()
            }).ToList();
            return res;
 
        }
        public async Task<List<IGrouping<string, TimetableResponceDTO>>> GetTimetableByWeeKNo(int weekNo, int year)
        {
            var data = await _repository.GetTimetableByWeeKNo(weekNo, year);

            if (data == null)
            {
                throw new Exception("No Data found");
            }

            var res = data.Select(d => new TimetableResponceDTO
            {
                Id = d.Id,
                Batch = d.Batch.ToString(),
                Day = d.Day.ToString(),
                Week = d.Week,
                Year = d.Year,
                DayOfWeek = d.Day.DayOfWeek,
                TimeSlots = d.TimeSlots.Select(s => new TimeSlotResponseDTO
                {
                    Id = s.Id,
                    CourseId = s.CourseId,
                    ClassType = s.ClassType.ToString(),
                    StartTime = s.StartTime.ToString(),
                    EndTime = s.EndTime.ToString(),
                }).ToList()
            }).OrderBy(d => d.DayOfWeek).GroupBy(d => d.Batch).ToList();

            return res;
        }


        // Task<List<Timetable>> GetTimetableByWeeKNo(int weekNo)


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

