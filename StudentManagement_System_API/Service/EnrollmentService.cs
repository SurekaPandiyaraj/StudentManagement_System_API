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

        public async Task<List<EntrollementResponceDTO>> AddEntrollement(EntrollementRequestDTO entrollementRequestDTOs)
        {
            var enrolls = new List<Enrollment>();
            foreach (var item in entrollementRequestDTOs.CourseIds)
            {
                var enroll = new Enrollment();
                enroll.StudentId = entrollementRequestDTOs.StudentId;
                enroll.CourseId = item;
                enroll.EnrolledDate = DateTime.Now; 
                enrolls.Add(enroll);
            }

            var data = await _enrollement.AddEnrollment(enrolls);

            var res = data.Select(d => new EntrollementResponceDTO
            {
                EnrolledDate = d.EnrolledDate,
                CourseId = d.CourseId,
                StudentId = d.StudentId,
            }).ToList();
            return res;
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
