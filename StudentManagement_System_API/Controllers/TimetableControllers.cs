using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
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

        [HttpPost]

        public async Task<IActionResult> CreateTimetable(TimetableRequestDTO timetableRequestDTO)
        {
            var createdTable = await _timetableService.CreateTable(timetableRequestDTO);
            return Ok(createdTable);
        }

        //[HttpGet]

        //public async Task<IActionResult> GetAllTimetable()
        //{
        //    var table = await _timetableService.GetTables();
        //    return Ok(table);
        //}

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetTable(Guid Id)
        {
            var table = await _timetableService.GetTimetableById(Id);
            if (table == null) return NotFound();

            return Ok(table);
        }

        [HttpPut("{Date}")]

        public async Task<IActionResult> UpdateTable(Guid Id, TimetableRequestDTO TimetableRequestDTO)
        {
            await _timetableService.UpdateTimetable(Id, TimetableRequestDTO);
            return NoContent();
        }

        [HttpDelete("{Date}")]

        public async Task<IActionResult> DeleteTable(Guid Id)
        {
            await _timetableService.DeleteTable(Id);
            return NoContent();
        }
    }
}
