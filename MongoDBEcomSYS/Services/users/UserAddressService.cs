using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.user;

namespace MongoDBEcomSYS.Services.users
{
    public class UserAddressService
    {
        public readonly IUserAddressRepository _uadre;
        public UserAddressService(IUserAddressRepository uadre) {  _uadre = uadre; }
        public async Task<UserAddress> AddUserAddress(UserAddress userAddress)
        {
            return await _uadre.CreateAsync(userAddress);
        }
        public async Task<List<UserAddress>> getbyuserId(string userId)
        {
            var lst = await _uadre.GetbyuserIdAsync(userId);
            if (lst == null|| !lst.Any())
            {
                return null;
            }
            else
            {
                return lst;
            }
        }
        public async Task<UserAddress> updateAdr(UserAddress userAddress)
        {
            return await _uadre.UpdateAsync(userAddress);  
        }
        public async Task DeleteAdr(string id)
        {
            await _uadre.DeleteAsync(id);
        }
    }
}
