using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControllers : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentControllers(IStudentService studentService)
        {
            _studentService = studentService;
        }
    }
}
