﻿

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.Course;

namespace ELearning.Controllers.AdminControllers.AdminCourseControllers.AdminRequireController
{
    [ApiController]

    public class AdminMainTypeController : Controller
    {
        private readonly ILogger<AdminMainTypeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public AdminMainTypeController(ILogger<AdminMainTypeController> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            this._elearningContext = elearningContext;
        }


        [Route("admin/course/main_type/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.MainTypes
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, (list));
        }

        [Route("admin/course/main_type/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.MainTypes.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, s);
        }

        [Route("admin/course/main_type/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var mainTypeData = await (from x in _elearningContext.MainTypes
                                      where x.ID == id
                                      select x).FirstOrDefaultAsync();
            if (mainTypeData == null) return StatusCode(404);
            return StatusCode(200, Json(new { MainType = mainTypeData }));
        }

        [Route("admin/course/main_type/create")]
        [HttpPost]
        public async Task<IActionResult> Create(MainTypeDTO data)
        {
            MainType newMainType = new();
            newMainType.TypeName = data.TypeName;

            await _elearningContext.AddAsync(newMainType);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, newMainType);
        }
    }
}

