using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public interface IProductRepository
    {
        public Task<Product> AddProductAsync(Product product);
        public Task<Product> UpdateProductAsync(Product product);
        public Task DeleteProductAsync(string productId);
        public Task<List<Product>> GetProductAsync();
        public Task<Product> GetProductByIdAsync(string productId);
        public Task<Product> GetProductByNameAsync(string productName);
    }
}
