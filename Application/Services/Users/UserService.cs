

using Application.Exceptions;
using Application.Interfaces;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Users
{
    public class UserService(IHttpContextAccessor accessor, IUserRepository userRepository) : IUserService
    {
        public async Task<User?> LoggedInUser()
        {
            try
            {
                var userId = accessor?.HttpContext?.User?.Claims?.FirstOrDefault(u => u.Type == "Id")?.Value;
                var getUser = await userRepository.GetUserAsync(u => u.Id.ToString() == userId);
                return getUser;
            }
            catch (UnAuthorizeException ex)
            {
                throw new UnAuthorizeException("User Must Be Valid" + ex.Message);
            }
        }
    }
}
