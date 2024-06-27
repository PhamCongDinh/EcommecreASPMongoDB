using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.shopping
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly MongoEcomsysContext _db;
        public CartItemRepository(MongoEcomsysContext db) { _db = db; }   
        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            await _db.CartItems.InsertOneAsync(cartItem);   
            return cartItem;
        }

        public async Task<CartItem> Check(string Id, string prodId)
        {
            var filter = Builders<CartItem>.Filter.And(
                   Builders<CartItem>.Filter.Eq(item => item.SessionId, Id),
                   Builders<CartItem>.Filter.Eq(item => item.ProductId, prodId)
               );
            var cart = await _db.CartItems.Find(filter).FirstOrDefaultAsync();
            return cart;
        }

        public async Task DeleteCartItemByID(string Id)
        {
            await _db.CartItems.DeleteOneAsync(x => x.Id== Id);
        }

        public async Task DeleteCartItemByShopSeId(string shopSeId)
        {
            await _db.CartItems.DeleteManyAsync(x => x.SessionId == shopSeId);

        }

        public async Task<CartItem> GetCartItemsByIdAsync(string Id)
        {
            var cart = await _db.CartItems.Find(x =>x.Id== Id).FirstOrDefaultAsync();
            return cart;
        }

        public async Task<List<CartItem>> GetCartItemsByShopSessionIdAsync(string shopSeId)
        {
            var lstccart = await _db.CartItems.Find(x =>x.SessionId== shopSeId).ToListAsync();
            return lstccart;
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            await _db.CartItems.ReplaceOneAsync(x =>x.Id==cartItem.Id, cartItem);
            return cartItem;
        }
    }
}
