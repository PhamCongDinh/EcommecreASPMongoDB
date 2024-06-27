using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.shopping
{
    public interface IShopCartRepository
    {
        public Task<ShoppingSession> CreateShopCart(ShoppingSession shoppingSession);
        public Task<ShoppingSession> UpdateShopCart(ShoppingSession shoppingSession);

    }
}
