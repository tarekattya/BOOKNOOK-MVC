using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BookStore.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fromEmail = "ta4280429@gmail.com";
            var fromPassword = "zfmi hejh qxro mdhs"; // Use App Password

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpClient.EnableSsl = true;

                using (var message = new MailMessage(fromEmail, email, subject, htmlMessage))
                {
                    message.IsBodyHtml = true;
                    await smtpClient.SendMailAsync(message);
                }
            }
        }
    }
}
