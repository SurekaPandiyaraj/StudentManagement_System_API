using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.DTOs.ResponseDTOs;

namespace StudentManagement_System_API.IService
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserRequestDto userRequestDto);
    }
}
