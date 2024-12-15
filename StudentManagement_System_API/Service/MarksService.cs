using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.DTOS.ResponseDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class MarksService : IMarksService
    {
        private readonly IMarksRepository _marksRepository;

        public MarksService(IMarksRepository marksRepository)
        {
            _marksRepository = marksRepository;
        }

        public async Task<MarksResponceDTO> AddMarks(MarksRequestDTO marksRequest)
        {
            var marks = new Marks
            {
                ExamId = (Guid)marksRequest.ExamId,
                StudentUTNumber = marksRequest.UTNumber,
                IsApproved = false,
                MarksObtained = marksRequest.Marks
            };

            var data = await _marksRepository.AddMarks(marks);

            var req = new MarksResponceDTO
            {
                Id = data.Id,
                ExamId= data.ExamId,
                UTNumber = data.StudentUTNumber,
                IsApproved = data.IsApproved,
                MarksObtained= data.MarksObtained
            };
            return req;
        }

        public async Task<MarksResponceDTO> GetMarksById(Guid id)
        {
            var data = await _marksRepository.GetMarksById(id);
            var req = new MarksResponceDTO
            {
                Id = data.Id,
                ExamId = data.ExamId,
                UTNumber = data.StudentUTNumber,
                IsApproved = data.IsApproved,

            };
            return req;
        }

        public async Task<List<Marks>> GetAllMarks()
        {
            var data = await _marksRepository.GetAllMarks();
            return data;
        }

        public async Task<MarksResponceDTO> UpdateMarks(Guid MarkId, MarksRequestDTO marksRequest)
        {
            //var marks = new Marks
            //{
            //    ExamId = (Guid)marksRequest.ExamId,
            //    StudentUTNumber = marksRequest.UTNumber,
            //    IsApproved = (bool)marksRequest.IsApproved,

            //};
            var marks = await _marksRepository.GetMarksById(MarkId);
            marks.IsApproved = (bool)marksRequest.IsApproved;

            var data = await _marksRepository.UpdateMarks(marks);

            var req = new MarksResponceDTO
            {
                Id = data.Id,
                ExamId = data.ExamId,
                UTNumber = data.StudentUTNumber,
                IsApproved = data.IsApproved,
            }; 
            return req;
        }
        public async Task<List<Marks>> GetMarksByExamId(Guid examId)
        {
            var data = await _marksRepository.GetMarksByExamId(examId);
            return data;
        }

    }
}
