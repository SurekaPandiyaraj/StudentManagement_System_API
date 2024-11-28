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

        public async Task<MarksResponceDTO> CreateUser(MarksRequestDTO marksRequest)
        {
            var marks = new Marks
            {
                ExamId = marksRequest.ExamId,
                UTNumber = marksRequest.UTNumber,
                IsApproved = marksRequest.IsApproved,

            };

            var data = await _marksRepository.AddMarks(marks);

            var req = new MarksResponceDTO
            {
                Id = data.Id,
                ExamId= data.ExamId,
                UTNumber = data.UTNumber,
                IsApproved = data.IsApproved,
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
                UTNumber = data.UTNumber,
                IsApproved = data.IsApproved,

            };
            return req;
        }

        public async Task<List<MarksResponceDTO>> GetAllMarks()
        {
            var data = await _marksRepository.GetAllMarks();

            var req = data.Select(m => new MarksResponceDTO
            {
                ExamId = m.ExamId,
                UTNumber = m.UTNumber,
                IsApproved = m.IsApproved
            }).ToList();

            return req;
        }

        public async Task<MarksResponceDTO> UpdateMarks(Guid UserId, MarksRequestDTO marksRequest)
        {
            var marks = new Marks
            {

                ExamId = marksRequest.ExamId,
                UTNumber = marksRequest.UTNumber,
                IsApproved = marksRequest.IsApproved,

            };

            var data = await _marksRepository.UpdateMarks(marks);

            var req = new MarksResponceDTO
            {
                Id = data.Id,
                ExamId = data.ExamId,
                UTNumber = data.UTNumber,
                IsApproved = data.IsApproved,
            }; 
            return req;
        }

    }
}
