using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IExamRepository
    {
        Task<Exam> UpdateAsync(Exam exam);
        Task<Exam> AddExam(Exam exam);
        Task<Exam> GetByExamById(Guid id);
        Task<List<Exam>> GetAllExam();
    }
}
