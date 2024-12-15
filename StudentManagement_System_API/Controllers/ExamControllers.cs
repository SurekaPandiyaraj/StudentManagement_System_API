using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamControllers : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamControllers(IExamService examService)
        {
            _examService = examService;
        }
        // POST: api/exams
        [HttpPost]
        public async Task<IActionResult> AddExams( ExamRequestDTO exam)
        {
            try
            {
                var data = await _examService.AddExam(exam);
                return Ok(data);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/exams
        [HttpGet]
        public async Task<IActionResult> GetAllExam()
        {
            var exams = await _examService.GetAllExams();
            return Ok(exams);
        }

        // GET: api/exams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exam = await _examService.GetExamById(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        

        // PUT: api/exams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExams(Guid id,  ExamRequestDTO exam)
        {
            if (exam == null || exam.CourseId != id)
            {
                return BadRequest();
            }

            var existingExam = await _examService.GetExamById(id);
            if (existingExam == null)
            {
                return NotFound();
            }

            await _examService.UpdateExam(id ,exam);
            return NoContent();
        }

       
    }
}