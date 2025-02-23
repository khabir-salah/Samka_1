

using System.Linq.Expressions;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository
{
    public class UserRepository(SamkaDBContext ContextDB) : IUserRepository
    {
        public async Task<User?> GetUserAsync(Expression<Func<User, bool>> predicate)
        {
            return await ContextDB.Users.Include(r => r.Role)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExisAsync(Expression<Func<User, bool>> predicate)
        {
            return await ContextDB.Users.AnyAsync(predicate);
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            await ContextDB.Users.AddAsync(user);
            return user;
        }

        public User UpdateUser(User user)
        {
             ContextDB.Users.Update(user);
             return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await ContextDB.Users.ToListAsync();
        }

        public Task<Role> GetROleAsync(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
