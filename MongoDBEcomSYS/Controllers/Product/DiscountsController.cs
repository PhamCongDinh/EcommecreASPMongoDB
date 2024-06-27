using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.product;

namespace MongoDBEcomSYS.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly DiscountService _disSe;
        public DiscountsController(DiscountService disSe)
        {
            _disSe = disSe;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _disSe.GetAllDicountsAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Dicounts dicounts)
        {
            return Ok(await _disSe.AddDiscount(dicounts));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Dicounts dicounts)
        {
            return Ok(await _disSe.UpdateDiscount(dicounts));
        }
        
    }
}
