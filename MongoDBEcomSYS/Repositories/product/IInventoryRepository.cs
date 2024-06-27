using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public interface IInventoryRepository
    {
        public Task<ProductInventory> GetProductInventoryAsync(string inventoryId);
        public Task<ProductInventory> AddProductInventoryAsync(ProductInventory ProductInventory);
        public Task<ProductInventory> UpdateProductInventoryAsync(ProductInventory ProductInventory);
        public Task DeleteInventoryAsync(string inventorytId);
    }
}
