using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.product;

namespace MongoDBEcomSYS.Services.product
{
    public class CategoryService
    {
        public readonly ICategoryRepository _prodCa;
        public CategoryService(ICategoryRepository prodCa)
        {
            _prodCa = prodCa;
        }
        public async Task<List<ProductCategory>> GetAllProductCategories()
        {
            var lst = await _prodCa.GetAllProductCategoriesAsync();
            if (lst == null)
            {
                return null;
            }
            else
            {
                return lst;
            }
        }
        public async Task<ProductCategory> AddCategory(ProductCategory category)
        {
            var check = await _prodCa.GetProductCategoryAsync(category.Name);
            if (check != null)
            {
                return null;
            }
            var add = await _prodCa.AddProductCategoryAsync(category);
            return add;
        }
        public async Task<ProductCategory> UpdateCategory(ProductCategory productCategory)
        {
            return await _prodCa.UpdateProductCategoryAsync(productCategory);
        }
    }
}
