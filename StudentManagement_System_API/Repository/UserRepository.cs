using StudentManagement_System_API.Database;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentManagementContext _studentManagementContext;

        public UserRepository(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }
    }
}
