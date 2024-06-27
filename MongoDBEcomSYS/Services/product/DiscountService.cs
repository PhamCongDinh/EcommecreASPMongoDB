using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.product;

namespace MongoDBEcomSYS.Services.product
{
    public class DiscountService
    {
        public readonly IDicountRepository _disR;
        public DiscountService(IDicountRepository disR)
        {
            _disR = disR;
        }
        public async Task<List<Dicounts>> GetAllDicountsAsync()
        {
            return await _disR.GetAllDicountsAsync();
        } 
        public async Task<Dicounts> AddDiscount(Dicounts dicounts)
        {
            return await _disR.AddDicountAsync(dicounts);
        }
        public async Task<Dicounts> UpdateDiscount(Dicounts dicounts)
        {
            return await _disR.UpdateDicountAsync(dicounts);
        }

    }
}
