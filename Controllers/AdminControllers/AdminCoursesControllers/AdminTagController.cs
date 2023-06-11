

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;

namespace ELearning.Controllers.AdminControllers.AdminCourseControllers.AdminTagController
{
    [ApiController]

    public class AdminTagController : Controller
    {
        private readonly ILogger<AdminTagController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public AdminTagController(ILogger<AdminTagController> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("admin/tag/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Tag
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, list);
        }

        [Route("/tag/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.Tag.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("/tag/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var RequireData = await (from x in _elearningContext.Tag
                                     where x.ID == id
                                     select x).FirstOrDefaultAsync();
            if (RequireData == null) return StatusCode(404);
            return StatusCode(200, Json(new { Require = RequireData }));
        }

        [Route("/tag/create")]
        [HttpPost]
        public async Task<IActionResult> Create(TagDTO data)
        {
            Tag newRequire = new();

            newRequire.CourseID = data.CourseID;
            newRequire.TagName = data.TagName;

            await _elearningContext.AddAsync(newRequire);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, Json(new { Require = newRequire }));
        }
    }
}

