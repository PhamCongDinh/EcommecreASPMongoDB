using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Repositories.user;

namespace MongoDBEcomSYS.Services.users
{
    public class RolesService
    {
        public readonly IRolesRepository _roR;
        public RolesService(IRolesRepository roR) {  _roR = roR; }
        public async Task<Roles> AddRoles(Roles roles)
        {
            if (roles == null)
            {
                throw new ArgumentNullException(nameof(roles));
            }
            var existingRole = await _roR.GetRolesByNameAsync(roles.Name);
            if (existingRole != null)
            {
                throw new InvalidOperationException("Role already exists.");
            }

            await _roR.AddRolesAsync(roles);
            return roles;
        }
        public async Task<Roles> getbyname(string name)
        {
            return await _roR.GetRolesByNameAsync(name);
        }
    }
}
