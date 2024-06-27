using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Services.ShopCart;

namespace MongoDBEcomSYS.Controllers.ShopCart
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly ShopCartService _scSe;
        public ShoppingCartsController(ShopCartService scSe)
        {
            _scSe = scSe;
        }
        [HttpPost("addShopCart")]
        public async Task<IActionResult> addshopcart(ShoppingSession shoppingSession)
        {
            var add =await _scSe.AddShopCart(shoppingSession);
            return Ok(add);
        }
        [HttpPost("addCartItem")]
        public async Task<IActionResult> addCartItem(CartItem cartItem)
        {
            try
            {
                var add = await _scSe.AddCartItem(cartItem);
                return Ok(add);
            }
            catch (InvalidOperationException ex)
            {
                // Quantity exceeds available inventory
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> update(CartItem cart)
        {
            try
            {
                var put = await _scSe.updatecart(cart);
                return Ok(put);
            }
            catch(InvalidCastException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
            

            
        }
        [HttpGet("getcartItembysessionId")]
        public async Task<IActionResult> getcart(string sessionId)
        {
            var lst = await _scSe.GetCartItemByShopCartAsync(sessionId);
            if(lst == null|| !lst.Any())
            {
                return NotFound(new { message = "No items found in the shopping cart." });
            }
            return Ok(lst);
        }
    }
}
