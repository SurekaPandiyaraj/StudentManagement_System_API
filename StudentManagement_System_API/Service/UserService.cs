using StudentManagement_System_API.Database;
using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;

namespace StudentManagement_System_API.Service
{
    public class UserService:IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto)
        {
            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),  // Assuming UserId is generated
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Password = userRequestDto.Password, // In a real app, don't store raw passwords!
                UserRole = userRequestDto.UserRole
            };

            var createdUser = await _repository.CreateUserAsync(user);
            return new UserResponseDto
            {
                UserId = createdUser.UserId,
                Name = createdUser.Name,
                Email = createdUser.Email,
                UserRole = createdUser.UserRole
            };
        }
    }
}
