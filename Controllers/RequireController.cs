

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.Require;

namespace ELearning.Controllers
{
    [ApiController]

    public class RequireController : Controller
    {
        private readonly ILogger<RequireController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public RequireController(ILogger<RequireController> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            this._elearningContext = elearningContext;
        }


        [Route("/require/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Requires
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("/require/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.Requires.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("/require/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var RequireData = await (from x in _elearningContext.Requires
                                     where x.ID == id
                                     select x).FirstOrDefaultAsync();
            if (RequireData == null) return StatusCode(404);
            return StatusCode(200, Json(new { Require = RequireData }));
        }

        [Route("/require/create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDTO data)
        {
            Require newRequire = new();

            newRequire.CourseID = data.CourseID;
            newRequire.Content = data.Content;

            await _elearningContext.AddAsync(newRequire);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, Json(new { Require = newRequire }));
        }
    }
}

