using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDTOs;
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

        //public async Task<List<Student>> GetStudentsForAttendance(int courseId)
        //{
        //    var AttendanceList = new List<Student>();   
        //    var data = await _studentrepository.GetStudentsWithEnrollments();
        //    foreach (var student in data) {
        //        var enrollments = student.Enrollments.ToList();
        //        foreach (var enrollment in enrollments) {
        //            if (enrollment.CourseId == courseId) {
        //                AttendanceList.Add(student);
        //            }
        //        }
        //    }
        //    return AttendanceList;
        //}


        public async Task<StudentResponceDTO> GetStudentById(string utNumber)
        {
            var student = await _studentrepository.GetStudentById(utNumber);
            if (student == null)
            {
                return null;  // Handle not found case
            }
            return new StudentResponceDTO
            {
                UTNumber = student.UTNumber,
                Batch = student.Batch,
                UserId = student.UserId
            };
        }


        public async Task<List<StudentResponceDTO>> GetAllStudent()
        {
            var students = await _studentrepository.GetAllStudent();
            return students.Select(student => new StudentResponceDTO
            {
                UTNumber = student.UTNumber,
                Batch = student.Batch,
                UserId = student.UserId
            }).ToList();
        }


        public async Task<StudentResponceDTO> AddStudent(StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
                Batch = studentRequestDto.Batch,
                UserId = studentRequestDto.UserId
            };

            var createdStudent = await _studentrepository.AddStudent(student);

            return new StudentResponceDTO
            {
                UTNumber = createdStudent.UTNumber,
                Batch = createdStudent.Batch,
                UserId = createdStudent.UserId
            };
        }

        public async Task<StudentResponceDTO> UpdateStudent(StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
                Batch = studentRequestDto.Batch,
                UserId = studentRequestDto.UserId
            };

            var updatedStudent = await _studentrepository.UpdateStudent(student);

            return new StudentResponceDTO
            {
                UTNumber = updatedStudent.UTNumber,
                Batch = updatedStudent.Batch,
                UserId = updatedStudent.UserId
            };
        }

    }
}
