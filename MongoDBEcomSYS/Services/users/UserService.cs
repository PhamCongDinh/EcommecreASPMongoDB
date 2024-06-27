using MongoDBEcomSYS.Models;
using MongoDBEcomSYS.Models.DTOsCreated;
using MongoDBEcomSYS.Repositories.user;

namespace MongoDBEcomSYS.Services.users
{
    public class UserService
    {
        public readonly IRolesRepository _rosrv;
        public readonly IUserRepository _uRep;
        public UserService(IRolesRepository rosrv, IUserRepository uRep)
        {
            _rosrv = rosrv;
            _uRep = uRep;
        }
        
        public async Task<User> AddUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }

            var existingUserByUsername = await _uRep.GetByNameAsync(userDTO.Username);
            if (existingUserByUsername != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var existingUserByEmail = await _uRep.GetByEmailAsync(userDTO.Email);
            if (existingUserByEmail != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            User user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Roles = new List<Roles>()
            };

            string name = "User";
            var role = await _rosrv.GetRolesByNameAsync(name);
            if (role != null)
            {
                user.Roles.Add(role);
            }
            else
            {
                throw new InvalidOperationException("Default role 'User' not found.");
            }

            await _uRep.AddUser(user);

            return user;
        }

        public async Task<User> updateuserasync(User user)
        {
            await _uRep.UpdateUser(user);
            return user; 
        }
    }
}
