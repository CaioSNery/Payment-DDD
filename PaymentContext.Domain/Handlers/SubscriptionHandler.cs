using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _email;
        public SubscriptionHandler(IStudentRepository repository, IEmailService email)
        {
            _repository = repository;
            _email = email;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            if (_repository.DocumentExists(command.Document))
                AddNotification("Documento", "CPF ja em uso");

            if (_repository.EmailSExists(command.Email))
                AddNotification("Email", "Email ja cadastrado");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);

            var address = new Address(command.Street, command.Number, command.Neighborhood,
            command.City, command.State, command.Country, command.ZipCode, command.Type);

            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var student = new Student(name, document, email);

            var payment = new BoletoPayment(command.BarraCode, command.BoletoNumber, command.Number,
            command.PaidDate, command.ExpireDate, command.Total, command.PaidTotal,
            address, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, subscription, student, payment);

            _repository.CreateSubscription(student);

            _email.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo", "Assinatura criada");

            return new CommandResult(true, "Assinatura Realizada com sucesso!");
        }
    }
}