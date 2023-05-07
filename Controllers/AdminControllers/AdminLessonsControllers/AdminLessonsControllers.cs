

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;

namespace ELearning.Controllers.AdminControllers.AdminLessonsControllers;

[ApiController]

public class AdminLessonsControllers : Controller
{
    private readonly ILogger<AdminLessonsControllers> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly ElearningContext _elearningContext;
    public AdminLessonsControllers(ILogger<AdminLessonsControllers> logger, IWebHostEnvironment env, ElearningContext elearningContext)
    {
        _logger = logger;
        _env = env;
        _elearningContext = elearningContext;
    }


    [Route("admin/lessons/main/all")]
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var list = await (from n in _elearningContext.Lessons
                          orderby n.ID ascending
                          select n).ToListAsync();
        return StatusCode(200, (list));
    }

    [Route("admin/lessons/main/delete/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var s = await _elearningContext.Lessons.SingleAsync(x => x.ID == id);
        _elearningContext.Remove(s);
        await _elearningContext.SaveChangesAsync();
        return StatusCode(200, s);
    }

    [Route("admin/lessons/main/find/{id}")]
    [HttpGet]
    public async Task<IActionResult> Find([FromRoute] int id)
    {
        var lessonData = await (from x in _elearningContext.Lessons
                                 where x.ID == id
                                 select x).FirstOrDefaultAsync();
        if (lessonData == null) return StatusCode(404);
        return StatusCode(200, lessonData);
    }

    [Route("admin/lessons/main/create")]
    [HttpPost]
    public async Task<IActionResult> Create(LessonDTO data)
    {
        Lesson newLesson = new();

        newLesson.ChapterID = data.ChapterID;
        newLesson.LessonName = data.LessonName;
        newLesson.LessonURL = data.LessonURL;
        newLesson.Duration = data.Duration;

        await _elearningContext.AddAsync(newLesson);
        await _elearningContext.SaveChangesAsync();
        return StatusCode(200, newLesson);
    }
}

