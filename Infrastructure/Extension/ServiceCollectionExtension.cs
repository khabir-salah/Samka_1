
using Application.Services.NotificationProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNotificationProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailSender, NotificationSender>();
            services.AddTransient<ISMSSender, NotificationSender>();
            services.Configure<SMSOption>(configuration);
            services.Configure<EmailOption>(configuration);
            return services;
        }
    }
}
