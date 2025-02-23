
using System.Linq.Expressions;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Sheared.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User?> GetUserAsync(Expression<Func<User, bool>> predicate);
        Task<bool> IsExisAsync(Expression<Func<User, bool>> predicate);
        User UpdateUser(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
