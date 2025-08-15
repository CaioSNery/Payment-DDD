using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Testes.ValueObjects
{
    [TestClass]
    public class DocumentTest : Notifiable<Notification>
    {
        [TestMethod]
        public void ReturnErrorCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ReturnSucessCNPJIsInvalid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void ReturnErrorCPFIsInvalid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void ReturnSucessCPFIsInvalid()
        {
            Assert.Fail();
        }
    }
}