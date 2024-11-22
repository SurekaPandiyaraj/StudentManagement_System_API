using StudentManagement_System_API.DTOs.RequestDTOs;

namespace StudentManagement_System_API.IService
{
    public interface ILoginService
    {
        Task<string> Register(UserRequestDTO userRequest);
        Task<string> Login(string UserId, string password);
    }
}
