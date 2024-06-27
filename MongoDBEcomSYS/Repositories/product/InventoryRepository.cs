using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public class InventoryRepository : IInventoryRepository
    {
        public readonly MongoEcomsysContext _db;
        public InventoryRepository(MongoEcomsysContext db) {  _db = db; }
        public async Task<ProductInventory> AddProductInventoryAsync(ProductInventory ProductInventory)
        {
            await _db.ProductInventories.InsertOneAsync(ProductInventory);
            return ProductInventory;
        }

        public Task DeleteInventoryAsync(string inventorytId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductInventory> GetProductInventoryAsync(string inventoryId)
        {
            var lst = await _db.ProductInventories.Find(x => x.Id == inventoryId).FirstOrDefaultAsync();
            return lst;
        }

        public async Task<ProductInventory> UpdateProductInventoryAsync(ProductInventory ProductInventory)
        {
            await _db.ProductInventories.ReplaceOneAsync(x=>x.Id==ProductInventory.Id, ProductInventory);
            return ProductInventory;
        }
    }
}
