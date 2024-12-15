using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IMarksRepository
    {
        Task<Marks> AddMarks(Marks marks);
        Task<List<Marks>> GetAllMarks();
        Task<Marks> GetMarksById(Guid id);
        Task<Marks> UpdateMarks(Marks marks);
        Task<List<Marks>> GetMarksByExamId(Guid examId);
    }
}
