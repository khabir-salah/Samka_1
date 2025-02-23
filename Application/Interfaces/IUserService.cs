

using Domain.Aggregates.UserAggregate.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoggedInUser();
    }
}
