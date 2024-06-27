using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.product;

namespace MongoDBEcomSYS.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        public readonly InventoryService _InSer;
        public InventoriesController(InventoryService InSer)
        {
            _InSer = InSer;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductInventory productInventory)
        {
            return Ok(await _InSer.Add(productInventory));
        }
    }
}
