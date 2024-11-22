using Microsoft.Azure.Documents;

namespace StudentManagement_System_API.IRepository
{
    public interface ILoginRepository
    {
        Task<User> AddUser(User user);
        Task<Entity.User> AddUser(Entity.User user);
        Task<User> GetUserByUserId(string userId);
    }
}
