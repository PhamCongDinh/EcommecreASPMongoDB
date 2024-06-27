using MongoDB.Driver;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;

namespace MongoDBEcomSYS.Repositories.product
{
    public class ProductRepository : IProductRepository
    {
        public readonly MongoEcomsysContext _db;
        public ProductRepository(MongoEcomsysContext db)
        {
            _db = db;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _db.Products.InsertOneAsync(product);
            return product;
        }

        public async Task DeleteProductAsync(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);
            await _db.Products.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetProductAsync()
        {
            var filter = Builders<Product>.Filter.Gt(p => p.Inventory.Quantity, 0);
            var lstProduct = await _db.Products.Find(filter).ToListAsync();
            return lstProduct;
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            var Product = await _db.Products.Find(x=>x.Id == productId).FirstOrDefaultAsync();
            return Product;
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            var Product = await _db.Products.Find(x => x.Name == productName).FirstOrDefaultAsync();
            return Product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            await _db.Products.ReplaceOneAsync(x=>x.Id==product.Id, product);
            return product;
        }
    }
}
