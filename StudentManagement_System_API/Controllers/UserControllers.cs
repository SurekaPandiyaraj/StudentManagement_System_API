using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }
        // Create user
        [HttpPost]
        public async Task<ActionResult<UserResponseDTOs>> CreateUser(UserRequestDTOs userRequestDTO)
        {
            var createdUser = await _userService.CreateUserAsync(userRequestDTO);
            return Ok(createdUser);
        }

        // Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTOs>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTOs>> GetUser(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // Update user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserRequestDTOs userRequestDTO)
        {
            await _userService.UpdateUserAsync(id, userRequestDTO);
            return NoContent();
        }

        // Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
