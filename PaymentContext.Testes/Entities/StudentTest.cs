using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Testes.Entities
{
    public class StudentTest
    {
        [TestMethod]
        public void ReturnErrorActiveSubscription()
        {
            var name = new Name("BRuce", "Wayne");
            var document = new Document("06222446558", EDocumentType.CPF);
            var email = new Email("bruce@balta.io");
            var addres = new Address("rua 1", "14", "centro", "LF", "BA", "BR", "42700", "Re");
            var subscription = new Subscription(DateTime.Now);
            var payment = new PaypalPayment("001001", "1025", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, addres, "Wayne", document, email);
            var student = new Student(name, document, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            Assert.Fail();
        }

        [TestMethod]
        public void ReturnSucessActiveSubscription()
        {


        }
    }
}