using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Services.product;

namespace MongoDBEcomSYS.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly ProductService _prodSer;
        public ProductsController(ProductService prodSer)
        {
            _prodSer = prodSer;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDTO)
        {
            var add = await _prodSer.AddProduct(productDTO);
            if (add != null)
            {
                return Ok(add);
            }
            else
            {
                return StatusCode(409, "Sản phẩm đã có");
            }
        }

        [HttpGet]
        public async Task<IActionResult> getallproduct()
        {
            return Ok(await _prodSer.GetProductsAsync());
        }
        [HttpGet("getbyId")]
        public async Task<IActionResult> getbyId(string productId)
        {
            return Ok(await _prodSer.GetById(productId));
        }
        [HttpPut]
        public async Task<IActionResult> update(string Id,ProductDTO productDTO)
        {
            return Ok(await _prodSer.UpdateProduct(Id,productDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> delete(string productId)
        {
            await _prodSer.DeleteProduct(productId);
            return Ok(new {success="Xóa thành công"});
        }
    }
}
