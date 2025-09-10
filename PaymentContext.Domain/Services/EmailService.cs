using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PaymentContext.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpClient = new SmtpClient
            {
                Host = _configuration["EmailSettings:SmtpHost"],
                Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    _configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]
                )
            };
        }



        public void Send(string to, string email, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:From"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            _smtpClient.Send(mailMessage);
        }
    }
}
