using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentrepository;
        public StudentService(IStudentRepository studentrepository) { 
            _studentrepository = studentrepository;
        }

        public async Task<List<Student>> GetStudentsForAttendance(int courseId)
        {
            var AttendanceList = new List<Student>();   
            var data = await _studentrepository.GetStudentsWithEnrollments();
            foreach (var student in data) {
                var enrollments = student.Enrollments.ToList();
                foreach (var enrollment in enrollments) {
                    if (enrollment.CourseId == courseId) {
                        AttendanceList.Add(student);
                    }
                }
            }
            return AttendanceList;
        }
    }
}
