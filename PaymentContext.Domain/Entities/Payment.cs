
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal paidTotal, string address, string payer, Document document, Email email)
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
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal PaidTotal { get; private set; }
        public string Address { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
    }

}