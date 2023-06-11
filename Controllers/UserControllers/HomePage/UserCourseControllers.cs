

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;
using ELearning.Commons;

namespace ELearning.Controllers.UserControllers.HomePage
{
    [ApiController]

    public class UserCourseControllers : Controller
    {
        private readonly ILogger<UserCourseControllers> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public UserCourseControllers(ILogger<UserCourseControllers> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("user/course/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var query = await _elearningContext.CourseMix.FromSqlRaw("call elearning.GetAllCourseWithSkill()").ToListAsync();

            return StatusCode(200, query);
        }

    }
}

