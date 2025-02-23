
using Application.DTOs;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Application.Services.NotificationProvider
{
    public class NotificationSender : IEmailSender, ISMSSender
    {
        public NotificationSender(IOptions<SMSOption> optionsAccessor, IOptions<EmailOption> options)
        {
            Options = optionsAccessor.Value;
            EmailOption = options.Value;
        }

        public SMSOption Options { get; }  
        public EmailOption EmailOption { get; }

        public async Task SendEmailAsync(EmailResponseModel mailRequest)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("SAMKA", EmailOption.SenderEmail));
            message.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;

            var body = new TextPart("html")
            {
                Text = mailRequest.HtmlContent,
            };
            message.Body = body;

            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await client.ConnectAsync(EmailOption.SmtpServer, EmailOption.SmtpPort, false);
                await client.AuthenticateAsync(EmailOption.UserName, EmailOption.Password);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to send email.", ex);
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }

        public Task SendSmsAsync(SmsResponseModel sms)
        {
            ASPSMS.SMS SMSSender = new ASPSMS.SMS();

            SMSSender.Userkey = Options.SMSAccountIdentification;
            SMSSender.Password = Options.SMSAccountPassword;
            SMSSender.Originator = Options.SMSAccountFrom;

            SMSSender.AddRecipient(sms.ToNumber);
            SMSSender.MessageData = sms.Body;

            return Task.FromResult(0);
        }

        public async Task<int> SendVerificationCode(string PhoneNumber)
        {
            var code = new Random().Next(11111, 99999);
            var model = new SmsResponseModel
            {
                Body = $"Your SAMKA Verification code is {code}",
                ToNumber = PhoneNumber,
            };
            await SendSmsAsync(model);
            return code;
        }

        public async Task SendEmailVerificationMessage(string email, string name, string code)
        {

            string subject = "Verify Your SAMKA Account";
            string html = $@"
    <body>
        <div>
            <h1>Welcome to SAMKA😊!</h1>
            <p3>Hi <strong>{name}</strong>,</p3>
            <p>Welcome to SAMKA, Your All in one Home Solution and MArketplace.</p>
            <p>Ready to get started? Simply book for a service and lets our professionals do the rest. we'll do the rest!</p>
            <a href=""{code}"">Confirm your mail first :)</a>
        </div>
        <div>
            <p>If you have any questions or need assistance, feel free to <a href=""mailto:samka.support.com"">contact our support team</a>.</p>
            <p>Thank you for choosing SAMKA❤️❤️❤️!</p>
        </div>
    </body>";

            var model = new EmailResponseModel
            {
                ToName = name,
                HtmlContent = html,
                Subject = subject,
                ToEmail = email,
            };
            await SendEmailAsync(model);
        }


        public async Task SendPasswordResetMessage(string email, string name, string code)
        {

            string subject = "Reset Your SAMKA Account";
            string html = $@"
    <body>
        <div>
            <h1>Welcome to SAMKA😊!</h1>
            <p3>Hi <strong>{name}</strong>,</p3>
            <p>You request for a password reset .</p>
            <p>Ready to get started? Simply book for a service and lets our professionals do the rest. we'll do the rest!</p>
            <a href=""{code}"">Click this link to reset your password :)</a>
        </div>
        <div>
            <p>If you have any questions or need assistance, feel free to <a href=""mailto:samka.support.com"">contact our support team</a>.</p>
            <p>Thank you for choosing SAMKA❤️❤️❤️!</p>
        </div>
    </body>";

            var model = new EmailResponseModel
            {
                ToName = name,
                HtmlContent = html,
                Subject = subject,
                ToEmail = email,
            };
            await SendEmailAsync(model);
        }

        public async Task ProviderWelcomeMessage(string email, string name, string code)
        {

            string subject = "Reset Your SAMKA Account";
            string html = $@"
    <body>
        <div>
            <h1>Welcome to SAMKA😊!</h1>
            <p3>Hi <strong>{name}</strong>,</p3>
            <p>Thank you for joining us you made the right choice.</p>
            <p>Confirm your Email here for joing us. after confirmation you can proceed to login with ur email and your phoneNumber been your temporary password. u are adviced to change it. </p>
            <a href=""{code}"">Click this link to confirm joining Us and proceed to login:)</a>
        </div>
        <div>
            <p>If you have any questions or need assistance, feel free to <a href=""mailto:samka.support.com"">contact our support team</a>.</p>
            <p>Thank you for choosing SAMKA❤️❤️❤️!</p>
        </div>
    </body>";

            var model = new EmailResponseModel
            {
                ToName = name,
                HtmlContent = html,
                Subject = subject,
                ToEmail = email,
            };
            await SendEmailAsync(model);
        }
    }
}
