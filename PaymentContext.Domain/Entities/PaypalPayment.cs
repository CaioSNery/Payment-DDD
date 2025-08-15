
using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string transactionCode,
        string number,
        DateTime paidDate,
         DateTime expireDate,
         decimal total,
         decimal paidTotal,
         Address address,
          string payer,
          Document document,
          Email email) : base(number,
         paidDate,
          expireDate,
          total,
          paidTotal,
          address,
           payer,
           document,
           email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}