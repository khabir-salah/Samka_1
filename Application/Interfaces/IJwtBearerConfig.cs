
using System.Security.Claims;
using Domain.Aggregates.UserAggregate.Entities;

namespace Infrastructure.JWT
{
    public interface IJwtBearerConfig
    {
        Task<string> GenerateJwtAsync(User user);
        Task<IEnumerable<Claim>> GetClaimsAsync(User user);
    }
}
