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
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                NICNumber = users.NICNumber,
                UserRole = users.UserRole,
                DateOfBirth = users.DateOfBirth,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };

            if (users.UserRole != Role.Student)
            {
                req.UserId = users.UserId;
                if (users.UserRole == Role.Manager)
                {
                    req.PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@2024"); // Default password for Manager
                }
                var user = await _loginRepository.AddUser(req);
            }
            else
            {
                req.UserId = users.UTNumber;
                var studentUser = await _loginRepository.AddUser(req);
                var student = new Student
                {
                    User = studentUser,
                    Batch = users.Batch,
                    UTNumber = users.UTNumber,
                    Group = (Batch)users.Group,
                   
                };
                var getStudent = await _studentRepository.CreateStudent(student);
            }

            var token = CreateToken(req);
            return token;
        }

        public async Task<TokenModel> Login(LogInRequestDTO logInRequest)
        {
            var user = await _loginRepository.GetUserById(logInRequest.UserId);
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
            if (!BCrypt.Net.BCrypt.Verify(logInRequest.Password, user.PasswordHash))
            {
                throw new Exception("Wrong Password!");
            }
            return CreateToken(user);
        }

        // Create token for User
        private TokenModel CreateToken(User user)
        {
            var claimsList = new List<Claim>();

           
            claimsList.Add(new Claim("FirstName", user.FirstName));
            claimsList.Add(new Claim("LastName", user.LastName));
            claimsList.Add(new Claim("Email", user.Email));
            claimsList.Add(new Claim("NICNumber", user.NICNumber));
            claimsList.Add(new Claim("UserId", user.UserId));
            claimsList.Add(new Claim("UserRole", user.UserRole.ToString()));

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
            );
            var response = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }

        // Create token for Student
        private TokenModel CreateToken(Student student)
        {
            var claimsList = new List<Claim>();

            claimsList.Add(new Claim("UTNumber", student.UTNumber.ToString()));
            claimsList.Add(new Claim("Batch", student.Batch));

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
            );
            var response = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }
    }
}


