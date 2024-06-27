using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.users;

namespace MongoDBEcomSYS.Controllers.Authen
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthensController : ControllerBase
    {
        public readonly UserService _useSv;
        public AuthensController(UserService useSv)
        {
            _useSv = useSv;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is null.");
            }

            try
            {
                var user = await _useSv.AddUser(userDTO);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                // Xử lý lỗi trùng lặp username hoặc email
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                return StatusCode(500, new { message = "An error occurred while creating the user.", details = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> update(User user)
        {
            return Ok(await _useSv.updateuserasync(user));
        }
    }
}
