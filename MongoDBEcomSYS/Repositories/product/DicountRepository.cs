using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.product
{
    public class DicountRepository : IDicountRepository
    {
        public readonly MongoEcomsysContext _db;
        public DicountRepository(MongoEcomsysContext db)
        {
            _db = db;
        }
        public async Task<Dicounts> AddDicountAsync(Dicounts dicounts)
        {
            await _db.Dicounts.InsertOneAsync(dicounts);
            return dicounts;
        }

        public async Task DeleteDicountAsync(string dicountId)
        {
           await _db.Dicounts.DeleteOneAsync(dicountId);
        }

        public async Task<List<Dicounts>> GetAllDicountsAsync()
        {
            var lst = await _db.Dicounts.FindAsync(_ => true);
            return lst.ToList();
        }

        public async Task<Dicounts> GetDicountsAsync(string dicountId)
        {
            var filter = await _db.Dicounts.Find(x => x.Id == dicountId).FirstOrDefaultAsync();
            return filter;
        }

        public async Task<Dicounts> UpdateDicountAsync(Dicounts dicounts)
        {
            await _db.Dicounts.ReplaceOneAsync(x => x.Id == dicounts.Id, dicounts);
            return dicounts;
        }
    }
}
