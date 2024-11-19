using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;

namespace StudentManagement_System_API.IService
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateUserAsync(UserRequestDTO userRequestDTO);
        Task<IEnumerable<UserResponseDTO>> GetAllUsersAsync();
        Task<UserResponseDTO> GetUserAsync(string id);
        Task UpdateUserAsync(string id, UserRequestDTO userRequestDTO);
        Task DeleteUserAsync(string id);
    }
}
