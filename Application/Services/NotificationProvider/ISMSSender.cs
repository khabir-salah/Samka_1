using Application.DTOs;

namespace Application.Services.NotificationProvider
{
    public interface ISMSSender
    {
        Task SendSmsAsync(SmsResponseModel sms);
        Task<int> SendVerificationCode(string PhoneNumber);
    }
}
