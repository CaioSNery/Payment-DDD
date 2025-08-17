using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Testes.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExists(string document)
        {
            if (document == "00000000000")
                return true;
            return false;
        }

        public bool EmailSExists(string email)
        {
            if (email == "hello@hi.com")
                return true;
            return false;
        }
    }
}