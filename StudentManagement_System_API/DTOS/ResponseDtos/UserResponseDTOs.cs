﻿using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class UserResponseDTOs
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NICNumber { get; set; }
        public string UserRole { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
