using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.product;

namespace MongoDBEcomSYS.Services.product
{
    public class InventoryService
    {
        public readonly IInventoryRepository _InRe;
        public InventoryService(IInventoryRepository InRe) { _InRe = InRe; }   
        public async Task<ProductInventory> Add(ProductInventory productInventory)
        {
            return await _InRe.AddProductInventoryAsync(productInventory);
        }
    }
}
