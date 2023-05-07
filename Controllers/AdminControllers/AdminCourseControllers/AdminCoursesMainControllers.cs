

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;
using ELearning.Commons;

namespace ELearning.Controllers.AdminControllers.AdminCourseControllers.AdminCoursesMainController
{
    [ApiController]

    public class AdminCoursesMainControllers : Controller
    {
        private readonly ILogger<AdminCoursesMainControllers> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public AdminCoursesMainControllers(ILogger<AdminCoursesMainControllers> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("admin/courses/main/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Courses
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("admin/courses/main/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.Courses.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("admin/courses/main/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var CourseData = await (from x in _elearningContext.Courses
                                     where x.ID == id
                                     select x).FirstOrDefaultAsync();
            if (CourseData == null) return StatusCode(404);
            return StatusCode(200, Json(new { Course = CourseData }));
        }

        [Route("admin/courses/main/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseDTO data, [FromForm] IFormFile image)
        {
            Course newCourse = new();

            //newCourse.AuthorID = 0;
            newCourse.CourseTypeID = data.CourseTypeID;
            newCourse.CourseName = data.CourseName;
            newCourse.CourseFee = data.CourseFee;
            newCourse.Description = data.Description;
            newCourse.CourseState = data.CourseState;
            newCourse.Commission = data.Commission;
            newCourse.CourseImage = "course/image.jpeg";

            await _elearningContext.AddAsync(newCourse);
            await _elearningContext.SaveChangesAsync();

            await ELearning.Commons.ImageHandler.SaveImageAsync(image, "courses", "image", _env);

            return StatusCode(200, Json(new { Course = newCourse }));
        }
    }
}

