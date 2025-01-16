using boilerplate.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace boilerplate.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<SmtpSettings> smtpSettings, IOptions<EmailSettings> emailSettings)
        {
            _smtpSettings = smtpSettings.Value;
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string[] to, string subject, string content)
        {
            MailMessage mailMessage = new()
            {
                Subject = subject,
                IsBodyHtml = true
            };

            foreach (string s in to)
            {
                mailMessage.To.Add(s);
            }

            mailMessage.From = new MailAddress(_emailSettings.Adress);

            SmtpClient client = new(_smtpSettings.Server)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = true
            };
            return client.SendMailAsync(mailMessage);
        }
    }
}
