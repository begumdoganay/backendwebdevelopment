using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using BookStore_Web_Application.Core.Interfaces.Services;
using BookStore_Web_Application.Core.Settings;

namespace BookStore_Web_Application.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailSettings _emailSettings;

        public EmailService(ILogger<EmailService> logger, IOptions<EmailSettings> emailSettings)
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                if (string.IsNullOrEmpty(_emailSettings.FromAddress))
                {
                    throw new ArgumentNullException(nameof(_emailSettings.FromAddress), "From address cannot be null or empty.");
                }

                var message = new MailMessage
                {
                    From = new MailAddress(_emailSettings.FromAddress),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                message.To.Add(new MailAddress(to));

                using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
                {
                    Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                    EnableSsl = true
                };

                await client.SendMailAsync(message);
                _logger.LogInformation($"Email sent successfully to {to}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending email to {to}");
                throw;
            }
        }
    }

}
