using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Testes.Entities
{
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription(null);
            var student = new Student("Caio", "Souza", "06222446558", "caionery40@gmail.com");

            student.AddSubscription(subscription);

        }
    }
}