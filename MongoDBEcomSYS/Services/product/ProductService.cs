using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Repositories.product;
using System.Security.Cryptography.X509Certificates;

namespace MongoDBEcomSYS.Services.product
{
    public class ProductService
    {
        public readonly IProductRepository _prodRe;
        public readonly IInventoryRepository _inventoryRe;
        public readonly ICategoryRepository _categoryRe;
        public readonly IDicountRepository _DicountRe;
        public ProductService(IProductRepository prodRe, IInventoryRepository inventory,ICategoryRepository category, IDicountRepository dicountRe)
        {
            _prodRe = prodRe;
            _inventoryRe = inventory;
            _DicountRe = dicountRe;
            _categoryRe = category;
        }
        public async Task<Product> AddProduct(ProductDTO productDTO)
        {
            var checkname = await _prodRe.GetProductByNameAsync(productDTO.Name);
            if (checkname != null)
            {
                return null;
            }
            else
            {


                ProductInventory productInventory = new ProductInventory();
                productInventory.Quantity = productDTO.Quantity;
                await _inventoryRe.AddProductInventoryAsync(productInventory);
                var category = await _categoryRe.GetProductCategoryByIdAsync(productDTO.CategoryId);
                Dicounts discount;
                if (productDTO.DicountId == null || productDTO.DicountId=="")
                {
                    discount = null;
                }
                else
                {
                    discount = await _DicountRe.GetDicountsAsync(productDTO.DicountId);

                }
                Product product = new Product();
                product.Name = productDTO.Name;
                product.Sku = productDTO.Sku;
                product.Desc = productDTO.Desc;
                product.Image = productDTO.Image;
                product.Price = productDTO.Price;
                product.Inventory = productInventory;
                product.Category = category;
                product.Dicount = discount;
                await _prodRe.AddProductAsync(product);
                return product;
            }

           
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _prodRe.GetProductAsync();
        }
        public async Task<Product> GetById(string productId)
        {
            return await _prodRe.GetProductByIdAsync(productId);
        }
        public async Task<Product> UpdateProduct(string Id, ProductDTO productDTO)
        {
            var product= await _prodRe.GetProductByIdAsync(Id);
 
            
            var inventory = await _inventoryRe.GetProductInventoryAsync(product.Inventory.Id);
            inventory.Quantity = productDTO.Quantity;
           await _inventoryRe.UpdateProductInventoryAsync(inventory);
            var category = await _categoryRe.GetProductCategoryByIdAsync(productDTO.CategoryId);
            Dicounts discount;
            if (productDTO.DicountId == null)
            {
                discount = null;
            }
            else
            {
                discount = await _DicountRe.GetDicountsAsync(productDTO.DicountId);

            }
            product.Name = productDTO.Name;
            product.Sku = productDTO.Sku;
            product.Desc = productDTO.Desc;
            product.Image = productDTO.Image;
            product.Price = productDTO.Price;
            product.Category= category;
            product.Dicount = discount;
            product.Inventory = inventory;
            return await _prodRe.UpdateProductAsync(product);


        }
        public async Task DeleteProduct(string productId)
        {
            await _prodRe.DeleteProductAsync(productId);
        }
    }
}
