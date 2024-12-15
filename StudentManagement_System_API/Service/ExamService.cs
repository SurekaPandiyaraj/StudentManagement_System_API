using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task<ExamResponceDTO> AddExam(ExamRequestDTO examRequestDTO)
        {
            var exam = new Exam
            {
                CourseId = examRequestDTO.CourseId,
                ExamDate = examRequestDTO.ExamDate,
                Group = examRequestDTO.Group,
                Batch = examRequestDTO.Batch

            };
            var data = await _examRepository.AddExam(exam);

            var req = new ExamResponceDTO
            {
                CourseId = data.CourseId,
                ExamDate = data.ExamDate,
                Group = data.Group,
                Batch = data.Batch,
            };
            return req;

        }
        public async Task<ExamResponceDTO> GetExamById(Guid id)
        {
            var data = await _examRepository.GetByExamById(id);
            var req = new ExamResponceDTO
            {
                CourseId = data.CourseId,
                ExamDate = data.ExamDate,
                Batch = data.Batch,
                Group = data.Group,
                Course = data.Course,
                Marks = data.Marks,
                Id = data.Id
            };
            return req;
        }

        public async Task<List<ExamResponceDTO>> GetAllExams()
        {
            var data = await _examRepository.GetAllExam();

            var req = data.Select(e => new ExamResponceDTO
            {
                CourseId = e.CourseId,
                ExamDate = e.ExamDate,
                Batch = e.Batch,
                Group = e.Group,
                Id = e.Id,
                Course  = e.Course,
            }).ToList(); ;
            return req;
        }

        public async Task<ExamResponceDTO> UpdateExam(Guid id, ExamRequestDTO examRequest)
        {
            var getExam = await _examRepository.GetByExamById(id);
            getExam.CourseId = examRequest.CourseId;
            getExam.ExamDate = examRequest.ExamDate;
            var data = await _examRepository.UpdateAsync(getExam
                );

            var req = new ExamResponceDTO
            {
                CourseId = data.CourseId,
                ExamDate = data.ExamDate,

            };
            return req;
        }
    }
}