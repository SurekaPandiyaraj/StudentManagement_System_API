using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
    }
}
