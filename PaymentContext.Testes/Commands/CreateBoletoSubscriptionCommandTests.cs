using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Command;
using PaymentContext.Shared.Commands;


namespace PaymentContext.Testes.Commands
{
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ReturnNameWhenisInValid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";


        }
    }
}