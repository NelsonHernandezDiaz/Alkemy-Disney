using Disney.Application.Interfaces;
using Disney.Application.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration Iconfiguration;
        public EmailService(IConfiguration Iconfiguration)
        {
            this.Iconfiguration = Iconfiguration;
        }
        
        public async Task SendMail(EmailInfo email)
        {
            var apiKey = Iconfiguration.GetSection("XXXXXXXXXXXXXXXXXXXXXXXX").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email.Sender);
            var to = new EmailAddress(email.Sender);

            var htmlContent = "";
            var textContent = ($"Tu registro en la plataforma ha sido exitoso tu usuario es {email.Receiver}");

            try
            {
                var message = await Task.Run(() => MailHelper.CreateSingleEmail(from, to, email.Subject, textContent, htmlContent));
                var response = await client.SendEmailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
