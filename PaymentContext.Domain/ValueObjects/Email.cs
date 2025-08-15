using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;


namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Email.Address", "Invalid Email")


            );
        }
        public string Address { get; private set; }
    }
}