using MongoDB.Driver;
using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.user
{
    public class RolesRepository : IRolesRepository
    {
        public readonly MongoEcomsysContext _db;
        public RolesRepository(MongoEcomsysContext db) {  _db = db; }
        public async Task<Roles> AddRolesAsync(Roles role)
        {
            await _db.Roles.InsertOneAsync(role);
            return role;
        }

        public Task DeleteRolesAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Roles>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Roles> GetRolesByNameAsync(string name)
        {
            return await _db.Roles.Find(x=>x.Name == name).FirstOrDefaultAsync();
        }

        public Task<Roles> UpdateRolesAsync(Roles role)
        {
            throw new NotImplementedException();
        }
    }
}
