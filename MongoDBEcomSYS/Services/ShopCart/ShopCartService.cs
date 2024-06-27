using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsGet;
using MongoDBEcomSYS.Repositories.product;
using MongoDBEcomSYS.Repositories.shopping;

namespace MongoDBEcomSYS.Services.ShopCart
{
    public class ShopCartService
    {
        private readonly IShopCartRepository _shopRe;
        private readonly ICartItemRepository _cartItemRe;
        private readonly IProductRepository _productRe;
        public ShopCartService(IShopCartRepository shopRe, ICartItemRepository cartItemRe, IProductRepository productRe)
        {
            _shopRe = shopRe;
            _cartItemRe = cartItemRe;
            _productRe = productRe;
        }

        public async Task<ShoppingSession> AddShopCart(ShoppingSession shoppingSession)
        {
            return await _shopRe.CreateShopCart(shoppingSession);
        }
        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            var checkquantity = await _productRe.GetProductByIdAsync(cartItem.ProductId);
            var check = await _cartItemRe.Check(cartItem.SessionId, cartItem.ProductId);
            if (check != null)
            {
                check.Quantity += cartItem.Quantity;
                if(check.Quantity > checkquantity.Inventory.Quantity)
                {
                    throw new InvalidOperationException("The quantity exceeds available inventory.");
                }
                var update = await _cartItemRe.UpdateCartItem(check);
                return update;
            }
            else
            {
                if(cartItem.Quantity > checkquantity.Inventory.Quantity)
                {
                    throw new InvalidOperationException("The quantity exceeds available inventory.");
                }
                await _cartItemRe.AddCartItem(cartItem);
                return cartItem;
            }
        }

        public async Task<List<CartItemDetail>> GetCartItemByShopCartAsync(string shoppingCartId)
        {
            var cartItemDetails = new List<CartItemDetail>();

            var cartItems = await _cartItemRe.GetCartItemsByShopSessionIdAsync(shoppingCartId);

            if (cartItems != null)
            {
                foreach (var cartItem in cartItems)
                {
                    var product = await _productRe.GetProductByIdAsync(cartItem.ProductId);

                    if (product != null)
                    {
                        decimal discountPercent = product.Dicount?.DiscountPercent ?? 0;
                        decimal priceAfterDiscount = product.Price * (1 - (discountPercent / 100));
                        decimal sumMoney = cartItem.Quantity * priceAfterDiscount;

                        var cartItemDetail = new CartItemDetail
                        {
                            Id = cartItem.Id,
                            SessionId = cartItem.SessionId,
                            ProductId = cartItem.ProductId,
                            Product = product,
                            Quantity = cartItem.Quantity,
                            SumMoney = sumMoney
                        };

                        cartItemDetails.Add(cartItemDetail);
                    }
                }
            }
            else
            {
                return null;
            }

            return cartItemDetails;
        }
        public async Task<CartItem> updatecart(CartItem cart)
        {
            var product = await _productRe.GetProductByIdAsync(cart.ProductId);
            if(cart.Quantity > product.Inventory.Quantity)
            {
                throw new InvalidOperationException("The quantity exceeds available inventory.");
            }
            else
            {
                var update = await _cartItemRe.UpdateCartItem(cart);
                return update;
            }
        }

    }
}
