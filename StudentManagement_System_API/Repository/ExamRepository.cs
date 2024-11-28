using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly StudentManagementContext _context;

        public ExamRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetAllExam()
        {
            var data = await _context.Exams.ToListAsync();
            return data;
        }

        public async Task<Exam> GetByExamById(Guid id)
        {
            var data = await _context.Exams.FirstOrDefaultAsync(x => x.Id == id);
            return data;

        }

        public async Task<Exam> AddExam(Exam exam)
        {
            var data = await _context.AddAsync(exam);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Exam> UpdateAsync(Exam exam)
        {
           var data = await GetByExamById(exam.Id);

            if (data == null) return null;
            {
                data.Id = exam.Id;
                data.CourseId = exam.CourseId;
                data.Course = exam.Course;
                data.CutOffMarks = exam.CutOffMarks;


                await _context.SaveChangesAsync();

                return exam;

            }
        }

      
    }
}