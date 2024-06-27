using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public interface IDicountRepository
    {
        public Task<List<Dicounts>> GetAllDicountsAsync();
        public Task<Dicounts> GetDicountsAsync(string dicountId);
        public Task<Dicounts> AddDicountAsync(Dicounts dicounts);
        public Task<Dicounts> UpdateDicountAsync(Dicounts dicounts);
        public Task DeleteDicountAsync(string dicountId);

    }
}
