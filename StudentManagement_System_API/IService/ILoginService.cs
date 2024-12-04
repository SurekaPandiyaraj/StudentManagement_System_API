using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface ILoginService
    {
        Task<TokenModel> Register(UserRequestDTOs userRequest);
        Task<TokenModel> Login(LogInRequestDTO logInRequest);
    }
}
