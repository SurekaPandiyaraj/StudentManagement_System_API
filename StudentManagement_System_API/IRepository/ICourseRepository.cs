using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ICourseRepository
    {
        Task<Course> AddCourses(Course course);
        Task<List<Course>> GetallCourses();
        Task<Course> GetCourseById(Guid id);
        Task<Course> UpadteCourse(Course course);
        Task DeleteCourse(Guid id);
    }
}
