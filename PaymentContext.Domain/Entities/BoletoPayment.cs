using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barraCode,
         string boletoNumber, string number,
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
            BarraCode = barraCode;
            BoletoNumber = boletoNumber;
        }

        public string BarraCode { get; private set; }

        public string BoletoNumber { get; private set; }

    }
}