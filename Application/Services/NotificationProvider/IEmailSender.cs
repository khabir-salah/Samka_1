using Application.DTOs;

namespace Application.Services.NotificationProvider
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailResponseModel mailRequest);
        Task SendEmailVerificationMessage(string email, string name, string code);
        Task SendPasswordResetMessage(string email, string name, string code);
        Task ProviderWelcomeMessage(string email, string name, string code);
    }
}
