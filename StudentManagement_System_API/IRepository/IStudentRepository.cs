using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IStudentRepository
    {
        //Task<List<Student>> GetStudentsWithEnrollments();

        Task<Student> GetStudentById(string utNumber);
        Task<List<Student>> GetAllStudent();
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);

    }
}
