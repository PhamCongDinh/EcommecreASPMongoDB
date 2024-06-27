using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Services.order;

namespace MongoDBEcomSYS.Controllers.ShopCart
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _OdSe;
        public OrdersController(OrderService odSe)
        {
            _OdSe = odSe;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CheckOut checkOut)
        {
            return Ok(await _OdSe.Add(checkOut));

        }
    }
}
