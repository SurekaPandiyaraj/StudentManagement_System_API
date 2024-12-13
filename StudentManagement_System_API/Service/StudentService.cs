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
        private readonly IUserRepository _userrepository;
        public StudentService(IStudentRepository studentrepository, IUserRepository userrepository)
        {
            _studentrepository = studentrepository;
            _userrepository = userrepository;
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
                IsActive = student.IsActive,
                Batch = student.Batch,
                Email = student.User.Email,
                FirstName = student.User.FirstName,
                LastName = student.User.LastName,
                DateOfBirth = student.User.DateOfBirth,
                NICNumber = student.User.NICNumber
            };
        }


        public async Task<List<StudentResponceDTO>> GetAllStudent()
        {
            var students = await _studentrepository.GetAllStudent();
         var responseList = new List<StudentResponceDTO>();
            foreach (var student in students)
            {
                var response = new StudentResponceDTO();
                response.UTNumber = student.UTNumber;
                response.Batch = student.Batch;
                response.FirstName = student.User.FirstName;
                response.LastName = student.User.LastName;
                response.Email = student.User.Email;
                response.DateOfBirth = student.User.DateOfBirth;
                response.NICNumber = student.User.NICNumber;
                responseList.Add(response);
               // responseList.Add(response);
            }
            return responseList;
        }


        public async Task<StudentResponceDTO> CreateStudent(StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
             
                Batch = studentRequestDto.Batch,
                UserId = studentRequestDto.UserId,
               
            };
            var user = new User
            {

            };

            var createdStudent = await _studentrepository.CreateStudent(student);

            return new StudentResponceDTO
            {
                UTNumber = createdStudent.UTNumber,
                Batch = createdStudent.Batch,
                IsActive = createdStudent.IsActive,
                UserId = createdStudent.UserId,
               
            };
        }

        public async Task<StudentResponceDTO> UpdateStudent(string utnumber,StudentRequestDTO studentRequestDto)
        {
            var student = new Student
            {
                UTNumber = studentRequestDto.UTNumber,
                Batch = studentRequestDto.Batch,
                UserId = studentRequestDto.UserId,
               
            };

            var updatedStudent = await _studentrepository.UpdateStudent(student);

            return new StudentResponceDTO
            {
                UTNumber = updatedStudent.UTNumber,
                IsActive= updatedStudent.IsActive,
                Batch = updatedStudent.Batch,
                UserId = updatedStudent.UserId,
              
            };
        }

        public async Task<bool> DeleteStudent(string utNumber)
        {
            return await _studentrepository.DeleteStudent(utNumber);
        }

        public async Task<StudentResponceDTO> softDelete(string utNumber)
        {
            var getstudent = await _studentrepository.GetStudentById(utNumber);
            if(getstudent == null)
            {
                throw new Exception("Student not found!");
            }
            var softDelete = await _studentrepository.UpdateStudent(getstudent);

            var studentDTO = new StudentResponceDTO();
            studentDTO.UTNumber = utNumber;
            studentDTO.IsActive = softDelete.IsActive;
            studentDTO.Batch = softDelete.Batch;
            return studentDTO;
        }


    }
}
