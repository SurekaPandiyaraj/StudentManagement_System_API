using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableControllers : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableControllers(TimetableService timetableService)
        {
            _timetableService = timetableService;
        }
    }
}
