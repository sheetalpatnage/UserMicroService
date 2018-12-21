using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserType.Contracts.Model;
using UserType.Contracts.Interface;
using Microsoft.EntityFrameworkCore;

namespace UserType.Contracts.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IWriteRepository
    {

        public readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAllAsync()
        {
            using (var _context = new UserContext())
            {
                return await _context.Users.ToListAsync();
            }
        }

        public async Task<User> GetByIdAsync(string id)
        {
            using (var _context = new UserContext())
            {
                return await _context.Users.FindAsync(id);
            }
        }

        public  async Task<User> InsertAsync(User entity)
        {
            using (var _context = new UserContext())
            {
                _context.Users.Add(entity);
                var result = await _context.SaveChangesAsync();
                return entity;
            }
        }


        public async Task<User> UpdateAync(string UserId , User entity)
        {
            using (var _context = new UserContext())
            {
                var userdata = _context.Users.FirstOrDefault(x => x.Id == UserId);
                _context.Entry(userdata).CurrentValues.SetValues(entity);
                var result = await _context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
