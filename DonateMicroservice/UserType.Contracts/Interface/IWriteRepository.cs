using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserType.Contracts.Model;


namespace UserType.Contracts.Interface
{ 
    public interface IWriteRepository
    {
        Task<User> InsertAsync(User entity);

        Task<User> UpdateAync(string Id, User entity);
    }
}
