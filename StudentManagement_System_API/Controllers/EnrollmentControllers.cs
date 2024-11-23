﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentControllers : ControllerBase
    {
        private readonly IEntrollementService _enrollmentService;

        public EnrollmentControllers(IEntrollementService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
    }
}
