using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksControllers : ControllerBase
    {
        private readonly IMarksService _marksService;

        public MarksControllers(IMarksService marksService)
        {
            _marksService = marksService;
        }

        [HttpPost]

        public async Task<IActionResult> AddMarks(MarksRequestDTO marksRequestDTO)
        {
            try
            {
                var data = await _marksService.AddMarks(marksRequestDTO);
                return Ok(data);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
           
        }

       [HttpGet("{Id}")]

        public async Task<IActionResult> GetMarksById(Guid Id)
        {
            var data = await _marksService.GetMarksById(Id);
            return Ok(data);
        }

        [HttpGet]

        public async Task<IActionResult> GetMarks()
        {
            var data = await _marksService.GetAllMarks();
            return Ok(data);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateMarks(Guid Id, MarksRequestDTO marksRequestDTO)
        {
            var data = await _marksService.UpdateMarks(Id, marksRequestDTO);
            return Ok(data);
        }

        [HttpGet("Get-Marks-By-ExamId")]
        public async Task<IActionResult> GetMarksByExamId(Guid examId)
        {
            try
            {
                var data = await _marksService.GetMarksByExamId(examId);
                return Ok(data);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);  
            }
        }
    }
}
