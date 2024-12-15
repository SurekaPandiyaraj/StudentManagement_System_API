using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using System.Runtime.InteropServices;

namespace StudentManagement_System_API.Repository
{
    public class MarksRepository : IMarksRepository
    {
        private readonly StudentManagementContext _context;

        public MarksRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<Marks> AddMarks(Marks marks)
        {
            var data = await _context.Marks.AddAsync(marks);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<Marks>> GetAllMarks()
        {
            var data = await _context.Marks.Include(m => m.Student).Include(m => m.Exam).ToListAsync();
            return data;
        }

        public async Task<Marks> GetMarksById(Guid id)
        {
            var data = await _context.Marks.FirstOrDefaultAsync(x => x.Id == id);
            return data;

        }

        public async Task<Marks> UpdateMarks(Marks marks)
        {
            var data = await GetMarksById(marks.Id);

            if (data == null) return null;

            data.Student = marks.Student;
            data.MarksObtained = marks.MarksObtained;
            data.StudentUTNumber = marks.StudentUTNumber;
            data.Exam = marks.Exam;
            data.ExamId = marks.ExamId;

            await _context.SaveChangesAsync();

            return data;
        }
        public async Task<List<Marks>> GetMarksByExamId(Guid examId)
        {
            var data = await _context.Marks.Where(m => m.ExamId == examId).Include(m => m.Student).Include(m =>m.Exam).ToListAsync();
            return data;
        }
    }
}
