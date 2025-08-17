using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;


namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            if (string.IsNullOrEmpty(FirstName))
                AddNotification("Name.FirstName", "Invalid Name");

            if (string.IsNullOrEmpty(LastName))
                AddNotification("Name.FirstName", "Invalid Name");

            AddNotifications(new Contract<Name>()
            .Requires()

            );

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}";
        }
    }
}