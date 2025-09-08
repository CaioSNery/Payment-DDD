
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal paidTotal, Address address, string payer, Document document, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            PaidTotal = paidTotal;
            Address = address;
            Payer = payer;
            Document = document;
            Email = email;

            AddNotifications(new Contract<Payment>()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "The Total is not 0")
                .IsGreaterOrEqualsThan(Total, Total, "Payment.TotalPaid", "Price Insuficient")
            );
        }



        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal PaidTotal { get; private set; }

        [NotMapped]
        public Address Address { get; private set; }
        public string Payer { get; private set; }

        [NotMapped]
        public Document Document { get; private set; }

        [NotMapped]
        public Email Email { get; private set; }
    }

}