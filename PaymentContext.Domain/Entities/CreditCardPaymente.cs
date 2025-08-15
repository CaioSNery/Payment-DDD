
using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPaymente : Payment
    {
        public CreditCardPaymente(string cardHolderName,
        string cardNumber,
        string lastTransactionNumber, string number,
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
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}