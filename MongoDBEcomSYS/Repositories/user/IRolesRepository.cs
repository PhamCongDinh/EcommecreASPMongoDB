using MongoDBEcomSYS.Models;

namespace MongoDBEcomSYS.Repositories.user
{
    public interface IRolesRepository
    {
        public Task<List<Roles>> GetRolesAsync();
        public Task<Roles> GetRolesByNameAsync(string name);
        public Task<Roles> AddRolesAsync(Roles role);
        public Task<Roles> UpdateRolesAsync(Roles role);
        public Task DeleteRolesAsync(string id);
    }
}
