using MongoDB.Driver;
using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;

namespace MongoDBEcomSYS.Repositories.user
{
    public class UserRepository : IUserRepository
    {
        public MongoEcomsysContext _db;
        public UserRepository(MongoEcomsysContext db)
        {
            _db = db;
        }
        public async Task<User> AddUser(User user)
        {
           await _db.Users.InsertOneAsync(user);
            return user;

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.Find(x=>x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _db.Users.Find(x=>x.Username == name).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            await _db.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
            return user;
        }
    }
}
