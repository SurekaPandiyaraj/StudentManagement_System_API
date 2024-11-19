using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceControllers : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceControllers(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

    }
}
