using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamControllers : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamControllers(ExamService examService)
        {
            _examService = examService;
        }
    }
}
