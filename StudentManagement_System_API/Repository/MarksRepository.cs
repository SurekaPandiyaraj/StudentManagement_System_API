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
            var data = await _context.Marks.ToListAsync();
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
            data.UTNumber = marks.UTNumber;
            data.Exam = marks.Exam;
            data.ExamId = marks.ExamId;

            await _context.SaveChangesAsync();

            return data;
        }
    }
}
