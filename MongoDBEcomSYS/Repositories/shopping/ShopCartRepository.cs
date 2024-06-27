using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.shopping
{
    public class ShopCartRepository : IShopCartRepository
    {
        private readonly MongoEcomsysContext _db;
        public ShopCartRepository(MongoEcomsysContext db) { _db = db; }

        public async Task<ShoppingSession> CreateShopCart(ShoppingSession shoppingSession)
        {
            await _db.ShoppingSessions.InsertOneAsync(shoppingSession);
            return shoppingSession;
        }

        public async Task<ShoppingSession> UpdateShopCart(ShoppingSession shoppingSession)
        {
            await _db.ShoppingSessions.ReplaceOneAsync(x =>x.Id==shoppingSession.Id, shoppingSession);
            return shoppingSession;
        }
    }
}
