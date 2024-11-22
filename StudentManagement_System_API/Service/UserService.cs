using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserResponseDTOs> CreateUserAsync(UserRequestDTOs userRequestDTO)
        {
            // Manually map UserRequestDTO to User entity
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),  // Assuming GUID as ID generator for the user
                Name = userRequestDTO.Name,
                Email = userRequestDTO.Email,
                PasswordHash = userRequestDTO.Password,
                UserRole = userRequestDTO.UserRole
            };

            var createdUser = await _repository.CreateUserAsync(user);

            // Return the response DTO after creation
            return new UserResponseDTOs
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                UserRole = createdUser.UserRole
            };
        }

        public async Task<IEnumerable<UserResponseDTOs>> GetAllUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            // Manually map User to UserResponseDTO for each user
            var userDtos = users.Select(user => new UserResponseDTOs
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserRole = user.UserRole
            });

            return userDtos;
        }

        public async Task<UserResponseDTOs> GetUserAsync(string id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) return null;

            // Manually map User to UserResponseDTO
            return new UserResponseDTOs
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserRole = user.UserRole
            };
        }

        public async Task UpdateUserAsync(string id, UserRequestDTOs userRequestDTO)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) return;

            // Manually update User entity from UserRequestDTO
            user.Name = userRequestDTO.Name;
            user.Email = userRequestDTO.Email;
            user.PasswordHash = userRequestDTO.Password;
            user.UserRole = userRequestDTO.UserRole;

            await _repository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _repository.DeleteUserAsync(id);
        }
    }
}
