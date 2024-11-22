using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface IUserService
    {
        Task<UserResponseDTOs> CreateUserAsync(UserRequestDTOs userRequestDTO);
        Task<IEnumerable<UserResponseDTOs>> GetAllUsersAsync();
        Task<UserResponseDTOs> GetUserAsync(string id);
        Task UpdateUserAsync(string id, UserRequestDTOs userRequestDTO);
        Task DeleteUserAsync(string id);
    }
}
