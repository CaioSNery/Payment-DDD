using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}