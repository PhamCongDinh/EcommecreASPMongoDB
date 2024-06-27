using MongoDB.Driver;
using MongoDBEcomSYS.Models;
using System.Xml.Linq;

namespace MongoDBEcomSYS.Repositories.product
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly MongoEcomsysContext _db;
        public CategoryRepository(MongoEcomsysContext db)
        {
            _db = db;
        }
        public async Task<ProductCategory> AddProductCategoryAsync(ProductCategory ProductCategory)
        {
            await _db.ProductCategories.InsertOneAsync(ProductCategory);
            return ProductCategory;
            
        }

        public Task DeleteCategoryAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductCategory>> GetAllProductCategoriesAsync()
        {
            var lstcate = await _db.ProductCategories.FindAsync(_=>true);
            return lstcate.ToList();
        }

        public async Task<ProductCategory> GetProductCategoryAsync(string name)
        {
            var lst = await _db.ProductCategories.Find(x => x.Name == name).FirstOrDefaultAsync();
            return lst;
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(string Id)
        {
            var lst = await _db.ProductCategories.Find(x => x.Id == Id).FirstOrDefaultAsync();
            return lst;
        }

        public async Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory ProductCategory)
        {
            await _db.ProductCategories.ReplaceOneAsync(x => x.Id == ProductCategory.Id, ProductCategory);
            return ProductCategory;
        }
    }
}
