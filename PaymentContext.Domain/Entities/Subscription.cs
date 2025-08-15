using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            Active = true;
            ExpireDate = expireDate;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            _payments = new List<Payment>();
        }

        public bool Active { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get; private set; }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}