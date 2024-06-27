using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;

namespace MongoDBEcomSYS.Repositories.user
{
    public interface IUserRepository
    {
        public Task<User> GetByNameAsync(string name);
        public Task<User> GetByEmailAsync(string email);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
       
    }
}
