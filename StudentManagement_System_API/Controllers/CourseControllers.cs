using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseControllers : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseControllers(ICourseService courseService)
        {
            _courseService = courseService;
        }
    }
}
