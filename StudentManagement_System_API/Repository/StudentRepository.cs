using StudentManagement_System_API.Database;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementContext _studentManagementContext;

        public StudentRepository(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }
    }
}
