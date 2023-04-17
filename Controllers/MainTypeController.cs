

using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.MainType;

namespace ELearning.Controllers
{
    [ApiController]

    public class MainTypeController : Controller
    {
        private readonly ILogger<MainTypeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public MainTypeController(ILogger<MainTypeController> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            this._elearningContext = elearningContext;
        }


        [Route("/main_type/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.MainTypes
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("/main_type/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.MainTypes.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("/main_type/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var mainTypeData = await (from x in _elearningContext.MainTypes
                                      where x.ID == id
                                      select x).FirstOrDefaultAsync();
            if (mainTypeData == null) return StatusCode(404);
            return StatusCode(200, Json(new { MainType = mainTypeData }));
        }

        [Route("/main_type/create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDTO data)
        {
            MainType newMainType = new();
            newMainType.TypeName = data.TypeName;

            await _elearningContext.AddAsync(newMainType);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, Json(new { MainType = newMainType }));
        }
    }
}

