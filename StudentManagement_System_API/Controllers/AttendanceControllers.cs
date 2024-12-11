using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.Entity;
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
        // GET: api/Attendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        // GET: api/Attendance/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(Guid id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpGet("Get-attendees")]
        public async Task<ActionResult<Attendance>> GetAttendeesByCourseAndBatch(Guid id,Batch batch)
        {
            var attendance = await _attendanceService.GetStudentsByCourseId(id, batch);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpGet("Get-students")]
        public async Task<IActionResult>GetStudents(Guid timeSlotId)
        {
            var data = await _attendanceService.GetStudents(timeSlotId);
            return Ok(data);
        }

        // POST: api/Attendance
        [HttpPost]
        public async Task<ActionResult> CreateAttendance([FromBody] AttendanceRequestDTO attendanceRequest)
        {
            if (attendanceRequest == null)
            {
                return BadRequest("Attendance data is required.");
            }

           var data = await _attendanceService.CreateAttendanceAsync(attendanceRequest);
            return Ok(data);
        }

        //PUT: api/Attendance/{id }
    
    //[HttpPut("{id}")]
    //public async Task<ActionResult> UpdateAttendance(Guid id, [FromBody] Attendance attendance)
    //{
    //    if (attendance == null || id != attendance.Id)
    //    {
    //        return BadRequest("Invalid attendance data.");
    //    }

    //    var existingAttendance = await _attendanceService.GetAttendanceByIdAsync(id);
    //    if (existingAttendance == null)
    //    {
    //        return NotFound();
    //    }

    //        await _attendanceService.GetAttendanceByIdAsync(id);
    //    return NoContent(); 
    //}

    [HttpGet("Get-students{courseId}")]
        public async Task<IActionResult> GetStudentsByCourseId(Guid courseId, Batch batch)
        {
            var data = await _attendanceService.GetStudentsByCourseId(courseId, batch);
            return Ok(data);
        }

        //// DELETE: api/Attendance/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteAttendance(Guid id)
        //{
        //    var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
        //    if (attendance == null)
        //    {
        //        return NotFound();
        //    }

        //    await _attendanceService.(id);
        //    return NoContent(); // Success, no content to return
        //}
    }
}
  
