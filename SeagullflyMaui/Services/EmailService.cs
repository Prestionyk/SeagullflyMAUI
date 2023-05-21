using SeagullflyMaui.Interfaces;
using System.Net.Mail;
using System.Net;
using SeagullflyMaui.Model;
using SeagullflyMaui;

namespace Seagullfly.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(EmailRequest request)
        {
            MailMessage mail = new();
            mail.To.Add(Config.GetInstance().SupportEmailAddress);
            mail.From = new MailAddress(request.From);
            mail.Subject = GenerateSubject(request);
            mail.Body = GenerateBody(request);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(Config.GetInstance().SupportEmailAddress, Config.GetInstance().SMTPCredentials),    
                EnableSsl = true
            };
            await smtp.SendMailAsync(mail);
            smtp.Dispose();
        }

        string GenerateSubject(EmailRequest request)
        {
            return $"[{request.From}] [{request.Title}]";
        }

        string GenerateBody(EmailRequest request)
        {
            return $"{request.Description}\n{request.Message}";
        }
    }
}
