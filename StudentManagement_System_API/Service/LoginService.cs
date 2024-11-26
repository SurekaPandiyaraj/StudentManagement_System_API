using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagement_System_API.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration, IStudentRepository studentRepository)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
            _studentRepository = studentRepository;
        }

        public async Task<TokenModel> Register(UserRequestDTOs users)
        {
            var req = new User
            {
                Name = users.Name,
                Email = users.Email,
                NICNumber = users.NICNumber,
                UserRole = users.UserRole,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
           
            if(users.UserRole != Role.Student)
            {
                req.UserId = users.UserId;
                if(users.UserRole == Role.Manager)
                {
                    req.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@2024");
                }
                var user = await _loginRepository.AddUser(req);
            }
            else
            {
                req.UserId =users.UTNumber;  
                var studentUser = await _loginRepository.AddUser(req);
                var student = new Student
                {
                    User = studentUser,
                    Batch = users.Batch,
                    UTNumber = users.UTNumber
                };
                var getStudent = await _studentRepository.AddStudent(student);
                  
            }
            var token = CreateToken(req);
            return token;

        }

        //public async Task<TokenModel> AddStudent(StudentRegisterRequest studentRequest)
        //{
            

        //    var student = await _studentRepository.GetStudentById(studentRequest.UTNumber);
        //    if(student == null)
        //    {
        //        throw new Exception("Student Not Found");
        //    }
        //    else
        //    {   var getUser = await _loginRepository.GetUserById(studentRequest.UTNumber);
        //        getUser.UserId = studentRequest.UTNumber;
        //        getUser.PasswordHash = studentRequest.Password;
        //        var user = await _loginRepository.UpdateUser(getUser);
        //        var token = CreateToken(user);
        //        return token;
        //    }
          
        //}

        public async Task<TokenModel> Login(string UserId, string password)
        {
            var user = await _loginRepository.GetUserById(UserId);
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Wrong Password!");
            }
            return CreateToken(user);
        }

        // Register For User

        private TokenModel CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            
               claimsList.Add(new Claim("Id",user.Id.ToString()));
               claimsList.Add(new Claim("Name", user.Name));
               claimsList.Add(new Claim("Email", user.Email));
               claimsList.Add(new Claim("NICNumber", user.NICNumber));
               claimsList.Add(new Claim("UserRole", user.UserRole.ToString()));
            

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"], 
                audience:_configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            var responce = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return responce;
        }

        // Register For Student

        private TokenModel CreateToken(Student student)
        {
            var claimsList = new List<Claim>();

            claimsList.Add(new Claim("UTNumber", student.UTNumber.ToString()));
            claimsList.Add(new Claim("Batch", student.Batch));
            


            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            var responce = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return responce;
        }
    }
}

