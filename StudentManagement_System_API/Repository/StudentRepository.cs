using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
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

        public async Task<List<Student>> GetStudentsWithEnrollments()
        {
            var data = await _studentManagementContext.Students.Include(s => s.Enrollments).ToListAsync();
            return data;
        }
    }
}
