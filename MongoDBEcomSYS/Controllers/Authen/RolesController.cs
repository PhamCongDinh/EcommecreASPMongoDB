using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.users;

namespace MongoDBEcomSYS.Controllers.Authen
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public readonly RolesService _roleService;
        public RolesController(RolesService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> Getbyname(string name)
        {
            return Ok(await _roleService.getbyname(name));
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Roles role)
        {
            if (role == null)
            {
                return BadRequest("Role is null.");
            }

            try
            {
                var addedRole = await _roleService.AddRoles(role);
                return Ok(addedRole);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}
