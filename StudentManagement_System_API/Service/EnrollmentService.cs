using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class EnrollmentService : IEntrollementService
    {
        private readonly IEnrollmentRepository _enrollement;

        public EnrollmentService(IEnrollmentRepository enrollement)
        {
            _enrollement = enrollement;
        }

        public async Task<EntrollementResponceDTO> AddEntrollement(EntrollementRequestDTO requestDTO)
        {
            var enroll = new Enrollment
            {
                EnrolledDate = DateTime.Now,
                StudentId = requestDTO.StudentId,
                CourseId = requestDTO.CourseId
            };
            var data = await _enrollement.AddEnrollment(enroll);

            var resentroll = new EntrollementResponceDTO
            {
                EnrolledDate = DateTime.Now,
                StudentId = requestDTO.StudentId,
                CourseId = requestDTO.CourseId

            };
            return resentroll;
        }

        public async Task<List<EntrollementResponceDTO>> GetEnrollmentById(Guid CourseId)
        {
           var ent = await _enrollement.GetEnrollmentById(CourseId);

            var resEnt = ent.Select(a => new EntrollementResponceDTO
            {
                EnrolledDate = DateTime.Now,
                StudentId = a.StudentId,
                CourseId = a.CourseId
            }).ToList();
            return resEnt;

        }
        public async Task Delete(Guid CourseId)
        {
            await _enrollement.DeleteEntrollment(CourseId);
        }

    }
}
