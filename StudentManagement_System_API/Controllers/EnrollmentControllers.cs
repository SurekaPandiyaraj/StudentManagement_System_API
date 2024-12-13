using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentControllers : ControllerBase
    {
        private readonly IEntrollementService _entrollment;

        public EnrollmentControllers(IEntrollementService entrollment)
        {
            _entrollment = entrollment;
        }

        [HttpPost]
        public async Task<IActionResult> AddEntrollement (EntrollementRequestDTO entrollementRequestDTOs)
        {
            var data = await _entrollment.AddEntrollement(entrollementRequestDTOs);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntrollmentById (Guid Id)
        {
            var data = await _entrollment.GetEnrollmentById(Id);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEntrollement(Guid Id)
        {
            await _entrollment.Delete(Id);
            return NoContent();
        }
    }
}
