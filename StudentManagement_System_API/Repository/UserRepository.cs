using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentManagementContext _context;

        public UserRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var data = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var data = await _context.Users.Where(a => (bool)!a.IsDelete).ToListAsync();
            return data;
        }

        //public async Task<User> GetUserByIdAsync(Guid Id)
        //{
        //    var data = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
        //    return data;
        //}

        public async Task<User> GetUserByUserId (string UserId)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId && (bool)!x.IsDelete);
            return data;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
           
         var data =  _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return data.Entity;


        }

        public async Task DeleteUserAsync(string Id)
        {
            var data = await GetUserByUserId(Id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Users.Update(data);
                await _context.SaveChangesAsync();

            }

        }
    }
}
