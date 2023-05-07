using ELearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ELearning.Commons.Constants;
using ELearning.DTOs.User;

namespace ELearning.Controllers.AdminControllers.AdminUserControllers
{
    [ApiController]

    public class AdminRoleControllers : Controller
    {
        private readonly ILogger<AdminRoleControllers> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ElearningContext _elearningContext;
        public AdminRoleControllers(ILogger<AdminRoleControllers> logger, IWebHostEnvironment env, ElearningContext elearningContext)
        {
            _logger = logger;
            _env = env;
            _elearningContext = elearningContext;
        }


        [Route("admin/role/all")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var list = await (from n in _elearningContext.Roles
                              orderby n.ID ascending
                              select n).ToListAsync();
            return StatusCode(200, Json(list));
        }

        [Route("admin/role/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var s = await _elearningContext.MainTypes.SingleAsync(x => x.ID == id);
            _elearningContext.Remove(s);
            return StatusCode(200, Json(ErrorCode.SUCCESS));
        }

        [Route("admin/role/find/{id}")]
        [HttpGet]
        public async Task<IActionResult> Find([FromRoute] int id)
        {
            var mainTypeData = await (from x in _elearningContext.MainTypes
                                      where x.ID == id
                                      select x).FirstOrDefaultAsync();
            if (mainTypeData == null) return StatusCode(404);
            return StatusCode(200, Json(new { MainType = mainTypeData }));
        }

        [Route("admin/role/create")]
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

