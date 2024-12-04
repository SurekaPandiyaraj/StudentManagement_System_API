using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface IUserService
    {
        Task<UserResponseDTOs> CreateUser(UserRequestDTOs userRequestDTOs);
        Task<UserResponseDTOs> GetUserById(string userId);
        Task<List<UserResponseDTOs>> GetAllUsers();
        Task<UserResponseDTOs> GetUserByUserId(string userId);
        Task<UserResponseDTOs> UpdateUser(Guid UserId, UserRequestDTOs userrequest);
        Task Deleteuser(string userId);
    }
}
