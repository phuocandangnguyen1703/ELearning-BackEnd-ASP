using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.User;

namespace ELearning.Controllers.AdminControllers.AdminUserControllers
{
    [ApiController]

    public class AdminUserControllers : Controller
    {
        private readonly ILogger<AdminUserControllers> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public AdminUserControllers(ILogger<AdminUserControllers> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("admin/user/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Users
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("admin/user/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.Users.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("admin/user/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var userData = await (from x in _elearningContext.Users
                                      where x.ID == id
                                      select x).FirstOrDefaultAsync();
            if (userData == null) return StatusCode(404);
            return StatusCode(200, Json(new { MainType = userData }));
        }

        [Route("admin/user/create")]
        [HttpPost]
        public async Task<IActionResult> Create(Role data)
        {
            Role newRole = new();
            newRole.Type = data.Type;
            newRole.RoleDescription = data.RoleDescription;

            await _elearningContext.AddAsync(newRole);
            await _elearningContext.SaveChangesAsync();
            return StatusCode(200, Json(new { MainType = newRole }));
        }
    }
}

