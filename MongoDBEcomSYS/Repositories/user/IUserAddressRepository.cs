using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.user
{
    public interface IUserAddressRepository
    {
        public Task<List<UserAddress>> GetbyuserIdAsync(string userId);
        public Task<UserAddress> CreateAsync(UserAddress userAddress);
        public Task<UserAddress> UpdateAsync(UserAddress userAddress);
        public Task DeleteAsync(string id);
    }
}
