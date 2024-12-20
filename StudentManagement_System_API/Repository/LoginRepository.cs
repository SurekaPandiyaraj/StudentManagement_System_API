﻿

using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class LoginRepository : ILoginRepository

    {
        private readonly StudentManagementContext _context;
        public LoginRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            var data = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<User> UpdateUser(User user)
        {

           var data = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return data.Entity;
            
        }

        public async Task<User> GetUserById(string userId)
        {
            var data = await _context.Users.SingleOrDefaultAsync(x => x.UserId == userId);
            return data;
        }
        
    }
}
