using StudentManagement_System_API.DTOS.RequestDtos;

namespace StudentManagement_System_API.IService
{
    public interface ILoginService
    {
        Task<string> Register(UserRequestDTOs userRequest);
        Task<string> Login(string UserId, string password);
    }
}
