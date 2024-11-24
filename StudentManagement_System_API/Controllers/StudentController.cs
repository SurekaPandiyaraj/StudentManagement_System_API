using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentById(string utNumber)
        {
            var student = await _studentService.GetStudentById(utNumber);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

    }
}
