using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.users;

namespace MongoDBEcomSYS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoUsersController : ControllerBase
    {
        public readonly UserAddressService _userAdrSer;
        public InfoUsersController(UserAddressService userAdrSer)
        {
            _userAdrSer = userAdrSer;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserAddress userAddress)
        {
            return Ok(await _userAdrSer.AddUserAddress(userAddress));
        }
        [HttpGet("getbyuserId")]
        public async Task<IActionResult> Get(string userId)
        {
            var lst = await _userAdrSer.getbyuserId(userId);
            if (lst == null)
            {
                return Ok(new { success = "chưa có địa chỉ nào" });
            }
            else
            {
                return Ok(lst);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserAddress userAddress)
        {
            return Ok(await _userAdrSer.updateAdr(userAddress));
        }
        [HttpDelete]
        public async Task<IActionResult> delete(string id)
        {
            await _userAdrSer.DeleteAdr(id);
            return Ok(new {success="xóa thành công"});
        }
    }
}
