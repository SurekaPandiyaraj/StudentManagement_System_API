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
                CutOffMarks = examRequestDTO.CutOffMarks,
            };
            var data = await _examRepository.AddExam(exam);

            var req = new ExamResponceDTO
            {
                CourseId = examRequestDTO.CourseId,
                ExamDate = examRequestDTO.ExamDate,
                MaximumMarks = examRequestDTO.MaximumMarks,
                CutOffMarks = examRequestDTO.CutOffMarks,
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

                    CutOffMarks = data.CutOffMarks,

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
                CutOffMarks = e.CutOffMarks,
            }).ToList(); ;
            return req;
        }

        public async Task<ExamResponceDTO> UpdateExam(Guid id, ExamRequestDTO examRequest)
        {
            var getExam = await _examRepository.GetByExamById(id);
            getExam.CourseId = examRequest.CourseId;
            getExam.ExamDate = examRequest.ExamDate;
            getExam.CutOffMarks = examRequest.CutOffMarks;
            var data = await _examRepository.UpdateAsync(getExam
                );

            var req = new ExamResponceDTO
            {
                CourseId = data.CourseId,
                ExamDate = data.ExamDate,
                CutOffMarks = data.CutOffMarks,

            };
            return req;
        }
    }
}