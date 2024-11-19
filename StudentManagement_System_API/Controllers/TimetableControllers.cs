using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableControllers : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableControllers(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        // POST: api/timetable
        [HttpPost]
        public async Task<ActionResult> CreateTimetable(TimetableRequestDto timetableRequestDto)
        {
           var data =  _timetableService.CreateTimetableAsync(timetableRequestDto);
            return Ok(data); 
        }

        // GET: api/timetable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimetableResponseDto>>> GetTimetables()
        {
            var timetables = await _timetableService.GetAllTimetablesAsync();
            return Ok(timetables);
        }

        // GET: api/timetable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimetableResponseDto>> GetTimetable(int id)
        {
            var timetable = await _timetableService.GetTimetableByIdAsync(id);
            if (timetable == null)
            {
                return NotFound();
            }
            return Ok(timetable);
        }

        // PUT: api/timetable/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTimetable(int id, TimetableRequestDto timetableRequestDto)
        {
            await _timetableService.UpdateTimetableAsync(id, timetableRequestDto);
            return NoContent();
        }
    }
}
