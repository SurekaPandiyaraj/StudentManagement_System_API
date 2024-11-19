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
    }
}
