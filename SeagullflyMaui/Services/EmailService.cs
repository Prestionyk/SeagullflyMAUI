using SeagullflyMaui.Interfaces;
using System.Net.Mail;
using System.Net;
using SeagullflyMaui.Model;

namespace Seagullfly.Services
{
    public class EmailService : IEmailService
    {
        const string To = "smtptestforproject@gmail.com";

        public async Task SendAsync(EmailRequest request)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(request.From);
            mail.Subject = GenerateSubject(request.Title, request.From);
            mail.Body = request.Message;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(To, "qjucyvitclhlhbtf"),    
                EnableSsl = true
            };
            await smtp.SendMailAsync(mail);
            smtp.Dispose();
        }

        string GenerateSubject(string subject, string from)
        {
            return $"[{from}] [{subject}]";
        }
    }
}
