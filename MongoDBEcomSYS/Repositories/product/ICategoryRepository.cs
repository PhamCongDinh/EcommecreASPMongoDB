using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public interface ICategoryRepository
    {
        public Task<ProductCategory> GetProductCategoryAsync(string name);
        public Task<ProductCategory> GetProductCategoryByIdAsync(string Id);
        public Task<List<ProductCategory>> GetAllProductCategoriesAsync();
        public Task<ProductCategory> AddProductCategoryAsync(ProductCategory ProductCategory);
        public Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory ProductCategory);
        public Task DeleteCategoryAsync(string categoryId);
    }
}
