using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using UserType.Contracts.Model;

namespace UserType.Contracts.Interface
{
    public interface IUserReadOnlyRepository
    {
         Task<List<User>> FindAllAsync();

         Task<User> GetByIdAsync(string id);       

    }

    public interface IRoleReadonlyRepository
    {
        Task<Role> GetRoleById(int Id);

    }

}
