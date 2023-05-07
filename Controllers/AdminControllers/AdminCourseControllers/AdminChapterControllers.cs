

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;

namespace ELearning.Controllers.AdminControllers.AdminCourseControllers.AdminChapterController
{
    [ApiController]

    public class ChapterController : Controller
    {
        private readonly ILogger<ChapterController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public ChapterController(ILogger<ChapterController> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("/chapter/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Chapters
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("/chapter/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.Chapters.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("/chapter/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var ChapterData = await (from x in _elearningContext.Chapters
                                     where x.ID == id
                                     select x).FirstOrDefaultAsync();
            if (ChapterData == null) return StatusCode(404);
            return StatusCode(200, Json(new { Chapter = ChapterData }));
        }

        [Route("/chapter/create")]
        [HttpPost]
        public async Task<IActionResult> Create(ChapterDTO data)
        {
            Chapter newChapter = new();

            newChapter.CourseID = data.CourseID;
            newChapter.ChapterName = data.ChapterName;

            await _elearningContext.AddAsync(newChapter);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, Json(new { Chapter = newChapter }));
        }
    }
}

