using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.product;

namespace MongoDBEcomSYS.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _cateSe;
        public CategoriesController(CategoryService cateSe)
        {
            _cateSe = cateSe;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lstcategory = await _cateSe.GetAllProductCategories();
            if (lstcategory == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstcategory);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCategory category)
        {
            var add = await _cateSe.AddCategory(category);
            if (add == null) {
                return BadRequest();
            }
            else
            {
                return Ok(add);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductCategory category)
        {
            return Ok(await _cateSe.UpdateCategory(category));
        }
    }
}
