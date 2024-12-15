  using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using System.Numerics;

namespace StudentManagement_System_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDTOs> CreateUser(UserRequestDTOs userRequestDTOs)
        {
            var user = new User
            {
               
                UserId = userRequestDTOs.UserId,
                FirstName = userRequestDTOs.FirstName,
                LastName = userRequestDTOs.LastName,
                Email = userRequestDTOs.Email,
                NICNumber = userRequestDTOs.NICNumber,
                PasswordHash = userRequestDTOs.Password,
                UserRole = userRequestDTOs.UserRole,
            };

            var data = await _repository.CreateUserAsync(user);

            var resuser = new UserResponseDTOs
            {
                
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName= data.LastName,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole.ToString(),
                IsDeleted = (bool)data.IsDelete,
            };
            return resuser;
        }

        public async Task<UserResponseDTOs> GetUserById (string userId) 
        {
            var data = await _repository.GetUserByUserId(userId);
            var resuser = new UserResponseDTOs
            {
              
                UserId = data.UserId,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole.ToString(),
                IsDeleted = (bool)data.IsDelete,
            };
            return resuser;
        }

        public async Task<List<UserResponseDTOs>> GetAllUsers()
        {
            var data = await _repository.GetUsersAsync();

            var resusers = data.Select(x => new UserResponseDTOs
            {
                
                UserId = x.UserId,
                DateOfBirth = (DateTime)x.DateOfBirth,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                NICNumber = x.NICNumber,
                Password = x.PasswordHash,
                UserRole = x.UserRole.ToString(),
                IsDeleted = (bool)x.IsDelete,
            }).ToList(); 
            return resusers;
        }

        public async Task<UserResponseDTOs> GetUserByUserId(string userId)
        {
            var data = await _repository.GetUserByUserId(userId);

            var resusers = new UserResponseDTOs
            {
               
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole.ToString(),
                IsDeleted = (bool)data.IsDelete,
            };
            return resusers;
        }

        public async Task<UserResponseDTOs> UpdateUser(Guid UserId, UserRequestDTOs userrequest)
        {
            var user = new User
            {
             
                UserId = userrequest.UserId,
                FirstName = userrequest.FirstName ,
                LastName = userrequest.LastName ,
                Email = userrequest.Email,
                NICNumber = userrequest.NICNumber,
                PasswordHash = userrequest.Password,
                UserRole = userrequest.UserRole

            };
            var data = await _repository.UpdateUserAsync(user);

            var resUser = new UserResponseDTOs
            {
               
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole.ToString(),
                IsDeleted = (bool)data.IsDelete

            };
            return resUser;
        }

        public async Task Deleteuser (string userId)
        {
            await _repository.DeleteUserAsync(userId);
        }
    }
}
     
