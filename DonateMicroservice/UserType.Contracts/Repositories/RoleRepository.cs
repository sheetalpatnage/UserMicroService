using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserType.Contracts.Interface;
using UserType.Contracts.Model;

namespace UserMicroservice.UserType.Contracts.Repositories
{
    public class RoleRepository : IRoleReadonlyRepository
    {

        private readonly UserContext _context;
        public RoleRepository(UserContext context)
        {
            context = _context;
        }

        public async Task<Role> GetRoleById(int Id)
        {
            using (var _context = new UserContext())
            {
                return await _context.Role.FindAsync(Id);
            }
            
        }
    }
}
