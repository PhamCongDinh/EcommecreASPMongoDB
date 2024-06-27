using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.user
{
    public class UserAddressRepository : IUserAddressRepository
    {
        public readonly MongoEcomsysContext _db;
        public UserAddressRepository(MongoEcomsysContext db) {  _db = db; }
        public async Task<UserAddress> CreateAsync(UserAddress userAddress)
        {
            await _db.UserAddresses.InsertOneAsync(userAddress);   
            return userAddress;
        }

        public async Task DeleteAsync(string id)
        {
             await _db.UserAddresses.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<List<UserAddress>> GetbyuserIdAsync(string userId)
        {
            var lstAdr = await _db.UserAddresses.Find(x =>x.UserID == userId).ToListAsync();
            return lstAdr;
        }

        public async Task<UserAddress> UpdateAsync(UserAddress userAddress)
        {
            await _db.UserAddresses.ReplaceOneAsync(x =>x.Id==userAddress.Id,userAddress);
            return userAddress;
        }
    }
}
