
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Testes.Mocks;

namespace PaymentContext.Testes.Handlers
{
    [TestClass]
    public class SubscriptionHandlerstests
    {
        [TestMethod]
        public void ReturnErrorDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "00000000000";
            command.Email = "hello@hi.com";
            command.City = "Mahantan";
            command.Street = "Teste";
            command.Number = "12";
            command.Neighborhood = "111";
            command.State = "AM";
            command.Country = "BR";
            command.ZipCode = "41500";
            command.Type = "CEP";
            command.BarraCode = "12132";
            command.BoletoNumber = "5465465";
            command.PaymentNumber = "546546";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.PaidTotal = 60;
            command.Payer = "WAyne";
            command.PayerDocument = "05626548458";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "bat@dc.com";

            handler.Handle(command);
            Assert.AreEqual(false, command.Valid);
        }
    }
}