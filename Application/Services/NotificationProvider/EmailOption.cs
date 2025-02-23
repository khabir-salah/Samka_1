

namespace Application.Services.NotificationProvider
{
    public class EmailOption
    {
        public string SmtpServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderEmail { get; set; }
        public int SmtpPort { get; set; }
    }
}
