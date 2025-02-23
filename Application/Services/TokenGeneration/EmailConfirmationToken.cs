

using Domain.Repositories;
using System.Security.Cryptography;

namespace Application.Services.TokenGeneration
{
    public class EmailConfirmationToken(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        public async Task<EmailResponse> GenerateEmailConfirmationToken(string email)
        {

            var tokenData = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(tokenData);

            var user = await userRepository.GetUserAsync(u => u.Email == email);
            var token = user.PasswordResetToken = Convert.ToBase64String(tokenData);
            user.PasswordExpireTime = DateTime.UtcNow.AddDays(1);
            userRepository.UpdateUser(user);
            await unitOfWork.Save();
            return new EmailResponse(token, user.FirstName, user.Id);
        }
    }

    public interface IEmailConfirmationToken
    {
        Task<EmailResponse> GenerateEmailConfirmationToken(string email);
    }

    public record EmailResponse(string Token, string Name, Guid userId);

}

