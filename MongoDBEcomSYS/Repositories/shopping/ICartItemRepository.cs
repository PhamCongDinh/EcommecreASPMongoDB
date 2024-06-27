using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.shopping
{
    public interface ICartItemRepository
    {
        public Task<List<CartItem>> GetCartItemsByShopSessionIdAsync(string shopSeId);
        public Task<CartItem> GetCartItemsByIdAsync(string Id);
        public Task<CartItem> Check(string Id, string prodId);
        public Task<CartItem> AddCartItem(CartItem cartItem);
        public Task<CartItem> UpdateCartItem(CartItem cartItem);
        public Task DeleteCartItemByID(string Id);
        public Task DeleteCartItemByShopSeId(string shopSeId);
    }
}
