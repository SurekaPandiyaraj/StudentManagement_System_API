using Microsoft.Azure.Documents;
using Microsoft.IdentityModel.Tokens;
using StudentManagement_System_API.DTOs.RequestDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace StudentManagement_System_API.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<string> Register(UserRequestDTO userRequest)
        {
            var req = new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                UserRole = userRequest.UserRole,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password)
            };

            var user = await _loginRepository.AddUser(req);
            var token = CreateToken(user);
            return token;

        }

        public async Task<string> Login(string UserId, string password)
        {
            var user = await _loginRepository.GetUserByUserId(UserId);
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
            if(!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Wrong Password!");
            }
            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("Id", user.Id.ToString()));
            claimsList.Add(new Claim("Name", user.Id));
            claimsList.Add(new Claim("Email", user.Id));
            claimsList.Add(new Claim("UserRole", user.Id.ToString()));

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
