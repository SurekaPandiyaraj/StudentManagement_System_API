using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository , IEnrollmentRepository enrollmentRepository)
        {
            _attendanceRepository = attendanceRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(Guid id)
        {
            return await _attendanceRepository.GetByAttendancesById(id);
        }

        public async Task<List<Student>> GetStudentsByCourseId(Guid CourseId)
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentsByCourseId(CourseId);
            var students = new List<Student>();
            foreach (var enrollment in enrollments)
            {
                var student = enrollment.Student;
                students.Add(student);
            }

            return students;
        }
        public async Task CreateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddStudentAttendence(attendance);
        }

        //public async Task UpdateAttendanceAsync(Attendance attendance)
        //{
        //    await _attendanceRepository.UpdateAsync(attendance);
        //}

        //public async Task DeleteAttendanceAsync(int id)
        //{
        //    await _attendanceRepository.DeleteAsync(id);
        //}
    }
}