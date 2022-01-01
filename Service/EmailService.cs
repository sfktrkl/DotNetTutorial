using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Mail;
using Tutorial.Models;
using System.Text;
using System.Net;
using System.IO;

namespace Tutorial.Service
{
    public class EmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            var mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
                mail.To.Add(toEmail);
            mail.BodyEncoding = Encoding.Default;

            var networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
            var smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            return File.ReadAllText(string.Format(templatePath, templateName));
        }
    }
}
